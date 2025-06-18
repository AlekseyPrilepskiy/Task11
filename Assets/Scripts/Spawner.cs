using System;
using System.Collections;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubePool _pool;
    [SerializeField] private float _spawnTime = 1f;
    [SerializeField] private float _spawnHeight = 10f;

    private Vector3 _spawnArea = new Vector3(5f, 0f, 5f);

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnTime);

            CubeBehavior cube = _pool.GetCube();

            cube.transform.position = new Vector3(
            UnityEngine.Random.Range(-_spawnArea.x, _spawnArea.x),
            _spawnHeight,
            UnityEngine.Random.Range(-_spawnArea.z, _spawnArea.z));
        }
    }
}