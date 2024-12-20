using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloonSpawner : MonoBehaviour
{
    public List<RoundSO> rounds;
    private int currentRound;
    
    
    private void FixedUpdate()
    {
        SpawnWaves();
    }

    private void SpawnWaves()
    {
        int currentWave = rounds[currentRound].currentWave;
        List<WaveData> waveDatas = rounds[currentRound].waves[currentWave].waveDatas;

        
        
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
}
