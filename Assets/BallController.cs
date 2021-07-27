using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public Rigidbody2D rb;
    SpriteRenderer render;
    AudioSource audio;
    public Sprite[] ballSkins;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        Respawn();

    }

    public void Respawn()
    {
        render.sprite = ballSkins[Random.Range(0, ballSkins.Length)];
        this.transform.position = Vector3.zero;
        audio.Play();
        float speed = Random.Range(1f, 3f);
        int dirX = 0;
        int dirY = 0;
        while (dirX == 0)
        {
            dirX = Random.Range(-1, 2);
        }
        while(dirY == 0)
        { 
            dirY = Random.Range(-1, 2);
        }
        rb.velocity = new Vector2(dirX * speed, dirY * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 n = collision.GetContact(0).normal.normalized;
        Vector2 i = rb.velocity;
        Vector2 r;
        float dot = Vector2.Dot(n, i);
        r = i - (2f * dot) * n;
        r *= 1.1f;
        //if(collision.GetContact(0).point.y)
        rb.velocity = r;
    }
}
