
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : GameCharacter
{
    public float shootingFrequency = 2f;

    private GameObject _player;
    private Gun _gun;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        slider = GetComponentInChildren<Slider>();
        _gun = GetComponentInChildren<Gun>();
    }

    private void Start()
    {
        StartCoroutine(AttackPlayer());
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    private IEnumerator AttackPlayer()
    {
        while (true)
        {      
            _gun.Shoot();
                
            yield return new WaitForSeconds(shootingFrequency);
        }
    }

    private void FollowPlayer()
    {
        transform.LookAt(_player.transform.position);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (other.name == "PlayerBullet")
            {
                Destroy(other.gameObject);

                ScoreController.Increment();

                //TakeDamage(other.attachedRigidbody.velocity.magnitude); - damage dependant on bullet speed
                TakeDamage(20);
            }
        }
    }

}
