using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _obstacles;
    [SerializeField] private float _timeBetweenSpawn = 5;

    private float _time;
    

    private void Update()
    {
        if (Time.time > _time)
        {
            Spawn();
            _time = Time.time + _timeBetweenSpawn;
        }
    }

    private void Spawn()
    {
        Instantiate(_obstacles[Random.Range(0, _obstacles.Count)], new Vector3(0,0,0), new Quaternion(0, 0, 0, 0));
    }
}