using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] private Vector2[] _pointsToSpawnAt;

    private void Awake()
    {
        foreach (var point in _pointsToSpawnAt)
        {
            Instantiate(_prefabToSpawn, point, Quaternion.identity, transform);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        float radius = 0.2f;
        foreach (var point in _pointsToSpawnAt)
            Gizmos.DrawWireSphere(point, radius);
    }
}
