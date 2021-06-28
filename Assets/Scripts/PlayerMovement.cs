using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 100;
    Vector3 move;

    public float jumpHeight = 4.5f;
    float gravity = -9.81f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxis("Horizontal");
        move.z = Input.GetAxis("Vertical");

        Vector3 player = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 deltaPosition = player - Input.mousePosition;
        float angle = -Mathf.Atan2(deltaPosition.y, deltaPosition.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(Vector3.up * angle);

        gravity -= 9.81f * Time.deltaTime;
        move.y = gravity;
        controller.Move(move * speed * Time.deltaTime);
        if (controller.isGrounded)
        {
            gravity = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gravity = jumpHeight;
            }
        }
        else
        {
            transform.parent = null;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "MovingPlatform")
        {
            transform.parent = hit.transform;
        }
        else
        {
            transform.parent = null;
        }
    }
}
