using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    [SerializeField] private float _jumpPower = 1;
    [SerializeField] private bool _grounded = false;
    private bool _jumpCD = false;
    private Rigidbody2D _rb;
    [SerializeField] private Animator _playerAnim;
    [SerializeField] private SpriteRenderer _playerSprite;
    // Start is called before the first frame update
    void Start()
    { 
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Grounded();
    }
    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(horizontal * _speed, _rb.velocity.y);

        if (_grounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower);
            _grounded = false;
            StartCoroutine(JumpCooldown());
        }
        AnimationChecks(horizontal);
    }

    void AnimationChecks(float Direction)
    {
        if (Direction > 0)
        {
            _playerSprite.flipX = false;
            _playerAnim.SetBool("Running", true);
        }

        else if (Direction < 0)
        {
            _playerSprite.flipX = true;
            _playerAnim.SetBool("Running", true);
        }

        else if(Direction == 0)
        {
            _playerAnim.SetBool("Running", false);
        }
    }

    private void Grounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, .6f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down, Color.green, .6f);

        if (hitInfo.collider != null)
        {
            Debug.Log(hitInfo.collider);
            if (_jumpCD == false)
            {
                _grounded = true;
            }
        }
    }
    IEnumerator JumpCooldown()
    {
        _jumpCD = true;
        yield return new WaitForSeconds(.2f);
        _jumpCD = false;
    }
}
