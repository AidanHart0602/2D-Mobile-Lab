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
        _playerAnim.SetTrigger("Attack");
        _swordArc.SetTrigger("ArcActive");
    }

    public void AnimationChecks(float Direction)
    {


        if (Direction > 0)
        {
            _playerAnim.SetBool("Running", true);
            _arcSprite.flipX = false;
            _playerSprite.flipX = false;
        }


        else if (Direction < 0)
        {
            _playerAnim.SetBool("Running", true);
            _arcSprite.flipX = true;
            _playerSprite.flipX = true;
        }

        else if (Direction == 0)
        {
            _playerAnim.SetBool("Running", false);
        }
    }
}
