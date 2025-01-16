using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloon : MonoBehaviour
{
    public float health;

    [Tooltip("Set the speed of the bloon equal to the health multiplied to the speedMultiplier")]
    public float speedMultiplier;
    
    [HideInInspector]
    public int targetIndex = 0;
    [HideInInspector]
    public float speed;

    private void Awake() { speed = health * speedMultiplier; }
    public Vector3 GetPosition(){ return gameObject.transform.position; }
    public void SetPosition(Vector3 newPosition){ transform.position = newPosition; }

    //public List<TurretTarget> turretCalls = new List<TurretTarget>();
    public void TakeDamage(float value)
    {
        health -= value;
        speed = health * 2;

        if (health <= 0)
        {
            Destroy(this.gameObject); // return to bloon pool 
            //foreach(TurretTarget turret in turretCalls)
            //    turret.bloonsInArea.Remove(this);
        }
    }

}

