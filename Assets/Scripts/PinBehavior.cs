using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBehavior : MonoBehaviour
{
    Animator anim;
    
    public void Bounce(bool doBounce)
    {
        //anim = gameObject.GetComponent<Animator>();
        //anim.SetBool("bounce", doBounce);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (anim.GetBool("bounce") != false)
            {
                //anim.SetBool("bounce", false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            gameObject.transform.parent = collision.gameObject.transform;
        }
    }
}
