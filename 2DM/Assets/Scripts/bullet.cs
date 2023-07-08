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
    Color spriteColor;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteColor = GetComponent<SpriteRenderer>().color;
        fade = spriteColor.a;
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(dir * speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        fade = Mathf.Clamp(fade - fadeRate * Time.deltaTime,0,255);
        this.GetComponent<SpriteRenderer>().color = new Color(spriteColor.r,spriteColor.g,spriteColor.b,fade);

        if (fade == 0) {
            Destroy(gameObject);
        }
    }
}
