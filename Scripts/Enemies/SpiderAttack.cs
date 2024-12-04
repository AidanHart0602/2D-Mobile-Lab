using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAttack : MonoBehaviour
{
    private Spider _spider;
    public void Fire()
    {
        _spider = GetComponentInParent<Spider>();
        _spider.Spit();
    }
}
