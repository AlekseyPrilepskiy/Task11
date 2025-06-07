using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    private CubeBehavior _cube;

    private float minTime = 2f;
    private float maxTime = 5f;

    private void Awake()
    {
        _cube = GetComponent<CubeBehavior>();
    }

    private void OnEnable()
    {
        _cube.TouchWithPlatform += Remove;
    }

    private void OnDisable()
    {
        _cube.TouchWithPlatform -= Remove;
    }

    private void Remove(CubeBehavior cube)
    {
        float delay = Random.Range(minTime, maxTime);
        Invoke(nameof(Deactivate), delay);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
