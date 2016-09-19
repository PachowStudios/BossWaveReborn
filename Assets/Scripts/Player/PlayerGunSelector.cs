using System.Collections.Generic;
using System.Linq;
using PachowStudios.BossWave.Guns;
using PachowStudios.Framework.Primitives;
using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Player
{
  public partial class PlayerGunSelector : IInitializable, ITickable
  {
    private GunFacade CurrentGun
    {
      get { return Model.CurrentGun; }
      set { Model.CurrentGun = value; }
    }

    private Settings Config { get; }
    private PlayerModel Model { get; }
    private PlayerInput Input { get; }
    private GunFactory GunFactory { get; }
    private Cooldown SelectGunCooldon { get; }

    private List<GunFacade> Guns => Model.Guns;
    private int CurrentGunIndex => Guns.IndexOf(CurrentGun);

    public PlayerGunSelector(Settings config, PlayerModel model, PlayerInput input, GunFactory gunFactory)
    {
      Config = config;
      Model = model;
      Input = input;
      GunFactory = gunFactory;
      SelectGunCooldon = new Cooldown(Config.SelectGunCooldown);
    }

    public void Initialize()
    {
      Config.StartingGuns.ForEach(AddGun);
      SelectGun(Guns.First());
    }

    public void Tick()
    {
      SelectGunCooldon.Tick(Time.deltaTime);

      if (SelectGunCooldon.IsExpired)
        CheckSelectGunInput();
    }

    private void CheckSelectGunInput()
    {
      if (Input.SelectPreviousGun)
        SelectGun(CurrentGunIndex - 1);
      else if (Input.SelectNextGun)
        SelectGun(CurrentGunIndex + 1);
      else if (Input.SelectGunIndex >= 0)
        SelectGun(Input.SelectGunIndex);
    }

    private void AddGun(GunType type)
    {
      var gun = GunFactory.Create(type);

      gun.ParentTo(Model.GunPoint);
      gun.transform.localPosition = Vector3.zero;

      if (Guns.Count == Config.Capacity)
      {
        ReplaceCurrentGun(gun);
        return;
      }

      Guns.Add(gun);
    }

    private void ReplaceCurrentGun(GunFacade gun)
    {
      Guns[CurrentGunIndex] = gun;
      CurrentGun.Destroy();
      SelectGun(gun);
    }

    private void SelectGun(int index)
      => SelectGun(Guns.ElementAtWrap(index));

    private void SelectGun(GunFacade gun)
    {
      if (gun == CurrentGun)
        return;

      if (CurrentGun != null)
        CurrentGun.IsActive = false;

      CurrentGun = gun;
      CurrentGun.IsActive = true;
      SelectGunCooldon.Reset();
    }
  }
}
