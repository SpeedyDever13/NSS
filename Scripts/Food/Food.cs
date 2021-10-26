using UnityEngine;

[CreateAssetMenu(fileName = "New Food", menuName = "Food")]
public class Food : ScriptableObject
{
    public int Satiety;
    public int Probability;
    public GameObject Prefab;
}
