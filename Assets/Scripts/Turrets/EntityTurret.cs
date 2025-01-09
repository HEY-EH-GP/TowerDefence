using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class EntityTurret : MonoBehaviour
{    
    public float range = 5f;
    public float fireRate = 1f;
    public EntityProjectile projectilePrefab;
    public Transform firePoint;

    private float fireCooldown = 0f;

    private int UpgradeListIndex1;
    private int UpgradeListIndex2;

    protected delegate void ShootMethod();

    protected ShootMethod shootMethod;

    protected virtual void Awake()
    {
        shootMethod = Shoot;
    }

    protected virtual void Update()
    {
        Cooldown();
    }

    protected void Cooldown()
    {
        fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0f)
        {
            shootMethod.Invoke();
            fireCooldown = 1f / fireRate;
        }
    }

    protected virtual void Shoot()
    {
        EntityProjectile projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}
