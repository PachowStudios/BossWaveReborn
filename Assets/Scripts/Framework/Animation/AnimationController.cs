using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using PachowStudios.Framework.Assertions;
using UnityEngine;
using Zenject;

namespace PachowStudios.Framework.Animation
{
  public class AnimationController
  {
    private readonly Animator animator;
    private readonly List<AnimationCondition> conditions = new List<AnimationCondition>();

    public AnimationController([NotNull] Animator animator)
    {
      this.animator = animator;
    }

    [NotNull]
    public AnimationController Add([NotNull] string name, [NotNull] Func<bool> condition)
    {
      this.conditions.Should().HaveNoneWhere(c => c.Name.EqualsIgnoreCase(name), "because condition names must be unique");
      this.conditions.Add(new AnimationCondition(name, condition));

      return this;
    }

    public void Tick()
    {
      foreach (var condition in this.conditions)
        this.animator.SetBool(condition.Name, condition.IsConditionSatisfied);
    }
  }
}