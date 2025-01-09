using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TurretSO", order = 1)]
public class TurretSO : ScriptableObject
{
    public string name;
    public string description;
    public Sprite turretSprite; 
    public Sprite InfoTurretsprite;

    public EntityProjectile projectile;

    public int cost;
    public int popCount;
    public KeyCode hotkey; // TODO use action maps

    public TurretUpgradeSO[] upgradeList1 = new TurretUpgradeSO[4]; 
    public TurretUpgradeSO[] upgradeList2 = new TurretUpgradeSO[4]; 
}
