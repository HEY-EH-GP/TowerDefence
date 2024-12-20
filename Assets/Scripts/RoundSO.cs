using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RoundSO", order = 1)]
public class RoundSO : ScriptableObject
{
    public List<WaveSO> waves;
    public int currentWave;
}
