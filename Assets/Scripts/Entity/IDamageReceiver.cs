namespace PachowStudios.BossWave.Entity
{
  public interface IDamageReceiver
  {
    void TakeDamage(IDamageSource source);
  }
}