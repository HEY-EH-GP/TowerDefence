using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //Public
    public TurretUpgradeSO currentUpgrade;
    public MeshRenderer meshRenderer;

    //Private
    private float fireCooldown = 0f;

    private IShootBehaviour shootBehaviour;

    protected virtual void Awake()
    {
        ApplyUpgrade(currentUpgrade);
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
            shootBehaviour?.Shoot();
            //fireCooldown = 1f / fireRate;
        }
    }

    public void ApplyUpgrade(TurretUpgradeSO newTurretUpgrade)
    {
        currentUpgrade = newTurretUpgrade;

        shootBehaviour = Instantiate(currentUpgrade.shootBehaviourPrefab).GetComponent<IShootBehaviour>();

        UpdateTurretAppearence(currentUpgrade.sprite);
    }

    private void UpdateTurretAppearence(Sprite sprite)
    {
        //TODO Create Custom Material and assign to meshRenderer
    }
}
