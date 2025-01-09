using UnityEngine;

public class Player : Character
{
    [SerializeField] private UserInput _userInput;

    private void OnEnable()
    {
        _userInput.JumpButtonClicked += _mover.Jump;
        _userInput.AttackButtonClicked += Attack<Enemy>;
    }

    private void OnDisable()
    {
        _userInput.JumpButtonClicked -= _mover.Jump;
        _userInput.AttackButtonClicked -= Attack<Enemy>;
    }

    private void Update()
    {
        Move();
    }

    protected override float GetHorizontalMovement()
    {
        return _userInput.Horizontal;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Medicine medicine))
        {
            int health = _health + medicine.Parameter;

            medicine.Take();

            if (health > _maxHealth)
                _health = _maxHealth;
            else
                _health = health;
        }
    }
}
