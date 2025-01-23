using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TurretUpgradeSO", order = 1)]
public class TurretUpgradeSO : ScriptableObject
{
    public TurretType turretType;
    public string name;
    public string description;
    public int cost;

    public GameObject shootBehaviourPrefab;
    public Sprite sprite;

    public float damage;
    public float range;
    public float fireRate;
}


