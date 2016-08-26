using InControl;

namespace PachowStudios.BossWave.Player
{
  public class PlayerInput : PlayerActionSet
  {
    private static KeyBindingSource CancelSetBindingKey { get; } = new KeyBindingSource(Key.Escape);

    public PlayerOneAxisAction Move { get; }
    public PlayerTwoAxisAction Aim { get; }

    public PlayerAction Shoot { get; }
    public PlayerAction ShootSecondary { get; }
    public PlayerAction Run { get; }
    public PlayerAction Jump { get; }

    private PlayerAction MoveLeft { get; }
    private PlayerAction MoveRight { get; }

    private PlayerAction AimLeft { get; }
    private PlayerAction AimRight { get; }
    private PlayerAction AimDown { get; }
    private PlayerAction AimUp { get; }

    public PlayerInput()
    {
      Move = CreateOneAxisPlayerAction(
        MoveLeft = CreatePlayerAction(nameof(MoveLeft)),
        MoveRight = CreatePlayerAction(nameof(MoveRight)));

      Aim = CreateTwoAxisPlayerAction(
        AimLeft = CreatePlayerAction(nameof(AimLeft)),
        AimRight = CreatePlayerAction(nameof(AimRight)),
        AimDown = CreatePlayerAction(nameof(AimDown)),
        AimUp = CreatePlayerAction(nameof(AimUp)));

      Shoot = CreatePlayerAction(nameof(Shoot));
      ShootSecondary = CreatePlayerAction(nameof(ShootSecondary));
      Run = CreatePlayerAction(nameof(Run));
      Jump = CreatePlayerAction(nameof(Jump));

      AssignDefaultBindings();
      ConfigureBindingListener();
    }

    private void AssignDefaultBindings()
    {
      MoveLeft.AddDefaultBinding(Key.A);
      MoveRight.AddDefaultBinding(Key.D);

      AimLeft.AddDefaultBinding(Mouse.NegativeX);
      AimRight.AddDefaultBinding(Mouse.PositiveX);
      AimDown.AddDefaultBinding(Mouse.NegativeY);
      AimUp.AddDefaultBinding(Mouse.PositiveY);

      Shoot.AddDefaultBinding(Mouse.LeftButton);
      ShootSecondary.AddDefaultBinding(Mouse.RightButton);
      Run.AddDefaultBinding(Key.LeftShift);
      Jump.AddDefaultBinding(Key.Space);
    }

    private void ConfigureBindingListener()
    {
      ListenOptions.IncludeUnknownControllers = false;
      ListenOptions.MaxAllowedBindings = 3;
      ListenOptions.OnBindingFound = OnBindingFound;
    }

    private static bool OnBindingFound(PlayerAction action, BindingSource binding)
    {
      if (binding != CancelSetBindingKey)
        return true;

      action.StopListeningForBinding();

      return false;
    }
  }
}