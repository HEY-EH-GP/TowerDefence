using System.Collections.Generic;
using UnityEngine;

public class BloonPathManager : MonoBehaviour
{
    private static BloonPathManager instance;
    public static BloonPathManager Instance
    {
        get { return instance; }
    }

    public enum PatrolType
    {
        StartToEnd,
        ClockWise,
        CounterClockwise
    }

    public PatrolType patrolType;
    public Transform[] pathPoints;

    [HideInInspector]
    public List<Bloon> bloons = new List<Bloon>();


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } 
        else 
        {
            instance = this;
        }
    }

    private void FixedUpdate()
    {
        HandleBloons();
    }
    
    private void HandleBloons()
    {
        if (bloons.Count == 0) return;

        // Use a `for` loop and decrement the index when removing
        for (int i = 0; i < bloons.Count; i++)
        {
            Bloon bloon = bloons[i];

            // Check if the bloon is active
            if (!bloon.gameObject.activeInHierarchy)
            {
                bloons.RemoveAt(i);
                i--; // Adjust index to account for the removed item
                continue;
            }

            // Check if the bloon is close to its target
            if (Vector3.Distance(pathPoints[bloon.targetIndex].position, bloon.GetPosition()) < 0.5f)
            {
                if (bloon.targetIndex == pathPoints.Length - 1)
                {
                    // Reached the final target, deactivate and remove
                    bloon.gameObject.SetActive(false);
                    bloons.RemoveAt(i);
                    i--; // Adjust index after removal
                    continue;
                }

                // Set a new target if not at the final point
                SetNewTarget(bloon);
            }

            // Move the bloon towards the target
            MoveTowardsTarget(bloon);
        }
    }

    private void MoveTowardsTarget(Bloon bloon)
    {
        // move towards target
        Vector3 newPosition = Vector3.MoveTowards(bloon.GetPosition(), pathPoints[bloon.targetIndex].position, bloon.speed * Time.deltaTime);
        bloon.SetPosition(newPosition);
    }

    private void SetNewTarget(Bloon bloon)
    {
        // get a new target
        switch (patrolType)
        {
            case PatrolType.StartToEnd:
                if(bloon.targetIndex < pathPoints.Length - 1)
                    bloon.targetIndex++;
                break;

            case PatrolType.ClockWise:
                bloon.targetIndex = (bloon.targetIndex + 1) % pathPoints.Length;
                break;

            case PatrolType.CounterClockwise:
                bloon.targetIndex = (bloon.targetIndex - 1 + pathPoints.Length) % pathPoints.Length;
                break;

            default:
                Debug.Log("Error!");
                break;
        }
    }

}

