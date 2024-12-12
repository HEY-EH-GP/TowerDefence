using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloonPathManager : MonoBehaviour
{
    public enum PatrolType
    {
        ClockWise,
        CounterClockwise
    }

    public Transform[] pathPoints;
    public PatrolType patrolType;

    public Bloon[] bloons;

    private void Start()
    {
        foreach (Bloon bloon in bloons)
        {
            bloon.TargetIndex = Random.Range(0, pathPoints.Length);
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < bloons.Length; i++)
        {
            SetNewTarget(i);
            MoveTowardsTarget(i);
        }
    }

    private void MoveTowardsTarget(int index)
    {
        // move towards target
        Vector3 newPosition = Vector3.MoveTowards(bloons[index].GetPosition(), pathPoints[bloons[index].TargetIndex].position, bloons[index].speed * Time.deltaTime);
        bloons[index].SetPosition(newPosition);
    }

    private void SetNewTarget(int index)
    {
        // if you are close to the current target
        if (Vector3.Distance(pathPoints[bloons[index].TargetIndex].position, bloons[index].GetPosition()) > 0.5f) return;

        // get a new target
        switch (patrolType)
        {
            case PatrolType.ClockWise:
                bloons[index].TargetIndex = (bloons[index].TargetIndex + 1) % pathPoints.Length;
                break;

            case PatrolType.CounterClockwise:
                bloons[index].TargetIndex = (bloons[index].TargetIndex - 1 + pathPoints.Length) % pathPoints.Length;
                break;

            default:
                Debug.Log("Error!");
                break;

        }
    }

}

