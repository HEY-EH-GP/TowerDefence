using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RoundSO", order = 1)]
public class RoundSO : ScriptableObject
{
    public List<WaveSO> Waves;
    private int _currentWaveIndex;

    public void ResetWaveIndex() => _currentWaveIndex = 0;

    private bool IsValidWaveIndex(int index) => index >= 0 && index < Waves.Count;
    public WaveSO GetCurrentWave() => IsValidWaveIndex(_currentWaveIndex) ? Waves[_currentWaveIndex] : null;

    public void InitializeAllWaves()
    {
        foreach (var wave in Waves)
        {
            wave.InitializeBloonData();
        }
    }
    
    public void MoveToNextWave()
    {
        if (GetCurrentWave()?.AllWavesFinished() == true && _currentWaveIndex < Waves.Count - 1)
            _currentWaveIndex++;
    }

    public bool WavesEnded() => Waves.TrueForAll(wave => wave.AllWavesFinished());

}