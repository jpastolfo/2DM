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

    private void Start() {
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(moveDirection * speed * Time.deltaTime, rb.velocity.y);
    }

    private void Update() {
        moveDirection = Input.GetAxisRaw("Horizontal");
        shootDirection = moveDirection != 0.0f ? moveDirection : shootDirection;

        if (Input.GetKeyDown(KeyCode.W) && canJump == true) {
            canJump = false;
            rb.AddForce(Vector2.up * jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject bullet = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
            bullet.GetComponent<bullet>().dir = shootDirection;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            canJump = true;
        }
    }
}
