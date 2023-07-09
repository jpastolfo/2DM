using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] GameManager gm;
    HeroMovement hm;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        hm = GetComponent<HeroMovement>();
    }

    public void TakeDamage(int amount)
    {
        if (health - amount > 0)
        {
            health -= amount;
        }
        else
        {
            hm.isAttacking = false;
            FindObjectOfType<AudioManager>().Play("Death");
            health = 0;
            this.gameObject.SetActive(false); // Better than destroying Player, so that cinemachine keeps a reference to follow
            gm.ShowLoseUI();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "DeathTrigger")
        {
            TakeDamage(100);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DeathTrigger")
        {
            TakeDamage(100);
        }
    }
}
