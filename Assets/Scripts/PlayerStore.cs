public class PlayerStore : Store<PlayerStore>, IObservable
{
  private int _score;
  private int _health;
  private int _maxHealth;

  public PlayerStore()
  {
    _score = 0;
    _maxHealth = 100;
    _health = _maxHealth;
  }

  public void IncreaseScore(int points)
  {
    _score += points;
    Notify("score:updated");
  }

  public void DecreaseHealth(int damage)
  {
    _health -= damage;
    if (_health > 0)
    {
      Notify("health:decreased");
    }
    else
    {
      Notify("health:none");
    }
  }
}
