using PachowStudios.BossWave.Guns;
using Zenject;

namespace PachowStudios.BossWave.Player
{
  public class PlayerDirectionHandler : ILateTickable
  {
    private PlayerModel Model { get; }
    private PlayerInput Input { get; }

    private GunFacade Gun => Model.CurrentGun;
    private bool IsLookingRight => Model.IsLookingRight;
    private bool IsMovingRight => Input.HorizontalMovement > 0;
    private bool IsAimingRight => Gun.AimDirection.x > 0f;
    private bool IsLookingTowardsMovementDirection => IsMovingRight == IsLookingRight;
    private bool IsLookingTowardsAimDirection => IsAimingRight == IsLookingRight;

    public PlayerDirectionHandler(PlayerModel model, PlayerInput input)
    {
      Model = model;
      Input = input;
    }

    public void LateTick()
    {
      if (Gun.IsShooting)
      {
        if (!IsLookingTowardsAimDirection)
          Model.Flip();
      }
      else if (Input.IsWalking && !IsLookingTowardsMovementDirection)
        Model.Flip();
    }
  }
}
