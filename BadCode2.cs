using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _shootingTime;

    private Coroutine _shoot;

    private void Start()
    {
        TurnOn();
    }

    private IEnumerator Shooting()
    {
        bool isWorking = enabled;
        Vector3 direction;
        var timeInterval = new WaitForSeconds(_shootingTime);

        while (isWorking)
        {
            direction = (_target.position - transform.position).normalized;
            Bullet bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            bullet.transform.up = direction;
            bullet.GetComponent<Rigidbody>().velocity = direction * _speed;

            yield return timeInterval;
        }
    }

    private void TurnOn()
    {
        if (_shoot != null)
        {
            StopCoroutine(_shoot);
        }

        _shoot = StartCoroutine(Shooting());
    }
}