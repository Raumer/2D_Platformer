using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyPatrol>(out EnemyPatrol enemyPatrol))
        {
            Destroy(gameObject);
        }
    }
}
