using PachowStudios.Framework.Movement;
using UnityEngine;

namespace PachowStudios.BossWave.Player
{
  public class PlayerModel
  {
    public Vector3 Position
    {
      get { return MovementController.Position; }
      set { MovementController.Position = value; }
    }

    public Vector3 CenterPoint => MovementController.CenterPoint;
    public bool IsGrounded => MovementController.IsGrounded;

    public SpriteRenderer[] Renderers { get; }

    private MovementController2D MovementController { get; }

    public PlayerModel(MovementController2D movementController, SpriteRenderer[] renderers)
    {
      MovementController = movementController;
      Renderers = renderers;
    }

    public void Move(Vector3 velocity)
      => MovementController.Move(velocity);
  }
}