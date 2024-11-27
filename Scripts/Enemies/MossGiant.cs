using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamage
{
    public int Health
    { get; set;}

    void Start()
    {
        ComponentGrab();
        Health = base.health;
    }
    public void Damage() 
    {
        anim.SetBool("InCombat", true);
        anim.SetTrigger("Injured");
        Health = Health - 1;
        isHit = true;
        if(Health < 1)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
