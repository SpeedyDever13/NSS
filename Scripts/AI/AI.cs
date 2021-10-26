using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [SerializeField] private GameObject _closestFood = null;
    [SerializeField] private GameObject _closestLittleEnemy = null;
    private Transform _gfx;
    private NavMeshAgent _agent;
    private Seeker _seeker; 

    private void Awake() 
    {
        _seeker = FindObjectOfType<Seeker>().GetComponent<Seeker>();
        _agent = GetComponent<NavMeshAgent>();
        _gfx = GetComponentInChildren<Eater>().transform;
    }

    private void Update() 
    {
        GoForFood();
        _closestLittleEnemy = _seeker.FindClosestLittleEnemy(_gfx);
    }

    private void GoForFood()
    {
        if(DontHaveFood())
        {
            _closestFood = _seeker.FindClosestFood(transform.position);
        }else _agent.SetDestination(_closestFood.transform.position);
    }

    private bool DontHaveFood()
    {
        return _closestFood == null;
    }
}
