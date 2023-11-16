using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _obstacles;

    private float _time;
    private float _timeBetweenSpawn = 5;

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
        float y = 0;
        while (y < 6 && y > -6)
        {
            y = Random.Range(-10, 10);
        }
        Instantiate(_obstacles[Random.Range(0, _obstacles.Count)], new Vector3(Random.Range(-10f, 7f), y, 0), new Quaternion(0, 0, 0, 0));
    }
}