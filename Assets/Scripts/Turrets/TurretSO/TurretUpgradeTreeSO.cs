using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TurretUpgradeTreeSO", order = 1)]
public class TurretUpgradeTreeSO : ScriptableObject
{
    public TurretUpgradeSO baseTurret;
    public List<TurretUpgradeSO> upgradePathA = new List<TurretUpgradeSO>();
    public List<TurretUpgradeSO> upgradePathB = new List<TurretUpgradeSO>();

}
