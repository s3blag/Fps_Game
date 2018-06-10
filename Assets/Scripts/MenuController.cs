using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    private Slider _enemiesCountSlider;

    private void Awake()
    {
        _enemiesCountSlider = GetComponentInChildren<Slider>();
    }

    public void NewGame()
    {
        GamePlayController.EnemiesCount = (int)_enemiesCountSlider.value;
        SceneManager.LoadScene("GameplayScene");
    }


    public void QuitGame() =>
        Application.Quit();

}
