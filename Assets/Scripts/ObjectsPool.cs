using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    private List<GameObject> _pool;

    private int _count = 10;

    private void Start()
    {
        _pool = new List<GameObject>();

        for (int i = 0; i < _count; i++)
        {
            GameObject gameObject = Instantiate(_prefab);
            gameObject.SetActive(false);
            _pool.Add(gameObject);
        }
    }

    public GameObject GetCube()
    {
        foreach (var cube in _pool)
        {
            if (cube.activeInHierarchy == false)
            {
                return cube;
            }
        }

        GameObject newCube = Instantiate(_prefab);
        newCube.SetActive(false);

        _pool.Add(newCube);

        return newCube;
    }
}
