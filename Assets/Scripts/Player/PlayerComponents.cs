using System;
using PachowStudios.Framework;
using PachowStudios.Framework.Movement;
using UnityEngine;

namespace PachowStudios.BossWave.Player
{
  [Serializable, InstallerSettings]
  public class PlayerComponents
  {
    public Transform Body;
    public Transform GunPoint;
    public MovementController2D MovementController;
    public Animator Animator;
  }
}
