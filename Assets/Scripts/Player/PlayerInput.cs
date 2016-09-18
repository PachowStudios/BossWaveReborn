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
    public bool IsShootingSecondary => ShootSecondary.IsPressed;
    public bool SelectPreviousGun => SelectGun.Value < 0f;
    public bool SelectNextGun => SelectGun.Value > 0f;

    private PlayerOneAxisAction Move { get; }
    private PlayerAction Run { get; }
    private PlayerAction Jump { get; }

    private PlayerTwoAxisAction Aim { get; }
    private PlayerAction Shoot { get; }
    private PlayerAction ShootSecondary { get; }
    private PlayerOneAxisAction SelectGun { get; }

    public PlayerInput()
    {
      Move = CreateOneAxisPlayerAction(
        CreatePlayerAction($"{nameof(Move)}Left").WithDefault(Key.A),
        CreatePlayerAction($"{nameof(Move)}Right").WithDefault(Key.D));
      Run = CreatePlayerAction(nameof(Run)).WithDefault(Key.LeftShift);
      Jump = CreatePlayerAction(nameof(Jump)).WithDefault(Key.Space);

      Aim = CreateTwoAxisPlayerAction(
        CreatePlayerAction($"{nameof(Aim)}Left").WithDefault(Mouse.NegativeX),
        CreatePlayerAction($"{nameof(Aim)}Right").WithDefault(Mouse.PositiveX),
        CreatePlayerAction($"{nameof(Aim)}Down").WithDefault(Mouse.NegativeY),
        CreatePlayerAction($"{nameof(Aim)}Up").WithDefault(Mouse.PositiveY));
      Shoot = CreatePlayerAction(nameof(Shoot)).WithDefault(Mouse.LeftButton);
      ShootSecondary = CreatePlayerAction(nameof(ShootSecondary)).WithDefault(Mouse.RightButton);
      SelectGun = CreateOneAxisPlayerAction(
        CreatePlayerAction($"{nameof(SelectGun)}Previous").WithDefault(Mouse.NegativeScrollWheel),
        CreatePlayerAction($"{nameof(SelectGun)}Next").WithDefault(Mouse.PositiveScrollWheel));

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
