using System;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public event Action<Player> PlayerFinded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            PlayerFinded?.Invoke(player);
        }
    }
}
