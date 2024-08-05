using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force;
    private Vector3 direction;
    public float lifetime = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Calculate the direction from the shot to the player
        Vector2 direction = (PlayerMovment.playerTransform.position - transform.position).normalized;

        rb.velocity = direction * force;

        Destroy(gameObject, lifetime);

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerManager.instance.isPlayerDead = true;
            EffectsManager.instance.ActivatePlayerExplosion(other.gameObject.transform.position);
            SoundManager.instance.playExplodeSound();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}
