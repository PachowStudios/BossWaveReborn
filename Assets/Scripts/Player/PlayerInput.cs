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

    public PlayerInput()
    {
      Move = CreateOneAxisPlayerAction(
        CreatePlayerAction("MoveLeft").WithDefault(Key.A),
        CreatePlayerAction("MoveRight").WithDefault(Key.D));

      Aim = CreateTwoAxisPlayerAction(
        CreatePlayerAction("AimLeft").WithDefault(Mouse.NegativeX),
        CreatePlayerAction("AimRight").WithDefault(Mouse.PositiveX),
        CreatePlayerAction("AimDown").WithDefault(Mouse.NegativeY),
        CreatePlayerAction("AimUp").WithDefault(Mouse.PositiveY));

      Shoot = CreatePlayerAction(nameof(Shoot)).WithDefault(Mouse.LeftButton);
      ShootSecondary = CreatePlayerAction(nameof(ShootSecondary)).WithDefault(Mouse.RightButton);
      Run = CreatePlayerAction(nameof(Run)).WithDefault(Key.LeftShift);
      Jump = CreatePlayerAction(nameof(Jump)).WithDefault(Key.Space);

      ConfigureBindingListener();
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
