using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnims : MonoBehaviour
{
    [SerializeField]
    private Animator _swordArc;
    [SerializeField]
    private SpriteRenderer _arcSprite;
    private Animator _playerAnim;
    private SpriteRenderer _playerSprite;
    [SerializeField]
    private Transform _arcTransform;
    // Start is called before the first frame update
    void Start()
    {
        _playerAnim = GetComponent<Animator>();
        _playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void JumpSwitch(bool Switch)
    {
        _playerAnim.SetBool("Jump", Switch);
    }

    public void AttackAnim()
    {
        if(_playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Reg Jump Landing"))
        {
            return;
        }
        else
        {
            _playerAnim.SetTrigger("Attack");
            _swordArc.SetTrigger("ArcActive");
        }  
    }

    public void MovementChecks(float Direction)
    {
        if (Direction > 0)
        {
            _playerAnim.SetBool("Running", true);
            _playerSprite.flipX = false;
            _arcTransform.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        else if (Direction < 0)
        {
            _playerAnim.SetBool("Running", true);
            _playerSprite.flipX = true;
            _arcTransform.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        else if (Direction == 0)
        {
            _playerAnim.SetBool("Running", false);
        }
    }
}
