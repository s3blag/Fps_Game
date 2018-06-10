using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletForce;
    public float bulletLifetime;

    public void Shoot()
    {
        var instantiatedBullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;

        instantiatedBullet.transform.Rotate(Vector3.left * 90);

        var rb = instantiatedBullet.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * bulletForce);

        if (transform.parent.CompareTag("MainCamera"))
        {
            this.DestroyWithAction(instantiatedBullet, bulletLifetime, () => ScoreController.Decrement());
            instantiatedBullet.name = "PlayerBullet";
        }
        else
        {
            Destroy(instantiatedBullet, bulletLifetime);
            instantiatedBullet.name = "EnemyBullet";
        }
            
    }

}
