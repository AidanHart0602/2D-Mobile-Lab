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
        Health = Health - 1;
        anim.SetTrigger("Injured");
        isHit = true;
        anim.SetBool("InCombat", true);
        if (Health < 1)
        {
            Death();
        }
    }
}
