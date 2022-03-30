using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIState : MonoBehaviour
{
    public void SetStateMachine(AIStateMachine statemachine) { _statemachine = statemachine; }

    public virtual void OnEnterState()
    {

    }
    public virtual void OnExitState()
    {

    }
    public virtual void OnAnimatorUpdated()
    {

    }
    public virtual void OnAnimatorIKUpdated()
    {

    }
    public virtual void OnTriggerEvent(AITriggerEventType eventType, Collider other)
    {

    }
    public virtual void OnDestinationReached(bool isReached) { }
    public abstract AIStateType GetStateType();
    public abstract AIStateType OnUpdate();

    protected AIStateMachine _statemachine;
}
