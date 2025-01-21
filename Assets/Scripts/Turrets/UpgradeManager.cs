using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public List<TurretUpgradeTreeSO> turretUpgradeTrees = new List<TurretUpgradeTreeSO>();
    private List<TurretData> turretDatas;

    //Singleton
    private static UpgradeManager instance;
    public static UpgradeManager Instance { get { return instance; } }




    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }

        instance = this;
        DontDestroyOnLoad(this);
    }

    // Call upon spawning turret
    public void AddTurretData(Turret turret)
    {
        foreach (TurretUpgradeTreeSO turretUpgrade in turretUpgradeTrees)
        {
            if (turret.baseUpgrade.turretType == turretUpgrade.baseTurret.turretType)
            {
                turretDatas.Add(new TurretData(turret, turretUpgrade));
            }
        }
    }

    public void UpgradeTurret(Turret turret, UpgradePath path)
    {
        TurretData targetTurretData = null;
        foreach (TurretData turretData in turretDatas)
        {
            if (turret == turretData.turret)
            {
                targetTurretData = turretData;
                break;
            }
        }

        if (targetTurretData != null)
        {
            if (targetTurretData.IncrementPathIndex(path))
            {
                turret.ApplyUpgrade(targetTurretData.GetTurretUpgradeFromPath(path));
            }
        }
        else
        {
            Debug.LogError("Turret not found inside TurretData");
        }
    }


    #region MyCode
    // Singleton del manager

    //public Turret turret;
    //public UpgradePath selectedPath;
    //public TurretUpgradeTreeSO[] upgradeTrees;
    //public int level;


    //private TurretUpgradeTreeSO selectedTree;
    //private TurretUpgradeSO selectedBranch;

    //public void FindTurretUpgrade(Turret targetTurret, UpgradePath selectedPath)   // Struct o SO     turret<-->Paths relations
    //{
    //    foreach(TurretUpgradeTreeSO upgradeTree in upgradeTrees)
    //    {
    //        if (upgradeTree.type == targetTurret.turretType)
    //        {
    //            this.turret = targetTurret;
    //            this.selectedTree = upgradeTree;

    //            switch (selectedPath)
    //            {
    //                case(UpgradePath.Path1):
    //                    this.level = turret.upgradeIndexA;
    //                    break;
    //                case (UpgradePath.Path2):
    //                    this.level = turret.upgradeIndexB;
    //                    break;
    //                default:
    //                    break;
    //            }

    //            UpgradeTurret(selectedPath);
    //        }
    //    }

    //}

    //public void UpgradeTurret(UpgradePath path)
    //{
    //    List<TurretUpgradeSO> selectedBranch = path == UpgradePath.Path1 ? selectedTree.upgradePathA : selectedTree.upgradePathB;

    //    if (this.level >= 0 && this.level < selectedBranch.Count)
    //    {
    //        turret.ApplyUpgrade(selectedBranch[this.level]);
    //    }
    //}
    #endregion
}

public class TurretData
{
    public TurretType type;
    public Turret turret;

    public TurretUpgradeTreeSO upgradeTree;

    public int indexPathA;
    public int indexPathB;

    public TurretData(Turret turret, TurretUpgradeTreeSO upgradeTree)
    {
        this.turret = turret;
        this.upgradeTree = upgradeTree;

        indexPathA = indexPathB = 0;
    }

    public bool IncrementPathIndex(UpgradePath pathType)
    {
        int index = pathType == UpgradePath.PathA ? indexPathA : indexPathB;

        if (index < (pathType == UpgradePath.PathA ? upgradeTree.upgradePathA.Count : upgradeTree.upgradePathB.Count))
        {
            if (pathType == UpgradePath.PathA)
            {
                indexPathA++;
                return true;
            }
            else
            {
                indexPathB++;
                return true;
            }
        }

        return false;
    }

    public TurretUpgradeSO GetTurretUpgradeFromPath(UpgradePath path)
    {
        return path == UpgradePath.PathA ? upgradeTree.upgradePathA[indexPathA] : upgradeTree.upgradePathB[indexPathB];
    }
}
