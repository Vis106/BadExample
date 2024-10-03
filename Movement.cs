using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _place;

    private Transform[] _places;
    private int _placeIndex = 0;

    private void Awake()
    {
        DefinePlaces();
    }

    private void Update()
    {
        Move();
    }

    private void DefinePlaces()
    {
        _places = new Transform[_place.childCount];

        for (int i = 0; i < _place.childCount; i++)
        {
            _places = _place.GetComponentsInChildren<Transform>();
        }
    }

    private void Move()
    {
        if (_places[_placeIndex] == null)
            return;

        if (transform.position == _places[_placeIndex].position)
        {
            _placeIndex = ++_placeIndex % _places.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _places[_placeIndex].position, _speed * Time.deltaTime);
    }
}