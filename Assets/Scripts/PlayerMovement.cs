using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 100;
    Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxis("Horizontal");
        move.z = Input.GetAxis("Vertical");
        controller.Move(move * speed * Time.deltaTime);

        Vector3 player = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 deltaPosition = player - Input.mousePosition;
        float angle = -Mathf.Atan2(deltaPosition.y, deltaPosition.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(Vector3.up * angle);
    }
}
