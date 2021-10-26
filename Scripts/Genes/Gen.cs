using UnityEngine;

public abstract class Gen : MonoBehaviour
{
    [SerializeField] protected float Multyplier;
    [SerializeField] protected float Value;
    [SerializeField] protected int Level = 1;
    [SerializeField] protected int Maxlevel;

    public abstract void Increase();
}
