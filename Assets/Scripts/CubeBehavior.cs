using System;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    private Renderer _renderer;

    private Color _baseColor;

    private bool _isTouched;

    public event Action<CubeBehavior> TouchWithPlatform;

    public Renderer Renderer => _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();

        _baseColor = _renderer.material.color;
    }

    private void OnEnable()
    {
        _isTouched = false;
    }

    private void OnDisable()
    {
        _renderer.material.color = _baseColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isTouched == false && collision.gameObject.CompareTag("Platform"))
        {
            _isTouched = true;
            TouchWithPlatform?.Invoke(this);
        }
    }
}
