using InControl;
using UnityEngine;

namespace PachowStudios.BossWave.Player
{
  public class PlayerInput : PlayerActionSet
  {
    private static KeyBindingSource CancelSetBindingKey { get; } = new KeyBindingSource(Key.Escape);

    public int HorizontalMovement => (int)Move.Value;
    public bool IsWalking => Move.IsPressed;
    public bool IsRunning => IsWalking && Run.IsPressed;
    public bool Jumped => Jump.WasPressed;

    public Vector2 AimTarget => Input.mousePosition;
    public bool IsShooting => Shoot.IsPressed;

    private PlayerOneAxisAction Move { get; }
    private PlayerAction Run { get; }
    private PlayerAction Jump { get; }

    private PlayerTwoAxisAction Aim { get; }
    private PlayerAction Shoot { get; }
    private PlayerAction ShootSecondary { get; }

    public PlayerInput()
    {
      Move = CreateOneAxisPlayerAction(
        CreatePlayerAction("MoveLeft").WithDefault(Key.A),
        CreatePlayerAction("MoveRight").WithDefault(Key.D));
      Run = CreatePlayerAction(nameof(Run)).WithDefault(Key.LeftShift);
      Jump = CreatePlayerAction(nameof(Jump)).WithDefault(Key.Space);

      Aim = CreateTwoAxisPlayerAction(
        CreatePlayerAction("AimLeft").WithDefault(Mouse.NegativeX),
        CreatePlayerAction("AimRight").WithDefault(Mouse.PositiveX),
        CreatePlayerAction("AimDown").WithDefault(Mouse.NegativeY),
        CreatePlayerAction("AimUp").WithDefault(Mouse.PositiveY));
      Shoot = CreatePlayerAction(nameof(Shoot)).WithDefault(Mouse.LeftButton);
      ShootSecondary = CreatePlayerAction(nameof(ShootSecondary)).WithDefault(Mouse.RightButton);

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
