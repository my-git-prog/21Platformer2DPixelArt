using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CommandManager _commandManager;
    [SerializeField] private CharacterMover _mover;
    [SerializeField] private CharacterView _view;
    
    private void OnEnable()
    {
        _commandManager.Moving += Move;
        _commandManager.Jumping += Jump;
    }

    private void OnDisable()
    {
        _commandManager.Moving -= Move;
        _commandManager.Jumping -= Jump;
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
