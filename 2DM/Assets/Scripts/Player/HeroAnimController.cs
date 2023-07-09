using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimController : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void StopAnim()
    {
        Debug.Log("Stop");
        anim.SetBool("isAttacking", false);
    }
}
