using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSkeleton : MonoBehaviour
{
    public GameObject bulletPrefab;
    GameObject target;
    [SerializeField] float reloadTime = 1f;
    [SerializeField] bool canShoot;
    float timer;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        timer = reloadTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f && target != null)
        {
            canShoot = true;
            anim.SetBool("isAttacking", true);
            timer = reloadTime;
        }
    }

    private void Attack()
    {
        if (target != null)
        {
            target.GetComponent<PlayerStats>().TakeDamage(1);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Entrou");
            target = collision.gameObject;
            anim.SetBool("isAttacking", true);
        }
    }

    public void StopAnim()
    {
        anim.SetBool("isAttacking", false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            target = null;
            timer = reloadTime;
        }
    }

}
