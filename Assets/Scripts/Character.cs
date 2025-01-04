using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Input _input;
    [SerializeField] private CharacterMover _mover;
    [SerializeField] private CharacterView _view;
    
    private void OnEnable()
    {
        _input.Moving += Move;
        _input.Jumping += Jump;
    }

    private void OnDisable()
    {
        _input.Moving -= Move;
        _input.Jumping -= Jump;
    }

    private void Move(float horizontal)
    {
        _mover.Move(horizontal);
        _view.Move(horizontal);
    }

    private void Jump()
    {
        _mover.Jump();
    }
}
