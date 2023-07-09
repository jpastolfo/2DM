using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public GameObject bulletPrefab;
    Transform target;
    [SerializeField] float reloadTime = 1f;
    [SerializeField] bool canShoot;
    float timer;

    private void Start()
    {
        timer = reloadTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            canShoot = true;
            ShootArrow();
        }
    }
    private void ShootArrow()
    {
        if (target != null && canShoot)
        {
            canShoot = false;
            timer = reloadTime;
            GameObject bullet = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
            bullet.transform.position = new Vector3(bullet.transform.position.x, bullet.transform.position.y, 0f);
            bullet bulletScript = bullet.GetComponent<bullet>();
            bulletScript.dir = -1f;
            bulletScript.fadeRate /= 3f;
            //Invoke("ArrowCooldown", reloadTime);
        }
    }

    private void ArrowCooldown()
    {
        Debug.Log("Reloading");
        ShootArrow();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Entrou");
            target = collision.transform;
            ShootArrow();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            target = null;
        }
    }

}
