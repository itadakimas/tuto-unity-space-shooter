public class PlayerStore : Store<PlayerStore>, IObservable
{
  private float _score;
  private float _health;
  private float _maxHealth;

  public PlayerStore()
  {
    _score = 0;
    _maxHealth = 100;
    _health = _maxHealth;
  }

  public float GetHealthRate()
  {
    return _health / _maxHealth;
  }

  public void IncreaseScore(float points)
  {
    _score += points;
    Notify("score:updated");
  }

  public void DecreaseHealth(float damage)
  {
    _health -= damage;
    Notify("health:decreased");
    if (_health <= 0)
    {
      Notify("health:none");
    }
  }
}
