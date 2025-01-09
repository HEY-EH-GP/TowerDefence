using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTargetless : EntityTurret
{
    protected override void Awake()
    {
        shootMethod = Shoot;
    }


    protected override void Update()
    {
        base.Update();
    }

    protected override void Shoot()
    {
        EntityProjectile projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        //projectile.SetTarget(target);
    }
}
