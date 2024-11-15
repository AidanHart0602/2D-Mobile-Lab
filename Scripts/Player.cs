using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3;
    [SerializeField]
    private float _jumpPower = 1;
    [SerializeField]
    private bool _grounded = false;
    private bool _jumpCD = false;
    private Rigidbody2D _rb;

    private SpriteRenderer _playerSprite;
    // Start is called before the first frame update
    void Start()
    {
        _playerSprite = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        _rb.velocity = new Vector2(horizontal * _speed, _rb.velocity.y);
        if (_grounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower);
            _grounded = false;
            _jumpCD = true;
            StartCoroutine(JumpCooldown());
        }

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, .6f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down, Color.green, .6f);

        if (hitInfo != null)
        {
            if (_jumpCD == false)
            {
                _grounded = true;
            }
        }


    }

    IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(.1f);
        _jumpCD = false;
    }
}
