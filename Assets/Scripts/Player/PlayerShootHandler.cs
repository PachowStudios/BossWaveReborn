using PachowStudios.BossWave.Guns;
using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Player
{
  public partial class PlayerShootHandler : ITickable
  {
    private Settings Config { get; }
    private PlayerModel Model { get; }
    private PlayerInput Input { get; }

    private GunFacade Gun => Model.CurrentGun;
    private Vector2 GunPosition => Model.GunPoint.position;
    private Vector2 WorldAimTarget => Camera.main.ScreenToWorldPoint(Input.AimTarget);

    public PlayerShootHandler(Settings config, PlayerModel model, PlayerInput input)
    {
      Config = config;
      Model = model;
      Input = input;
    }

    public void Tick()
    {
      Gun.IsShooting = Input.IsShooting;

      UpdateAimDirection();
    }

    private void UpdateAimDirection()
      => Gun.AimDirection = WorldAimTarget - GunPosition;
  }
}
