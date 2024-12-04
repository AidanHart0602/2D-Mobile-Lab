using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour, IDamage
{
   
    [SerializeField] private int _health = 3;
    [SerializeField] private float _speed = 3;
    [SerializeField] private float _jumpPower = 1;
    public int Loot;
    [SerializeField] private bool _grounded = false;
    private bool _jumpCD = false, _attackCD = true, _alive = true;
    private Rigidbody2D _rb;
    [SerializeField] private PlayerAnims _anims;
    private UIManager _uiManager;
    public int Health { get; set;}

    // Start is called before the first frame update
    void Start()
    {
        Health = _health;
        _rb = GetComponent<Rigidbody2D>();
        _uiManager = FindFirstObjectByType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_alive == true)
        {
            Movement();
            AttackInput();
        }

        Grounded();
    }

    void Movement()
    {
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        _rb.velocity = new Vector2(horizontal * _speed, _rb.velocity.y);

        if (_grounded == true && (Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("B_Button")))
        {
            _anims.JumpSwitch(true);
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower);
            _grounded = false;
            StartCoroutine(JumpCooldown());
        }
        _anims.MovementChecks(horizontal);
    }
    public void Damage()
    {
        Health--;
        _uiManager.HealthBits(Health);
        if(Health < 1 && _alive == true)
        {
            _alive = false;
            _anims.Death();
        }

        else if(Health > 1)
        {
            Debug.Log("Playing Hit animation");
            _anims.HitAnim();
        }
    }
    void AttackInput()
    {
        if (_attackCD == true && (Input.GetKeyDown(KeyCode.E) || CrossPlatformInputManager.GetButtonDown("A_Button")))
        {
            _anims.AttackAnim();
            _attackCD = false;
            StartCoroutine(AttackCD());
        }
    }

    private void Grounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, .6f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down, Color.green, .6f);

        if (hitInfo.collider != null)
        {
            if (_jumpCD == false)
            {
                _anims.JumpSwitch(false);
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

    IEnumerator AttackCD()
    {
        yield return new WaitForSeconds(1.5f);
        _attackCD = true;
    }
}
