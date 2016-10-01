using PachowStudios.Framework.Movement;
using UnityEngine;

namespace PachowStudios.BossWave.Projectiles
{
  public class ProjectileModel
  {
    public Vector2 Velocity { get; set; }

    public IRaycastSource RaycastSource => MovementController;

    private ProjectileComponents Components { get; }

    private Transform Transform => Components.Projectile;
    private MovementController2D MovementController => Components.MovementController;

    public ProjectileModel(ProjectileComponents components)
    {
      Components = components;
    }

    public void Move(Vector2 velocity)
      => Velocity = MovementController.Move(velocity);
  }
}
