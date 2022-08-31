using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed = 50f;
    private Rigidbody2D rb;
    private readonly int ttl = 2;
    private int aliveFor = 0;
    private int fixedUpdateCount = 0;
    private Text scoreText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    void FixedUpdate()
    {

        if (aliveFor == ttl)
        {
            Destroy(gameObject);
        }
        fixedUpdateCount += 1;
        if (fixedUpdateCount % 50 == 0)
        {
            aliveFor += 1;
        }
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.name == "Enemy(Clone)")
        {
            Destroy(collision.gameObject);
            scoreText.text = (Int32.Parse(scoreText.text) + 10).ToString();
        }
    }

}
