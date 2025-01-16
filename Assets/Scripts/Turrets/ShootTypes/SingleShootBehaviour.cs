using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShootBehaviour : MonoBehaviour, IShootBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;

    public void Shoot()
    {
        if(firePoint != null && projectilePrefab != null)
        {
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            Debug.LogError("FirePoint or ProjectilePrefab of the " + gameObject.name + " prefab are null!");
        }
    }
}
