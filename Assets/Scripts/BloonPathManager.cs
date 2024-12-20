using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloonPathManager : MonoBehaviour
{
    public enum PatrolType
    {
        StartToEnd,
        ClockWise,
        CounterClockwise
    }

    public PatrolType patrolType;
    public Transform[] pathPoints;

    
    private List<Bloon> bloons;
    
    private void FixedUpdate()
    {
        HandleBloons();
    }

    public void AddBloon(Bloon bloon)
    {
        bloons.Add(bloon);
    }
    
    private void HandleBloons()
    {
        foreach (Bloon bloon in bloons)
        {

            if (!bloon.gameObject.activeInHierarchy) continue;

            // if you are close to the current target
            if (Vector3.Distance(pathPoints[bloon.TargetIndex].position, bloon.GetPosition()) < 0.5f)
            {
                if (bloon.TargetIndex == pathPoints.Length - 1)
                {
                    bloon.gameObject.SetActive(false);
                    continue;
                }
                SetNewTarget(bloon);
            }
            MoveTowardsTarget(bloon);
        }
    }

    private void MoveTowardsTarget(Bloon bloon)
    {
        // move towards target
        Vector3 newPosition = Vector3.MoveTowards(bloon.GetPosition(), pathPoints[bloon.TargetIndex].position, bloon.speed * Time.deltaTime);
        bloon.SetPosition(newPosition);
    }

    private void SetNewTarget(Bloon bloon)
    {
        // get a new target
        switch (patrolType)
        {
            case PatrolType.StartToEnd:
                if(bloon.TargetIndex < pathPoints.Length - 1)
                    bloon.TargetIndex++;
                break;

            case PatrolType.ClockWise:
                bloon.TargetIndex = (bloon.TargetIndex + 1) % pathPoints.Length;
                break;

            case PatrolType.CounterClockwise:
                bloon.TargetIndex = (bloon.TargetIndex - 1 + pathPoints.Length) % pathPoints.Length;
                break;

            default:
                Debug.Log("Error!");
                break;
        }
    }

}

