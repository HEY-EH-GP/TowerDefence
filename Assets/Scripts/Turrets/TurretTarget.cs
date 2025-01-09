using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTarget : EntityTurret
{
    public TargetType targetType;

    public SphereCollider sphereCollider;

    public Bloon bloonTarget;

    [HideInInspector]
    public List<Bloon> bloonsInArea;


    protected override void Awake()
    {
        shootMethod = Shoot;
        sphereCollider = GetComponent<SphereCollider>();
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

    private void OnTriggerEnter(Collider other)
    {
       Bloon bloon;
       if (other.gameObject.TryGetComponent<Bloon>(out bloon))
       {
            bloonsInArea.Add(bloon);
       }
    }

    private void OnTriggerExit(Collider other)
    {
        Bloon bloon;
        if (other.gameObject.TryGetComponent<Bloon>(out bloon))
        {
            bloonsInArea.Remove(bloon);
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

    //bool IsTargetInRange()
    //{
    //    return Vector3.Distance(transform.position, target.transform.position) <= range;
    //}
}
