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
    bool isHurt = false;
    private int maxHp = 10;
    private int currentHp;

    public int CurrentHp
    {
        get
        {
            return currentHp;
        }
        set
        {
            currentHp = Mathf.Clamp(value, 0, maxHp);

            Debug.Log($"currentHp: {currentHp} / {maxHp}");

            if(currentHp <= 0)
            {
                Die();
            }
        }
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        currentHp = maxHp;
    }
    private void FixedUpdate()
    {
        if (!isAttacking && !isHurt)
        {
            rigid.MovePosition(rigid.position + moveInput * speed * Time.fixedDeltaTime);
        }        
        anim.SetFloat("Speed", moveInput.magnitude);
        if(moveInput.x != 0)
        sr.flipX = moveInput.x < 0;
    }

    private void Update()
    {
        Flip();
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
        if (sr.flipX)
            punchHitbox.transform.localPosition = new Vector3(-0.9f, 0f, 0f);
        else
            punchHitbox.transform.localPosition = new Vector3(0f, 0f, 0f);
    }

    public void TakeDamage(int damage)
    {
        CurrentHp -= damage;
        StartCoroutine (HurtRoutine());
    }

    IEnumerator HurtRoutine()
    {
        isHurt = true;
        anim.SetBool("isHurt", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isHurt", false);
        isHurt = false;
    }
    void Die()
    {
        print("플레이어 사망");
    }
}
