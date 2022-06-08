using UnityEngine;

[RequireComponent(typeof(Creature))]
public class MoveByPath : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;
    
    private int _currentPoint;
    private Creature _creature;
    private Transform[] _points;

    private void Awake()
    {
        _creature = GetComponent<Creature>();
        SetPoints();
    }

    private void Update()
    {
        DoPatrol(out Vector3 direction);
        _creature.SetDirection(direction.normalized);
    }

    private void SetPoints()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void DoPatrol(out Vector3 direction)
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        direction = transform.position - target.position;

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _path.childCount)
            {
                _currentPoint = 0;
            }
        }
    }
}