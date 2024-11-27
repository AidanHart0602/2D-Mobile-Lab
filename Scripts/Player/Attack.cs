using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canAttack = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamage Hit = collision.GetComponent<IDamage>();
        if(Hit != null)
        {
            Debug.Log("Hit is not null");
            if (_canAttack == true)
            {
                Hit.Damage();
                StartCoroutine(Cooldown());
            }
        }
    }

    IEnumerator Cooldown()
    {
        _canAttack = false;
        yield return new WaitForSeconds(.5f);
        _canAttack = true;
    }
}
