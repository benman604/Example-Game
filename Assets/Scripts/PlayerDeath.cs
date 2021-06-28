using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    GameObject currentCheckpoint;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Checkpoint")
        {
            currentCheckpoint = hit.gameObject;
        }
        if(hit.gameObject.tag == "OnHitDie")
        {
            Die();
        }
    }

    void Die()
    {
        Vector3 respawnPos = currentCheckpoint.transform.GetChild(0).transform.position;
        transform.position = respawnPos;
    }
}
