using UnityEngine;
using System;

public class Eater : MonoBehaviour
{

    public delegate void EnemyEat(float _enemySize);
    public event EnemyEat OnEnemyEaten;

    public delegate void FoodEat(int satiety);
    public event FoodEat OnFoodEaten;

    public void EatFood(int satiety)
    {
        if(satiety >= 0)
        {
            OnFoodEaten?.Invoke(satiety);
        } else throw new Exception("Incorrect satiety");
    }

    public void EatEnemy(float enemySize)
    {
        if(enemySize > 0)
        {
            OnEnemyEaten?.Invoke(enemySize);
        }else throw new Exception("Incorrect size");
    }
}
