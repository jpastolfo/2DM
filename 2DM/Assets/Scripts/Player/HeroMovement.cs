using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    public float speed = 200.0f;
    public float jumpForce = 10.0f;
    public GameObject bulletPrefab;
    float moveDirection;
    float shootDirection = 0.0f;
    Rigidbody2D rb;
    bool canJump = true;
    GameManager gm;
    

    private void Start() {
        rb = GetComponentInChildren<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void FixedUpdate() {
        if (gm.isPlaying)
        {
            rb.velocity = new Vector2(moveDirection * speed * Time.deltaTime, rb.velocity.y);
        }
    }

    private void Update() {
        moveDirection = Input.GetAxisRaw("Horizontal");
        shootDirection = moveDirection != 0.0f ? moveDirection : shootDirection;

        if (Input.GetKeyDown(KeyCode.W) && canJump == true && gm.isPlaying) {
            canJump = false;
            rb.AddForce(Vector2.up * jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.Space) && gm.isPlaying) {
            GameObject bullet = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
            bullet.GetComponent<bullet>().dir = shootDirection;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            canJump = true;
        }
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBullet")
        {
            this.GetComponent<PlayerStats>().TakeDamage(1); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "WinTrigger")
        {
            Debug.Log("Win");
            gm.WinGame();
        }
    }
}
