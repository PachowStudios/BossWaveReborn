using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Guns
{
  public class GunRotationHandler : ITickable
  {
    private GunModel Model { get; }

    public GunRotationHandler(GunModel model)
    {
      Model = model;
    }

    public void Tick()
      => RotateGun();

    private void RotateGun()
    {
      var rotation = Model.AimDirection.DirectionToRotation2D();

      Model.Rotation = rotation;
      Model.Scale = Model.Scale.Set(y: rotation.IsFlippedOnZAxis() ? -1f : 1f);
    }
  }
}
