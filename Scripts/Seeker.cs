using System.Collections.Generic;
using UnityEngine;

public class Seeker : MonoBehaviour
{
    [SerializeField] private List<FoodBehaviour> _food;

    private void Start() 
    {
        GetAllFoodInList();
    }

    public GameObject FindClosestFood(Vector3 SlimePosition)
    {
        GameObject _closestFood = null;
        float DistanceToClosestFood = Mathf.Infinity;
        foreach(FoodBehaviour food in _food)
        {
            if(food != null)
            {
                var Distance = Vector3.Distance(SlimePosition, food.transform.position);
                if(Distance < DistanceToClosestFood)
                {
                    DistanceToClosestFood = Distance;
                    _closestFood = food.gameObject;
                }
            }
        }
        return _closestFood;
    }

    private void GetAllFoodInList()
    {
        var Food = FindObjectsOfType<FoodBehaviour>();
        foreach (FoodBehaviour food in Food)
        {
            _food.Add(food);
        }
    }
}
