public class PlayerStore : Store<PlayerStore>, IObservable
{
  private bool _destroyed;
  private int _score;
  private float _health;
  private float _maxHealth;

  public PlayerStore()
  {
    Init();
  }

  public float GetHealthRate()
  {
    return _health / _maxHealth;
  }

  public int GetScore()
  {
    return _score;
  }

  public void IncreaseScore(int points)
  {
    _score += points;
    Notify("score:updated");
  }

  public void DecreaseHealth(float damage)
  {
    if (_destroyed)
    {
      return;
    }
    _health -= damage;
    Notify("health:decreased");
    if (_health <= 0)
    {
      _destroyed = true;
      Notify("health:none");
    }
  }

  public void Reset()
  {
    Init();
    Notify("player:reset");
  }

  private void Init()
  {
    _destroyed = false;
    _score = 0;
    _maxHealth = 100;
    _health = _maxHealth;
  }
}
