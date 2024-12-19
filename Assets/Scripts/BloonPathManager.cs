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
        public bool blockNextWave;
    }

    public struct WaveTimer
    {
        public float _quantityToSpawn;
        public float time;
        public int index;
        public bool _waveStarted;

        public WaveTimer(float quantity, float time, int index = 0, bool waveStarted = false)
        {
            _quantityToSpawn = quantity;
            this.time = time;
            this.index = index;
            _waveStarted = waveStarted;
        }
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

    public List<Wave> waves = new List<Wave>();

    private void FixedUpdate()
    {
        SpawnWaves();
        HandleBloons();
    }

    List<WaveTimer> waveTimers = new List<WaveTimer>();

    private void SpawnWaves()
    {
        waveTimers.Add(new WaveTimer(waves[0].quantity, waves[0].spawnDelay));

        //if(!waveStarted)
        //{
        //    bloonsToSpawn = waves[index].quantity;
        //    time = waves[index].spawnDelay;
        //    waveStarted = true;
        //}

        //if (bloonsToSpawn <= 0)
        //{
        //    //se avete spawnato tutte le wave 
        //    if(index >= waves.Count - 1)
        //        return;

        //    //altrimenti fai partire la prossima;
        //    index++;
        //    waveStarted = false;
        //}; 
            
        //time -= Time.deltaTime;

        //if(time <= 0)
        //{
        //    Bloon newBloon = Instantiate(waves[index].type, pathPoints[0].position, Quaternion.identity);
        //    bloons.Add(newBloon);

        //    bloonsToSpawn--;
        //    time = waves[index].spawnDelay;
        //}
        
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

