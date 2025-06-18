using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private CubeBehavior _cubePrefab;

    [SerializeField] private int _poolSize = 10;

    [SerializeField] private float _minLifeTime = 2f;
    [SerializeField] private float _maxLifeTime = 5f;

    private List<CubeBehavior> _cubePool;

    private void Start()
    {
        _cubePool = new List<CubeBehavior>();

        for (int i = 0; i < _poolSize; i++)
        {
            CubeBehavior cube = Instantiate(_cubePrefab);

            cube.gameObject.SetActive(false);
            cube.TouchedWithPlatform += ReturnCube;

            _cubePool.Add(cube);
        }
    }

    private void OnDisable()
    {
        foreach (CubeBehavior cube in _cubePool)
        {
            cube.TouchedWithPlatform -= ReturnCube;
        }
    }

    public CubeBehavior GetCube()
    {
        foreach (CubeBehavior cube in _cubePool)
        {
            if (cube.gameObject.activeInHierarchy == false)
            {
                cube.gameObject.SetActive(true);
                return cube;
            }
        }

        CubeBehavior newCube = Instantiate(_cubePrefab);

        newCube.gameObject.SetActive(true);
        newCube.TouchedWithPlatform += ReturnCube;

        _cubePool.Add(newCube);
        return newCube;
    }

    private void ReturnCube(CubeBehavior cube)
    {
        StartCoroutine(ReturnRoutine(cube));
    }

    private IEnumerator ReturnRoutine(CubeBehavior cube)
    {
        float time = Random.Range(_minLifeTime, _maxLifeTime);

        yield return new WaitForSeconds(time);

        cube.gameObject.SetActive(false);
        cube.ResetCharacteristic();
    }
}
