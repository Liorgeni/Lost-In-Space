using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject enemyFirePrefab;

    public float minShootInterval = 1f; 
    public float maxShootInterval = 4f; 

    void Start()
    {
        float initialDelay = Random.Range(0f, maxShootInterval);
        float shootInterval = Random.Range(minShootInterval, maxShootInterval);
        InvokeRepeating("Shoot", initialDelay, shootInterval);
    }

    void Update()
    {
        Movement();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {            
          Destroy(gameObject);
          EnemyManager.instance.count--;

        }


        if (other.gameObject.tag == "PlayerBullet")
        {
            EffectsManager.instance.ActivateEnemyExplosion(transform.position);
            Score.Instance.UpdateScoreDisplay(100);
            Destroy(gameObject);
            Destroy(other.gameObject);
            EnemyManager.instance.count--;

        }


        if (other.gameObject.tag == "Player")
        {
            PlayerManager.instance.isPlayerDead = true; 
            Destroy(gameObject);
            Destroy(other.gameObject);
            EffectsManager.instance.ActivatePlayerExplosion(other.gameObject.transform.position);
            SoundManager.instance.playExplodeSound();
        }
    }


    public void Movement()
    { 
            transform.Translate(0, -1 * Time.deltaTime, 0);


        if (transform.position.x < PlayerMovment.playerXPos)
        {
            transform.Translate(1 * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Translate(-1 * Time.deltaTime, 0, 0);
        }
    }

    private void Shoot()
    {
        if (transform.position.y < PlayerMovment.playerTransform.position.y) return;

        Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y);
        Instantiate(enemyFirePrefab, spawnPosition, Quaternion.identity);
    }


}
