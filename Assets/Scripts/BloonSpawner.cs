using System.Collections.Generic;
using UnityEngine;

public class BloonData
{
    public int BloonsToSpawn { get; set; }
    public float Time { get; set; }
    public bool Finished { get; set; }

    public BloonData(int bloonsToSpawn, float time)
    {
        BloonsToSpawn = bloonsToSpawn;
        Time = time;
        Finished = false;
    }
}

public class BloonSpawner : MonoBehaviour
{
    public List<RoundSO> Rounds;

    private int _currentRoundIndex;
    private Transform _spawnPoint;

    private void Awake()
    {
        _currentRoundIndex = 0;
        _spawnPoint = BloonPathManager.Instance.pathPoints[0];
        InitializeCurrentRound();
    }

    private void FixedUpdate()
    {
        SpawnWaves();
    }

    private void InitializeCurrentRound()
    {
        if (IsValidRoundIndex(_currentRoundIndex))
        {
            Rounds[_currentRoundIndex].ResetWaveIndex();
            Rounds[_currentRoundIndex].InitializeAllWaves();
        }
    }

    private bool IsValidRoundIndex(int index) => index >= 0 && index < Rounds.Count;

    private void SpawnWaves()
    {
        if (!IsValidRoundIndex(_currentRoundIndex)) return;

        var currentWave = Rounds[_currentRoundIndex].GetCurrentWave();
        
        foreach (var bloonData in currentWave.BloonDatas)
        {
            if (bloonData.BloonsToSpawn <= 0) bloonData.Finished = true;
            
            if (bloonData.Finished) continue;

            bloonData.Time -= Time.deltaTime;

            if (bloonData.Time <= 0)
            {
                InstantiateBloon(bloonData, currentWave.MicroWave[currentWave.BloonDatas.IndexOf(bloonData)]);
            }
        }

        if (currentWave.AllWavesFinished())
        {
            Rounds[_currentRoundIndex].MoveToNextWave();
        }
        
        if (Rounds[_currentRoundIndex].WavesEnded() && BloonPathManager.Instance.ReturnBloonCount() <= 0)
        {
            _currentRoundIndex++;
            InitializeCurrentRound();
        }
    }

    private void InstantiateBloon(BloonData bloonData, MicroWaveData microWaveData)
    {
        var newBloon = Instantiate(microWaveData.Type, _spawnPoint.position, Quaternion.identity);
        bloonData.BloonsToSpawn--;
        BloonPathManager.Instance.AddBloon(newBloon);
        bloonData.Time = microWaveData.SpawnDelay;
    }
}
