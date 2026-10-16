using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer sr;
    public GameObject punchHitbox;
    Vector2 moveInput;
    public float speed = 5f;
    bool isAttacking = false;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!isAttacking)
        {
            rigid.MovePosition(rigid.position + moveInput * speed * Time.fixedDeltaTime);
        }        
        anim.SetFloat("Speed", moveInput.magnitude);
        if(moveInput.x != 0)
        sr.flipX = moveInput.x < 0;
    }


    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnPunch()
    {
        if (!isAttacking)
        {
            StartCoroutine(PunchRoutine());
        }
    }
    
    IEnumerator PunchRoutine()
    {
        isAttacking = true;
        anim.SetBool("Punch", true);
        punchHitbox.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("Punch", false);
        isAttacking = false;
        punchHitbox.SetActive(false);
    }

    void Flip()
    {
        
    }

}
