using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float range = 5f;
    public float fireRate = 1f;
    public ProjectileController projectilePrefab;
    public Transform firePoint;

    private float fireCooldown = 0f;
    private Bloon target;

    private void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (target == null || !IsTargetInRange())
            target = FindClosestEnemy();

        if (target != null && fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = 1f / fireRate;
        }
        
    }

    Bloon FindClosestEnemy()
    {
        float shortestDistance = Mathf.Infinity;
        Bloon closestEnemy = null;

        foreach (var bloon in BloonPathManager.Instance.bloons)
        {
            float distance = Vector3.Distance(transform.position, bloon.transform.position);
            
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestEnemy = bloon;
            }
        }

        return closestEnemy;
    }
    
    bool IsTargetInRange()
    {
        return Vector3.Distance(transform.position, target.transform.position) <= range;
    }

    void Shoot()
    {
        ProjectileController projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectile.SetTarget(target);
    }
    
}
