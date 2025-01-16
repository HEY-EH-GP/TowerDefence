using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradePath
{
    Path1,
    Path2
}

public class UpgradeManager : MonoBehaviour
{
    public Turret turret;
    // int level
    // UpgradePath path
    public TurretUpgradeSO[] path1Upgrade;
    public TurretUpgradeSO[] path2Upgrade;

    public void UpgradeTurret(UpgradePath path, int level)
    {
        TurretUpgradeSO[] selectedPath = path == UpgradePath.Path1 ? path1Upgrade : path2Upgrade;

        if(level >= 0 && level < selectedPath.Length)
        {
            turret.ApplyUpgrade(selectedPath[level]);
        }
    }
}
