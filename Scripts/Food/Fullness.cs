using UnityEngine;

public class Fullness : MonoBehaviour
{
    private Eater _eater;
    [SerializeField] private int _fullness;

    private void OnEnable() 
    {
        _eater.OnFoodEaten += IncreaseFullness;
    }

    private void OnDisable() 
    {
        _eater.OnFoodEaten -= IncreaseFullness;
    }

    private void Awake() 
    {
        _eater = GetComponentInChildren<Eater>();
    }

    private void IncreaseFullness(int satiety)
    {
        _fullness += satiety;
    }
}
