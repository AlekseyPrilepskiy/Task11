using System;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    private bool _isTouched;

    public event Action<CubeBehavior> TouchWithPlatform;

    private void OnEnable()
    {
        _isTouched = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isTouched == false && collision.gameObject.TryGetComponent<Platform>(out _))
        {
            _isTouched = true;
            TouchWithPlatform?.Invoke(this);
        }
    }
}
