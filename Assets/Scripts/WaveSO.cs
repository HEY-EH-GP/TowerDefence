using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WaveSO", order = 1)]
public class WaveSO : ScriptableObject
{
    public List<WaveData> waveDatas = new List<WaveData>();
}

[System.Serializable]
public struct WaveData
{
    public Bloon type;
    [Range(0,100)]public int quantity;
    [Range(0, 3)]public float spawnDelay;

    [HideInInspector] public int index;
    [HideInInspector] public int time;
    [HideInInspector] public bool started;
    [HideInInspector] public bool  finished;
}
