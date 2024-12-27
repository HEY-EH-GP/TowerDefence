using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WaveSO", order = 1)]
public class WaveSO : ScriptableObject
{
    public List<MicroWaveData> MicroWave;
    public List<BloonData> BloonDatas { get; private set; }

    public void InitializeBloonData()
    {
        BloonDatas = new List<BloonData>();
        foreach (var waveData in MicroWave)
        {
            BloonData newData = new BloonData(waveData.Quantity, waveData.SpawnDelay);
            BloonDatas.Add(newData);
        }
    }

    public bool AllWavesFinished() => BloonDatas.TrueForAll(bloon => bloon.Finished);
}

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

[System.Serializable]
public struct MicroWaveData
{
    public Bloon Type;
    [Range(0, 100)] public int Quantity;
    [Range(0, 3)] public float SpawnDelay;
}