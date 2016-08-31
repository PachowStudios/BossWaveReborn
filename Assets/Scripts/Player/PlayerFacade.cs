using PachowStudios.Framework.Movement;
using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Player
{
  [AddComponentMenu("Boss Wave/Player/Player Facade")]
  public partial class PlayerFacade : MonoBehaviour, IGroundable
  {
    public Vector3 Position => Model.Position;
    public Vector3 CenterPoint => Model.CenterPoint;
    public bool IsGrounded => Model.IsGrounded;

    private PlayerModel Model { get; set; }

    [Inject]
    public void Construct(PlayerModel model)
    {
      Model = model;
    }
  }
}
