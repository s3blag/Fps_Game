using UnityEngine;

public static class ScoreController
{
    private static int _hits;
    private static int _total;

    public static int CurrentScore
    {
        get
        {
            return _total != 0 ? (int)((float)_hits / _total * 100) : 0;
        }
    }

    // PlayerPrefs is not the best option here, I would use something more secure (e.g. .persistenDataPath), 
    //but due to a lack of time I decided to use it 
    public static int HighestScore
    {
        get
        {
            return PlayerPrefs.GetInt("highestScore");
        }
    }

    public static void Increment()
    {
        _hits++;
        _total++;        
    }

    public static void EnsureUpdated()
    {
        if (CurrentScore > HighestScore)
        {
            Save();
        }
        
    }

    public static void Init()
    {
        _hits = 0;
        _total = 0;
    }

    public static void Decrement() =>
        _total++;

    private static void Save()
    {
        PlayerPrefs.SetInt("highestScore", CurrentScore);
    }
}
