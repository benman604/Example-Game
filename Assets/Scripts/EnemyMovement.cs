using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float viewDistance = 10;
    public float moveSpeed = 1;
    public GameObject player;
    public CharacterController controller;

    public float life = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < viewDistance)
        {
            Vector3 deltaPosition = transform.position - player.transform.position;
            float angle = -Mathf.Atan2(deltaPosition.z, deltaPosition.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(angle * Vector3.up);

            Vector3 direction = Quaternion.AngleAxis(-90, Vector3.up) * transform.forward;
            controller.Move(direction * moveSpeed * Time.deltaTime);
        }

        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.name == "PlayerBullet")
        {
            life -= 20;
        }
    }
}
