using System.Collections.Generic;
using PachowStudios.BossWave.Guns;
using UnityEngine;

namespace PachowStudios.BossWave.Player
{
  public partial class PlayerGunSelector
  {
    private Settings Config { get; }
    private PlayerModel Model { get; }
    private GunFactory GunFactory { get; }

    private GunFacade CurrentGun
    {
      get { return Model.CurrentGun; }
      set { Model.CurrentGun = value; }
    }

    private Transform GunPoint => Config.GunPoint;
    private List<GunFacade> Guns => Model.Guns;
    private int CurrentGunIndex => Guns.IndexOf(CurrentGun);

    public PlayerGunSelector(Settings config, PlayerModel model, GunFactory gunFactory)
    {
      Config = config;
      Model = model;
      GunFactory = gunFactory;

      Config.StartingGuns.ForEach(AddGun);
    }

    private void AddGun(GunType type)
    {
      var gun = GunFactory.Create(type);

      gun.ParentTo(GunPoint);

      if (!Guns.IsFull())
      {
        Guns.Add(gun);
        return;
      }

      Guns[CurrentGunIndex] = gun;
      CurrentGun.Destroy();
      SelectGun(gun);
    }

    private void SelectGun(GunFacade gun)
    {
      CurrentGun = gun;
      gun.IsActive = true;
    }
  }
}
