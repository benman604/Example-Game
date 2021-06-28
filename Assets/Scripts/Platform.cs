using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Vector3 velocity;
    public float wavelength;
    public float offset = 0;

    Vector3 inital;

    // Start is called before the first frame update
    void Start()
    {
        inital = transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 move = Vector3.zero;
        float x = (2 * Mathf.PI) / wavelength;
        move.x = velocity.x * Mathf.Sin(Time.time * x + offset);
        move.y = velocity.y * Mathf.Sin(Time.time * x + offset);
        move.z = velocity.z * Mathf.Sin(Time.time * x + offset);
        transform.localPosition = inital + move;
    }
}
