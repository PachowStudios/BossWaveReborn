using System;
using PachowStudios.Framework;

namespace PachowStudios.BossWave.Entity
{
  [Serializable, InstallerSettings]
  public class ExternalForces
  {
    public float Gravity = -38f;
    public float GroundDamping = 6f;
    public float AirDamping = 4f;
  }
}