using UnityEngine;

public class SizeGene : Gen
{
    private Transform _gfx;

    private void Awake() 
    {
        _gfx = FindObjectOfType<Eater>().transform;
        Value = _gfx.localScale.x;
    }

    public override void Increase()
    {
        if(Level < Maxlevel)
        {
            Value *= Multyplier;
            Level++;
            _gfx.localScale = Vector3.one * Value;
        }
    }
}
