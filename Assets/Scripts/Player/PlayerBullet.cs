using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    private Rigidbody2D rb;
    public float force;
    public float lifetime = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Debug.Log("Xxx");

       rb.velocity = Vector2.up * force;

        Destroy(gameObject, lifetime);
    }


}
