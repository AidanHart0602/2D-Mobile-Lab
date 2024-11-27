using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health, loot;
    [SerializeField] protected float speed;
    [SerializeField] protected Transform pointA, pointB;
    protected Transform currentTarget;
    protected SpriteRenderer sprite;
    protected Animator anim;
    protected Player player;
    protected bool isHit;
    public void ComponentGrab()
    {
        currentTarget = pointB;
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false)
        {
            return;
        }
        else
        {
            Movement();
        }
    }

    public void Movement()
    {
        if(isHit == false)
        {
            if (currentTarget == pointA)
            {
                sprite.flipX = false;
            }

            else
            {
                sprite.flipX = true;
            }

            if (transform.position == pointB.position)
            {
                currentTarget = pointA;
                anim.SetTrigger("Idle");
            }
            else if (transform.position == pointA.position)
            {
                currentTarget = pointB;
                anim.SetTrigger("Idle");
            }
        }
        
        
        if (isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
        }

        InCombat();
    }

    public void InCombat() 
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        Vector3 direction = player.transform.position - transform.position;
        if (distance > 5.0f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }

        if(direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = false;
        }

        else if(direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = true;
        }
    }
}
