using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloonPathManager : MonoBehaviour
{

    [System.Serializable]
    public struct Wave
    {
        public float quantity;
        public Bloon type;
        public float spawnDelay;
        public bool waveStarted;
    }

    public enum PatrolType
    {
        StartToEnd,
        ClockWise,
        CounterClockwise
    }

    public Transform[] pathPoints;
    public PatrolType patrolType;

    public List<Bloon> bloons;

    public Wave wave;

    private void Start()
    {
        foreach (Bloon bloon in bloons)
        {
            bloon.TargetIndex = Random.Range(0, pathPoints.Length);
        }
    }

    private void FixedUpdate()
    {
        SpawnWaves();
        HandleBloons();
    }

    float bloonsToSpawn = 0;
    float time = 0;
    private void SpawnWaves()
    {
        if(wave.waveStarted == false)
        {
            bloonsToSpawn = wave.quantity;
            time = wave.spawnDelay;
            wave.waveStarted = true;
        }
        while(bloonsToSpawn > 0)
        {
            time -= Time.deltaTime;

           if(time <= 0)
            {
                Bloon newBloon = Instantiate(wave.type, pathPoints[0].position, Quaternion.identity);
                bloons.Add(newBloon);

                bloonsToSpawn--;
                time = wave.spawnDelay;
            }
        }
    }

    private void HandleBloons()
    {
        foreach (Bloon bloon in bloons)
        {
            // if you are close to the current target
            if (Vector3.Distance(pathPoints[bloon.TargetIndex].position, bloon.GetPosition()) < 0.5f)
            {
                if (bloon.TargetIndex == pathPoints.Length - 1)
                {
                    Destroy(bloon.gameObject);
                    bloons.Remove(bloon);
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
                    bloon.TargetIndex = bloon.TargetIndex++;
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

