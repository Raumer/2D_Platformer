using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform _enemyesPath;
    [SerializeField] private float _speed;

    private Transform[] _patrolPoints;
    private int _currentPoint = 0;

    private void Start()
    {
        _patrolPoints = new Transform[_enemyesPath.childCount];

        for (int i = 0; i < _enemyesPath.childCount; i++)
        {
            _patrolPoints[i] = _enemyesPath.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _patrolPoints[_currentPoint];

        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if(transform.position == target.position)
        {
            _currentPoint++;

            if(_currentPoint >= _patrolPoints.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
