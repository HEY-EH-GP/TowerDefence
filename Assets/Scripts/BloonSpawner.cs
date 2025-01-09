using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloonSpawner : MonoBehaviour
{
    [Header("Rounds Configuration")]
    public List<RoundSO> Rounds;

    private int _currentRoundIndex = 0;
    private Transform _spawnPoint;

    private void Awake()
    {
        _spawnPoint = BloonPathManager.Instance.pathPoints[0];
        InitializeCurrentRound();
    }

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private void InitializeCurrentRound()
    {
        if (IsValidRoundIndex(_currentRoundIndex))
        {
            var currentRound = Rounds[_currentRoundIndex];
            currentRound.ResetWaveIndex();
            currentRound.InitializeAllWaves();
        }
    }

    private bool IsValidRoundIndex(int index) => index >= 0 && index < Rounds.Count;

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            if (!IsValidRoundIndex(_currentRoundIndex)) yield break;

            var currentRound = Rounds[_currentRoundIndex];
            var currentWave = currentRound.GetCurrentWave();

            if (currentWave != null)
            {
                foreach (var bloonData in currentWave.BloonDatas)
                {
                    if (bloonData.Finished) continue;

                    if (bloonData.Time <= 0)
                    {
                        InstantiateBloon(bloonData, currentWave.MicroWave[currentWave.BloonDatas.IndexOf(bloonData)]);
                    }
                    else
                    {
                        bloonData.Time -= Time.deltaTime;
                    }
                }

                if (currentWave.AllWavesFinished())
                {
                    currentRound.MoveToNextWave();
                }
            }

            if (currentRound.WavesEnded() && BloonPathManager.Instance.bloons.Count <= 0)
            {
                _currentRoundIndex++;
                InitializeCurrentRound();
            }

            yield return null;
        }
    }

    private void InstantiateBloon(BloonData bloonData, MicroWaveData microWaveData)
    {
        var newBloon = Instantiate(microWaveData.Type, _spawnPoint.position, Quaternion.identity);
        bloonData.BloonsToSpawn--;
        BloonPathManager.Instance.bloons.Add(newBloon);
        bloonData.Time = microWaveData.SpawnDelay;

        if (bloonData.BloonsToSpawn <= 0) bloonData.Finished = true;
    }
}
