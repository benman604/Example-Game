using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    GameObject currentCheckpoint;
    public float life = 100;

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

        if(hit.gameObject.name == "EnemyBullet")
        {
            life -= 20;
        }
    }

    void Die()
    {
        life = 100;
        Vector3 respawnPos = currentCheckpoint.transform.GetChild(0).transform.position;
        transform.position = respawnPos;
    }

    private void Update()
    {
        if(life <= 0)
        {
            Die();
        }
    }
}
