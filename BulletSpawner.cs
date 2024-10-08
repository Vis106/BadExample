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
        Vector3 direction;
        var timeInterval = new WaitForSeconds(_shootingTime);

        while (enabled)
        {
            direction = (_target.position - transform.position).normalized;
            Bullet bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            bullet.Init(direction);

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