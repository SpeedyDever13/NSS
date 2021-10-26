using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    private Seeker _seeker; 
    private NavMeshAgent _agent;
    [SerializeField] private GameObject _closestFood = null;

    private void Awake() 
    {
        _seeker = FindObjectOfType<Seeker>().GetComponent<Seeker>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update() 
    {
        if(_closestFood == null)
        {
            _closestFood = _seeker.FindClosestFood(transform.position);
        }else _agent.SetDestination(_closestFood.transform.position);
    }
}
