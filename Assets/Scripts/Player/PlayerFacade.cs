using PachowStudios.BossWave.Entity;
using PachowStudios.Framework.Messaging;
using PachowStudios.Framework.Movement;
using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Player
{
  [AddComponentMenu("Boss Wave/Player/Player Facade")]
  public class PlayerFacade : MonoBehaviour, IGroundable, IDamageReceiver
  {
    public Vector2 Position => Model.Position;
    public Vector2 CenterPoint => Model.CenterPoint;
    public bool IsGrounded => Model.IsGrounded;

    private PlayerModel Model { get; set; }
    private IEventAggregator EventAggregator { get; set; }

    [Inject]
    public void Construct(PlayerModel model, IEventAggregator eventAggregator)
    {
      Model = model;
      EventAggregator = eventAggregator;
    }

    public void TakeDamage(IDamageSource source)
      => EventAggregator.PublishLocally(new EntityDamagedMessage(source));
  }
}
