using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] GameManager gm;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void TakeDamage(int amount)
    {
        if (health - amount > 0)
        {
            health -= amount;
        }
        else
        {
            health = 0;
            this.gameObject.SetActive(false); // Better than destroying Player, so that cinemachine keeps a reference to follow
            gm.ShowLoseUI();
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
