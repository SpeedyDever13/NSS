using UnityEngine;

public class Experience : MonoBehaviour
{
    private Eater _eater;
    private float _experience = 0f;
    private float _experienceToNewLevel = 10f;
    private float _sizeToExperience = 3f;

    public delegate void LevelChanged();
    public event LevelChanged OnLevelUp;


    private void OnEnable() 
    {
        _eater.OnEnemyEaten += IncreaseExperience;
    }

    private void OnDisable() 
    {
        _eater.OnEnemyEaten -= IncreaseExperience;
    }

    private void Awake() 
    {
        _eater = FindObjectOfType<Eater>();
    }

    public void IncreaseExperience(float _enemySize)
    {
        _experience += _enemySize * _sizeToExperience;
        if(_experience > _experienceToNewLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        OnLevelUp?.Invoke();
        _experience = 0f;
    }
}
