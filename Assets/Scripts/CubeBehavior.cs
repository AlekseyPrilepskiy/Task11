using System;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private bool _isTouched;

    public event Action<CubeBehavior> TouchedWithPlatform;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isTouched == false && collision.gameObject.TryGetComponent<Platform>(out _))
        {
            _isTouched = true;
            TouchedWithPlatform?.Invoke(this);
        }
    }

    public void ResetCharacteristic()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        _isTouched = false;
    }
}
