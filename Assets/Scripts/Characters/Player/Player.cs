using UnityEngine;

public class Player : Character
{
    [SerializeField] private UserInput _userInput;
    [SerializeField] private Inventory _inventory;

    protected override void OnEnable()
    {
        base.OnEnable();
        _userInput.JumpButtonClicked += Jumper.Jump;
        _userInput.AttackButtonClicked += Attacker.Attack<Enemy>;
        _inventory.MedicineTaken += Health.TakeHeal;
    }

    protected override void OnDisable()
    {
        base .OnDisable();
        _userInput.JumpButtonClicked -= Jumper.Jump;
        _userInput.AttackButtonClicked -= Attacker.Attack<Enemy>;
        _inventory.MedicineTaken -= Health.TakeHeal;
    }

    private void Update()
    {
        Move();
    }

    protected override float GetHorizontalMovement()
    {
        return _userInput.Horizontal;
    }
}
