using System;

namespace PachowStudios.BossWave.Player
{
  [Serializable]
  public class PlayerExternalForceSettings
  {
    public float Gravity = -60f;
    public float GroundDamping = 6f;
    public float AirDamping = 4f;
  }
}