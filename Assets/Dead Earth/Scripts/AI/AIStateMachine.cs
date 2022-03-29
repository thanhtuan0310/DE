using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AIStateType { None, Idle, Alerted, Patrol, Attack, Feeding, Pursuit, Dead}
public enum AITargetType { None, Waypoint, Visual_Player, Visual_Light, Visual_Food, Audio}

public struct AITarget
{
    private AITargetType _type;
    private Collider _collider;
    private Vector3 _position;
    private float _distance;
    private float _time;

    public AITargetType type { get { return _type; } }
    public Collider collider { get { return _collider; } }
    public Vector3 position { get { return _position; } }
    public float distance { get { return _distance; } set { _distance = value; } }
    public float time { get { return _time; } }

    public void Set(AITargetType t, Collider c, Vector3 p, float d)
    {
        _type = t;
        _collider = c;
        _position = p;
        _distance = d;
        _time = Time.time;
    }

    public void Clear()
    {
        _type = AITargetType.None;
        _collider = null;
        _position =Vector3.zero;
        _time = 0.0f;
        _distance = Mathf.Infinity;
    }
}
public abstract class AIStateMachine : MonoBehaviour
{
    public AITarget VisualThreat = new AITarget();
    public AITarget AudioThreat = new AITarget();

    protected Dictionary<AIStateType, AIState> _states = new Dictionary<AIStateType, AIState>();
    protected AITarget _target = new AITarget();

    [SerializeField] protected SphereCollider _targetTrigger = null;
    [SerializeField] protected SphereCollider _sensorTrigger = null;

    protected Animator _animator = null;
    protected NavMeshAgent _navAgent = null;
    protected Collider _collider = null;
    protected Transform _transform = null;

    public Animator animator { get { return _animator; } }
    public NavMeshAgent navAgent { get { return _navAgent; } }
    protected virtual void Start()
    {
        AIState[] states = GetComponents<AIState>();
        foreach(AIState state in states)
        {
            if(state != null && _states.ContainsKey(state.GetStateType()))
            {
                _states[state.GetStateType()] = state;
            }
        }
    }
}
