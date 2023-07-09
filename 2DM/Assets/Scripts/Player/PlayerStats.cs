using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int health = 1;
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
            // Show Lose UI
        }
    }
}
