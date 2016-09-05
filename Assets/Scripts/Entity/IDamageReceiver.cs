namespace PachowStudios.BossWave.Entity
{
  public interface IDamageReceiver
  {
    DamageSourceType AcceptedDamageSourceType { get; }

    void TakeDamage(IDamageSource source);
  }
}