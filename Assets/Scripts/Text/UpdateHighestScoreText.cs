using UnityEngine;
using UnityEngine.UI;

public class UpdateHighestScoreText : MonoBehaviour
{
    private Text _highestScoreText;

	private void Awake()
    {
        _highestScoreText = GetComponent<Text>();
    }

    private void Start()
    {
        _highestScoreText.text = ScoreController.HighestScore.ToString() + "%";
    }
}
