using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public float dir;
    public float fadeRate;
    float fade;
    Rigidbody2D rb;
    [SerializeField]Color spriteColor;
    [SerializeField] bool hasFade;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteColor = GetComponentInChildren<SpriteRenderer>().color;
        fade = spriteColor.a;
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(dir * speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        fade = Mathf.Clamp(fade - fadeRate * Time.deltaTime,0,255);
        this.GetComponentInChildren<SpriteRenderer>().color = new Color(spriteColor.r,spriteColor.g,spriteColor.b,fade);

        //*
        if (fade == 0 && hasFade) {
            Destroy(gameObject);
        }
        //*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player" && this.tag == "EnemyBullet")
        {
            collision.transform.GetComponent<PlayerStats>().TakeDamage(1);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy" && this.tag == "Bullet")
        {
            collision.transform.GetComponent<HealthManager>().TakeDamage(1);
            Destroy(this.gameObject);
        }
    }
}
