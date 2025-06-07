using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectsPool _pool;

    private float _spawnInterval = 1f;
    private float _spawnHeight = 10f;

    private Vector3 _spawnArea = new Vector3(5f, 0f, 5f);

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0f, _spawnInterval);
    }

    private void Spawn()
    {
        GameObject cube = _pool.GetCube();

        Vector3 pos = new Vector3(
            UnityEngine.Random.Range(-_spawnArea.x, _spawnArea.x),
            _spawnHeight,
            UnityEngine.Random.Range(-_spawnArea.z, _spawnArea.z)
        );

        cube.transform.position = pos;
        cube.transform.rotation = Quaternion.identity;

        cube.SetActive(true);
    }
}
