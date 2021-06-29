using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public float viewDistance = 10;
    public float shootInterval = 0.5f;
    public float shootForce = 1000;
    public GameObject player;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < viewDistance)
        {
            GameObject mybullet = Instantiate(bullet, transform.position, Quaternion.identity);
            mybullet.gameObject.name = "EnemyBullet";
            Vector3 direction = Quaternion.AngleAxis(-90, Vector3.up) * transform.forward;
            mybullet.GetComponent<Rigidbody>().AddForce(direction * shootForce);
            Destroy(mybullet, 2);
        }
        Invoke("Shoot", shootInterval);
    }
}
