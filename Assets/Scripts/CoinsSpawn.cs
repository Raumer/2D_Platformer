using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawn : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Coin _coin;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
        }

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        foreach (var point in _points)
        {
            Instantiate(_coin, point.position, Quaternion.identity);

            yield return new WaitForSeconds(1);
        }
    }
}
