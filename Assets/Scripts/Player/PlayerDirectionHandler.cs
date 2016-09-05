using Zenject;

namespace PachowStudios.BossWave.Player
{
  public class PlayerDirectionHandler : ILateTickable
  {
    private PlayerModel Model { get; }
    private PlayerInput Input { get; }

    private bool IsMovingRight => Input.HorizontalMovement > 0;
    private bool IsLookingTowardsMovementDirection => !Input.IsWalking || IsMovingRight == Model.IsLookingRight;

    public PlayerDirectionHandler(PlayerModel model, PlayerInput input)
    {
      Model = model;
      Input = input;
    }

    public void LateTick()
    {
      if (!IsLookingTowardsMovementDirection)
        Model.Flip();
    }
  }
}
