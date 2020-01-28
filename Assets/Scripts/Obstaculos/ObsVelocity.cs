using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsVelocity : MonoBehaviour
{
    public float _objVelocity;
    public Rigidbody _rb;

    void Start()
    {
        _rb.AddForce(-transform.forward * _objVelocity * 100);
        _rb.useGravity = false;
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
        
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
