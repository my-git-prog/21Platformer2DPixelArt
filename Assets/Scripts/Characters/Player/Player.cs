using UnityEngine;

public class Player : Character
{
    [SerializeField] private UserInput _userInput;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private MagicVampire _magicVampire;

    protected override void OnEnable()
    {
        base.OnEnable();
        _userInput.JumpButtonClicked += Jumper.Jump;
        _userInput.AttackButtonClicked += Attacker.Attack<Enemy>;
        _userInput.Attack2ButtonClicked += _magicVampire.StartMagic;
        _inventory.MedicineTaken += Health.TakeHealing;
    }

    protected override void OnDisable()
    {
        base .OnDisable();
        _userInput.JumpButtonClicked -= Jumper.Jump;
        _userInput.AttackButtonClicked -= Attacker.Attack<Enemy>;
        _userInput.Attack2ButtonClicked -= _magicVampire.StartMagic;
        _inventory.MedicineTaken -= Health.TakeHealing;
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
