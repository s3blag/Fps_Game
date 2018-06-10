using UnityEngine;
using UnityEngine.UI;

public abstract class GameCharacter : MonoBehaviour
{
    public Slider slider;

    // unfortunatelly it makes Awake useless 
    [SerializeField]
    private float _startingHealth = 100;
    [SerializeField]
    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _startingHealth;
    }

    protected abstract void OnTriggerEnter(Collider other);

    protected virtual void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        slider.value = _currentHealth/_startingHealth * 100;
        if (_currentHealth <= 0)
            Die();
    }

    protected virtual void Die()
    {
        GamePlayController.CurrentEnemiesCount--;
        Destroy(gameObject);
    }
}
