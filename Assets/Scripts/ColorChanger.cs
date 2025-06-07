using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private CubeBehavior _cube;

    private void Awake()
    {
        _cube = GetComponent<CubeBehavior>();
    }

    private void OnEnable()
    {
        _cube.TouchWithPlatform += Change;
    }

    private void OnDisable()
    {
        _cube.TouchWithPlatform -= Change;
    }

    private void Change(CubeBehavior cube)
    {
        cube.Renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
