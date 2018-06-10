using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Player : GameCharacter
{

    private Gun _bulletGenerator;

    private void Awake()
    {
        ScoreController.Init();
        _bulletGenerator = GetComponentInChildren<Gun>();
    }

    void FixedUpdate()
    {
        GetButtonInput();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            TakeDamage(20); 
        }
    }

    // That might not be a perfect place for it
    private void GetButtonInput()
    {
#if UNITY_STANDALONE || UNITY_WEBPLAYER
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
            _bulletGenerator.Shoot();
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        if (CrossPlatformInputManager.GetButtonDown("Fire"))
            _bulletGenerator.Shoot();
#endif
    }

    protected override void Die() =>
        // it can show accuracy better than the current highest, but it won't save it
        SceneManager.LoadScene("GameOverScene");

}
