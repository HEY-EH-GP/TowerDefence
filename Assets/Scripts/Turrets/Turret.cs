using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Turret : MonoBehaviour
{
    //Public
    public MeshRenderer meshRenderer;

    public TurretUpgradeSO baseUpgrade;
    public TurretUpgradeSO currentUpgrade;

    //public int upgradeIndexA;
    //public int upgradeIndexB;

    //public TurretType turretType;

    //Private
    private float fireCooldown = 0f;

    private IShootBehaviour shootBehaviour;

    public virtual void Awake()
    {
        ApplyUpgrade(baseUpgrade);
    }
    // protected è leggibile solo da classi derivate di EntityTurret
    // virtual permette ai figli di overridare la funzione del padre
    protected virtual void Update()
    {
        Cooldown();
    }

    protected void Cooldown()
    {
        fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0f)
        {
            shootBehaviour?.Shoot(); // Try se esiste
            //fireCooldown = 1f / fireRate;
        }
    }

    public void ApplyUpgrade(TurretUpgradeSO newTurretUpgrade)
    {
        currentUpgrade = newTurretUpgrade;

        shootBehaviour = Instantiate(currentUpgrade.shootBehaviourPrefab).GetComponent<IShootBehaviour>();

        UpdateTurretAppearance(currentUpgrade.sprite);

    }

    private void UpdateTurretAppearance(Sprite sprite)
    {
        //TODO Create custom material and assign to meshRenderer
    }

    #region MyCode

    //[Range(1,10)] public int damage;
    //[Range(5,50)] public float range;

    //public enum TargetType
    //{
    //    Closest,
    //    Furthest,
    //    Strongest,
    //    Weakest
    //}

    //public TargetType targetType;
    //public Bloon target;
    //public GameObject cannon;

    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
    //    target = null;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    FindTarget();
    //    PointTowardsTarget();
    //}

    //public void FindTarget()
    //{
    //    // carica tutti i bloon in scena
    //    List<Bloon> bloons = BloonPathManager.Instance.GetBloonList();
    //    float dist;
    //    int HP;
    //    switch (targetType)
    //    {
    //        case TargetType.Closest:
    //            dist = float.MaxValue;
    //            foreach(Bloon bloon in bloons)
    //            {
    //                if ((Vector3.Distance(this.transform.position, bloon.GetPosition()) < dist) 
    //                    && (Vector3.Distance(this.transform.position, bloon.GetPosition()) < range))
    //                {
    //                    dist = Vector3.Distance(this.transform.position, bloon.GetPosition());
    //                    target = bloon;
    //                }
    //            }
    //            break;

    //        case TargetType.Furthest:
    //            dist = 0;
    //            foreach (Bloon bloon in bloons)
    //            {
    //                if ((Vector3.Distance(this.transform.position, bloon.GetPosition()) > dist)
    //                    && (Vector3.Distance(this.transform.position, bloon.GetPosition()) < range))
    //                {
    //                    dist = Vector3.Distance(this.transform.position, bloon.GetPosition());
    //                    target = bloon;
    //                }
    //            }

    //            break;

    //        case TargetType.Strongest:
    //            HP = 0;
    //            foreach (Bloon bloon in bloons)
    //            {
    //                if ((bloon.GetHP() > HP)
    //                    && (Vector3.Distance(this.transform.position, bloon.GetPosition()) < range))
    //                {
    //                    HP = bloon.GetHP();
    //                    target = bloon;
    //                }
    //            }

    //            break;

    //        case TargetType.Weakest:
    //            HP = int.MaxValue;
    //            foreach (Bloon bloon in bloons)
    //            {
    //                if ((bloon.GetHP() < HP)
    //                    && (Vector3.Distance(this.transform.position, bloon.GetPosition()) < range))
    //                {
    //                    HP = bloon.GetHP();
    //                    target = bloon;
    //                }
    //            }

    //            break;
    //    }
    //}

    //public void PointTowardsTarget()
    //{
    //    if (target != null)
    //    {
    //        cannon.transform.LookAt(target.transform, new Vector3(1,0,0));
    //        cannon.transform.rotation *= Quaternion.Euler(90, 0, 0);
    //    }
    //}
    #endregion

}
