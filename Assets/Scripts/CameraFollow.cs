using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = player.transform.position - offset;
        transform.position = Vector3.Lerp(transform.position, camPos, 10 * Time.deltaTime);
    }
}
