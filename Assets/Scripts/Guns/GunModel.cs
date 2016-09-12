using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Guns
{
  public class GunModel : IInitializable
  {
    private bool isActive;

    public Quaternion Rotation
    {
      get { return Transform.localRotation; }
      set { Transform.localRotation = value; }
    }

    public Vector3 Scale
    {
      get { return Transform.localScale; }
      set { Transform.localScale = value; }
    }

    public Color Color
    {
      get { return Renderer.color; }
      set { Renderer.color = value; }
    }

    public Color MuzzleFlashColor
    {
      get { return MuzzleFlashRenderer.color; }
      set { MuzzleFlashRenderer.color = value; }
    }

    public bool IsActive
    {
      get { return this.isActive; }
      set
      {
        this.isActive = value;

        if (!this.isActive)
          IsShooting = false;
      }
    }

    public bool IsShooting { get; set; }
    public Vector2 AimDirection { get; set; }

    private GunComponents Components { get; }
    private Transform Transform => Components.Gun;
    //private Transform FirePoint => Components.FirePoint;
    private SpriteRenderer Renderer => Components.Renderer;
    private SpriteRenderer MuzzleFlashRenderer => Components.MuzzleFlashRenderer;

    public GunModel(GunComponents components)
    {
      Components = components;
    }

    public void Initialize()
      => IsActive = false;
  }
}
