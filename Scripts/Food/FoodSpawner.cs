using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _freeSpawnPoints = new List<Transform>();
    [SerializeField] private List<Food> _foodTypes = new List<Food>();
    [SerializeField] private int _foodCount = 25;

    public void Spawn()
    {
        if(_freeSpawnPoints.Count != 0)
        {
            GameObject _food = CalculateFoodObject();
            Vector3 _spawnPoint = ChooseSpawnPoint();
            Instantiate(_food, _spawnPoint, Quaternion.identity);
        }
    }

    public Vector3 ChooseSpawnPoint()
    {
        int _pointIndex = Random.Range(0, _freeSpawnPoints.Count - 1);
        Vector3 _spawnPoint = _freeSpawnPoints[_pointIndex].position;
        _freeSpawnPoints.Remove(_freeSpawnPoints[_pointIndex]);
        return _spawnPoint;
    }

    public GameObject CalculateFoodObject()
    {
        int _foodIndex = Random.Range(1, 100);
            if(_foodIndex < _foodTypes[0].Probability + 1)
            {
                return _foodTypes[0].Prefab;
            }else if(_foodIndex < 100 - _foodTypes[2].Probability + 1)
            {
                return _foodTypes[1].Prefab;
            }else if(_foodIndex < 101)
            {
                return _foodTypes[2].Prefab;
            }
            else return _foodTypes[2].Prefab;
    }

    private void Awake() {
        for (int i = 0; i < _foodCount; i++)
        {
            Spawn();
        }
    }
}
