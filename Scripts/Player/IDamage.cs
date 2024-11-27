using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamage
{
    int Health { get; set; }
    public void Damage();
}
