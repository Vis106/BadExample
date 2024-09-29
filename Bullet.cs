using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody bullet;

    private void Awake()
    {
        bullet = GetComponent<Rigidbody>();    
    }

    public void Init(Vector3 direction)
    {
        transform.up = direction;
        bullet.velocity = direction * _speed;
    }
}
