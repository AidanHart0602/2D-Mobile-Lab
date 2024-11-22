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

    public void ComponentGrab()
    {
        currentTarget = pointB;
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
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

        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
    }
}
