using PachowStudios.Framework.Movement;
using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Player
{
  [AddComponentMenu("Boss Wave/Player/Player Facade")]
  public partial class PlayerFacade : MonoBehaviour, IGroundable
  {
    private PlayerModel Model { get; set; }

    public Vector3 Position => Model.Position;
    public Vector3 CenterPoint => Model.CenterPoint;
    public bool IsGrounded => Model.IsGrounded;

    [Inject]
    public void Construct(PlayerModel model)
      => Model = model;
  }
}
