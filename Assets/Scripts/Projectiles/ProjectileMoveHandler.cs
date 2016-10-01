using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Projectiles
{
  public partial class ProjectileMoveHandler : ILateTickable
  {
    private Settings Config { get; }
    private ProjectileModel Model { get; }

    private Vector2 Velocity
    {
      get { return Model.Velocity; }
      set { Model.Velocity = value; }
    }

    public ProjectileMoveHandler(Settings config, ProjectileModel model)
    {
      Config = config;
      Model = model;
    }

    public void LateTick()
    {
      
    }
  }
}
