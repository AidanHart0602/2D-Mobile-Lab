using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamage

{
    [SerializeField] private GameObject _acidPrefab;
    public int Health { get; set; }
    void Start()
    {
        ComponentGrab();
        Health = base.health;
    }

    public override void Update()
    {

    }

    public void Damage()
    {
        Health--;

        if (Health < 1)
        {
            Death();
        }
    }

    public void Spit()
    {
        Instantiate(_acidPrefab, transform.position, Quaternion.identity);
    }
}
