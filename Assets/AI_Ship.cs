using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Ship : MonoBehaviour
{
    public NavMeshAgent nma;

    private AIStates currentState;

    private Transform currentTarget;

    private void OnEnable()
    {
        StartCoroutine(EnableAI());
    }

    IEnumerator EnableAI()
    {
        yield return new WaitForSeconds(0.1f);

        currentState = AIStates.None;
        AI_Manager.Instance.AddEnemy(this);
    }

    private void OnDisable()
    {
        AI_Manager.Instance.RemoveEnemy(this);
    }

    private void Update()
    {
        switch (currentState)
        {
            case AIStates.None:
                break;
            case AIStates.SearchFlag:
                break;
            case AIStates.AttackFlag:
                AttackFlag();
                break;
            case AIStates.AttackPlayer:
                break;
            case AIStates.Dead:
                break;
            default:
                break;
        }
    }

    public void SetNewAIState(AIStates newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case AIStates.None:
                //return to pool
                break;
            case AIStates.SearchFlag:
                break;
            case AIStates.AttackFlag:
                SetNewTarget(AI_Manager.Instance.GetFoundFlag());
                break;
            case AIStates.AttackPlayer:
                break;
            case AIStates.Dead:
                break;
            default:
                break;
        }
    }

    public AIStates GetCurrentState()
    {
        return currentState;
    }

    public void SetNewTarget(Transform target)
    {
        if (target == null) SetNewAIState(AIStates.SearchFlag);
        this.currentTarget = target;
    }

    private void AttackFlag()
    {
        Move(currentTarget);
    }

    private void Move(Transform target)
    {
        nma.SetDestination(target.position);

    }
}
