using System.Collections.Generic;
using UnityEngine;

public class Seeker : MonoBehaviour
{
    [SerializeField] private List<FoodBehaviour> _food;
    [SerializeField] private List<Eater> _enemies;

    private void Start() 
    {
        FillFoodList();
        FillEnemyList();
    }

    private void FillFoodList()
    {
        var AllFood = FindObjectsOfType<FoodBehaviour>();
        foreach (FoodBehaviour food in AllFood)
        {
            _food.Add(food);
        }
    }

    private void FillEnemyList()
    {
        var AllEnemies = FindObjectsOfType<Eater>();
        foreach (Eater enemy in AllEnemies)
        {
            _enemies.Add(enemy);
        }
    }

    public GameObject FindClosestLittleEnemy(Transform AI)
    {   
        GameObject ClosestLittleEnemy = null;
        float DistanceToClosestLittleEnemy = Mathf.Infinity;
        foreach (Eater Enemy in _enemies)
        {
            float DistanceToCurrentEnemy = Vector3.Distance(AI.position, Enemy.gameObject.transform.position);
            if(IsBigger(AI.localScale, Enemy.gameObject.transform.localScale) && IsCloser(DistanceToClosestLittleEnemy, DistanceToCurrentEnemy))
            {
                DistanceToClosestLittleEnemy = DistanceToCurrentEnemy;
                ClosestLittleEnemy = Enemy.gameObject;
            }
        }
        return ClosestLittleEnemy;
    }

    public GameObject FindClosestFood(Vector3 AIPosition)
    {
        GameObject ClosestFood = null;
        float DistanceToClosestFood = Mathf.Infinity;
        foreach(FoodBehaviour food in _food)
        {
            if(food != null)
            {
                var DistanceToCurrentFood = Vector3.Distance(AIPosition, food.gameObject.transform.position);
                if(IsCloser(DistanceToClosestFood, DistanceToCurrentFood))
                {
                    DistanceToClosestFood = DistanceToCurrentFood;
                    ClosestFood = food.gameObject;
                }
            }
        }
        return ClosestFood;
    }

    private bool IsBigger(Vector3 AI, Vector3 Enemy)
    {
        return AI.x > Enemy.x;
    }

    private bool IsCloser(float ClosestDistance, float CurrentDistance)
    {
        return CurrentDistance < ClosestDistance;
    }
}
