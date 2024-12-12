using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloon : MonoBehaviour
{
    public float health;
    public float damage; 
    public float speed;

    private int targetIndex = 0;
    public int TargetIndex
    {
        get { return targetIndex; }
        set { targetIndex = value; }
    }

    public Vector3 GetPosition(){ return transform.position; }
    public void SetPosition(Vector3 newPosition){ transform.position = newPosition; }


}

