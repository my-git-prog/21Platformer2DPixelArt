using UnityEngine;

public class Player : Character
{
    [SerializeField] private UserInput _userInput;
    [SerializeField] private Inventory _inventory;

    private void OnEnable()
    {
        _userInput.JumpButtonClicked += Jumper.Jump;
        _userInput.AttackButtonClicked += Attack<Enemy>;
        _inventory.MedicineTaken += HealHealth;
    }

    private void OnDisable()
    {
        _userInput.JumpButtonClicked -= Jumper.Jump;
        _userInput.AttackButtonClicked -= Attack<Enemy>;
        _inventory.MedicineTaken -= HealHealth;
    }

    private void Update()
    {
        Move();
    }

    protected override float GetHorizontalMovement()
    {
        return _userInput.Horizontal;
    }

    private void HealHealth(int medicine)
    {
        int health = Health + medicine;

        if (health > MaxHealth)
            Health = MaxHealth;
        else
            Health = health;
    }
}
