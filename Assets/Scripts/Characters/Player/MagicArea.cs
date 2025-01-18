using System.Collections.Generic;
using UnityEngine;

public class MagicArea : MonoBehaviour
{
    private List<Enemy> _enemies = new();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            _enemies.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            _enemies.Remove(enemy);
        }
    }

    public bool TryGetEnemy(out Enemy enemy)
    {
        enemy = null;

        if (_enemies.Count == 0)
            return false;

        float sqrMinimumDistance = float.MaxValue;

        foreach (Enemy enemyInArea in _enemies)
        {
            float sqDistance = (transform.position - enemyInArea.transform.position).sqrMagnitude;
            
            if (sqDistance < sqrMinimumDistance)
            {
                sqrMinimumDistance = sqDistance;
                enemy = enemyInArea;
            }
        }

        return true;
    }
}
