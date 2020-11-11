using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    public Rigidbody2D RB;
    public float jumpForce;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private bool canDoubleJump;

    private Animator animator;
    private SpriteRenderer SR;

    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (knockBackCounter <= 0)
        {
            RB.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), RB.velocity.y);

            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

            if (isGrounded)
            {
                canDoubleJump = true;
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    RB.velocity = new Vector2(RB.velocity.x, jumpForce);
                }
                else
                {
                    if (canDoubleJump)
                    {
                        RB.velocity = new Vector2(RB.velocity.x, jumpForce);
                        canDoubleJump = false;
                    }
                }
            }

            if (RB.velocity.x < 0)
            {
                SR.flipX = true;
            }
            else if (RB.velocity.x > 0)
            {
                SR.flipX = false;
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
            if(!SR.flipX)
            {
                RB.velocity = new Vector2(-knockBackForce, RB.velocity.y);
            }
            else
            {
                RB.velocity = new Vector2(knockBackForce, RB.velocity.y);
            }
        }

        animator.SetFloat("moveSpeed", Mathf.Abs(RB.velocity.x));
        animator.SetBool("isGrounded", isGrounded);
    }

    public void KnockBack()
    {
        knockBackCounter = knockBackLength;
        RB.velocity = new Vector2(0f, knockBackForce);

        animator.SetTrigger("hurt");
    }
}
