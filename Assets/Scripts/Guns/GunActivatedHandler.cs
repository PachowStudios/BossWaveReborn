using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Guns
{
  public class GunActivatedHandler : ITickable
  {
    private GunModel Model { get; }

    public GunActivatedHandler(GunModel model)
    {
      Model = model;
    }

    public void Tick()
    {
      if (Model.IsActive && Model.IsShooting)
        Show();
      else
        Hide();
    }

    private void Show()
      => Model.Color = Color.white;

    private void Hide()
    {
      Model.Color = Color.clear;
      Model.MuzzleFlashColor = Color.clear;
    }
  }
}