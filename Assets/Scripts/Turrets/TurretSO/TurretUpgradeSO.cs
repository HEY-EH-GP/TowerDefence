using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TurretUpgradeSO", order = 1)]

public class TurretUpgradeSO : ScriptableObject
{
    public string name;
    public string description;
    public int cost;

    public EntityProjectile projectile; 
}
