using UnityEngine;

public class CharacterFlipper : MonoBehaviour
{
    [SerializeField] private CharacterDirection _characterDirection = CharacterDirection.Right;

    public CharacterDirection Direction => _characterDirection;

    public void Flip(float horizontal)
    {
        if (horizontal == 0f)
            return;

        if (horizontal > 0f && _characterDirection != CharacterDirection.Right)
        {
            _characterDirection = CharacterDirection.Right;
            Rotate();
        }
        else if (horizontal < 0f && _characterDirection != CharacterDirection.Left)
        {
            _characterDirection = CharacterDirection.Left;
            Rotate();
        }
    }

    private void Rotate()
    {
        transform.Rotate(0f, 180f, 0f);
    }
}
