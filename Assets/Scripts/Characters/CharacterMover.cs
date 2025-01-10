using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    public void Move(float horizontal)
    {
        transform.Translate(Vector2.right * horizontal * _speed * Time.deltaTime, Space.World);
    }
}