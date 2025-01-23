using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
using UnityEngine.AI;
using System;

public class AI_Manager : MonoBehaviour
{
    [Header("Navigation")]
    [Tooltip("Nav Mesh Surface")]
    public NavMeshSurface nms;

    [Tooltip("Nav Mesh Data")]
    public NavMeshData nmd;

    public GameObject bridge;

    public Transform spawnPoint;

    LayerMask layerMask;


    private static AI_Manager instance; 
    public static AI_Manager Instance { get { return instance; } }


    private List<AI_Ship> enemies = new List<AI_Ship>();

    public List<Transform> foundFlags = new List<Transform>();

    //private PlayerClass playerRef;

    // ~ Alt + 126 
    private void OnValidate()
    {
       
    }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private GameObject bridge_instance_ref;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {

        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            bridge_instance_ref = Instantiate(bridge, spawnPoint.position, Quaternion.identity, this.transform);

            bridge_instance_ref.layer = 7; // Walkable layer

            nms.BuildNavMesh();
        }
    }

    public void AddEnemy(AI_Ship enemy)
    {
        enemies.Add(enemy);

        AIStates state = enemy.GetCurrentState();

        if(state == AIStates.None)
        {
            enemy.SetNewAIState(AIStates.AttackFlag);
        }
    }

    public void RemoveEnemy(AI_Ship enemy)
    {
        enemies.Remove(enemy);

        enemy.SetNewAIState(AIStates.None);
    }

    public Transform GetFoundFlag()
    {
        if(foundFlags.Count > 0)
            return foundFlags[0].transform;

        return null;
    }

}
