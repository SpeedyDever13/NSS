using UnityEngine;

public class FoodBehaviour : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private int _satiety;
    public Food Food;

    private void Awake() 
    {
        _satiety = Food.Satiety;
    }

    private void Update() 
    {
        transform.Rotate(new Vector3(0, _rotationSpeed, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.GetComponent<Eater>() != null)
        {
            other.gameObject.GetComponent<Eater>().EatFood(_satiety);
            Destroy(this.gameObject);
        }
    }
}
