using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private CubeBehavior _cube;
    private Renderer _renderer;

    private void Awake()
    {
        _cube = GetComponent<CubeBehavior>();
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        _cube.TouchedWithPlatform += Change;
        _renderer.material.color = Color.white;
    }

    private void OnDisable()
    {
        _cube.TouchedWithPlatform -= Change;
    }

    private void Change(CubeBehavior cube)
    {
        _renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
