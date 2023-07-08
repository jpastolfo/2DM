using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;
    public float dir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(dir * speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
