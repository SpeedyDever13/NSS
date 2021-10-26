using UnityEngine;

public class PerceptionGene : Gen
{
    [SerializeField] private Light _light;

    private void Awake() 
    {
        Value = _light.spotAngle;
    }

    public override void Increase()
    {
        if(Level < Maxlevel)
        {
            Value *= Multyplier;
            Level++;
            _light.spotAngle = Value;
        }
    }
}