using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public GameObject bullet;
    public float shootForce = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject mybullet = Instantiate(bullet, transform.position, Quaternion.identity);
            mybullet.gameObject.name = "PlayerBullet";
            Vector3 direction = Quaternion.AngleAxis(-90, Vector3.up) * transform.forward;
            mybullet.GetComponent<Rigidbody>().AddForce(direction * shootForce);
            Destroy(mybullet, 2);
        }
    }
}
