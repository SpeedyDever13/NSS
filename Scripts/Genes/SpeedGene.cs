public class SpeedGene : Gen
{
    private PlayerMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        Value = GetComponent<PlayerMovement>().Speed;
    }
    
    public override void Increase()
    {
        if(Level < Maxlevel)
        {
            Value *= Multyplier;
            Level++;
            _movement.Speed = Value;
        }
    }
}
