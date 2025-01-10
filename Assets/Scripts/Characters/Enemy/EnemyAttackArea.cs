using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    private bool _isPlayerReachable = false;
    private int _playersCount = 0;

    public bool IsPlayerReachable => _isPlayerReachable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (_playersCount++ == 0)
            {
                _isPlayerReachable = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (--_playersCount == 0)
            {
                _isPlayerReachable = false;
            }
        }
    }
}
