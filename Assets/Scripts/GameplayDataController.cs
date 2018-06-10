using UnityEngine.SceneManagement;

public static class GamePlayController
{
    private static int _enemiesCount;
    private static int _currentEnemiesCount;
     
    public static int EnemiesCount
    {
        get
        {
            return _enemiesCount;
        }

        set
        {
            _enemiesCount = value;
            _currentEnemiesCount = value;
        }
    }

    public static int CurrentEnemiesCount
    {
        get
        {
            return _currentEnemiesCount;
        }
       
        set
        {
            _currentEnemiesCount = value;
            if (_currentEnemiesCount <= 0)
            {
                ScoreController.EnsureUpdated();
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }

}
