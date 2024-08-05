using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public static float playerXPos;

    float direction;
    public float speed;
    public GameObject firePrefab;
    private float minX, maxX, minY, maxY;
    private bool isAlive ;

    public static Transform playerTransform;

    void Awake()
    {
        playerTransform = transform;
    }

    void Start()
    {
        speed = 10;
        isAlive = true;
    }

    void Update()
    {
        if (!PlayerManager.instance.isPlayerDead)
        {
            Movement();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
            playerXPos = transform.position.x;
        }
    }



    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector3(horizontalInput, verticalInput);
        transform.Translate(movement * speed * Time.deltaTime);
        ClampPlayerPosition();

    }


    private void Shoot()
    {
        Vector2 spawnPosition = new Vector2(transform.position.x,transform.position.y);
        Instantiate(firePrefab, spawnPosition, Quaternion.identity);
        SoundManager.instance.PlayerShotSound();
  
    }



    public void ButtonPressFunc(string dir)
    {
        if (dir == "Right")
        {
            direction = +10;
            transform.Translate(direction * speed * Time.deltaTime,0, 0);
        }

        if (dir == "Left")
        {
            direction = -10;
            transform.Translate(direction * speed * Time.deltaTime, 0, 0);
        }

        if (dir == "Up")
        {
            direction = +10;
            transform.Translate(0, direction * speed * Time.deltaTime, 0);
        }

        if (dir == "Down")
        {
            direction = -10;
            transform.Translate(0, direction* speed * Time.deltaTime, 0);
        }

        if (dir == "Fire" && isAlive)
        {
            Shoot();
        }
    }

    private void ClampPlayerPosition()
    {
        // Get the screen boundaries in world coordinates
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // Clamp the player's position within these boundaries
        Vector2 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -screenBounds.x + 0.4f, screenBounds.x - 0.4f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -screenBounds.y +.7f, screenBounds.y -.7f);

        // Apply the clamped position
        transform.position = clampedPosition;
    }
}
