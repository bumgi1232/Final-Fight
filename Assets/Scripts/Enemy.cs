using NUnit.Framework.Constraints;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
<<<<<<< HEAD
    public bool isDead = false;
    bool isAttack = false;
    int blinkCount = 5;
    float attackTimer = 0f;
    float attackInterval = 2f;
    public int attackPower = 1;
    public int maxHp = 10;
    public int CurrentHp { get; private set; }
=======
    public int health = 5;
    public bool isDead = false;
    bool isAttack = false;
>>>>>>> 64860cbb2631adeefaf15b18d31d7a08a7c8758d
    [SerializeField] Transform target;
    public GameObject attackBox;
    Animator anim;
    Rigidbody2D rigid;
<<<<<<< HEAD
    SpriteRenderer sprite;
=======
>>>>>>> 64860cbb2631adeefaf15b18d31d7a08a7c8758d
    NavMeshAgent agent;

    [Header("이동 및 공격 설정")]
    public float attackRange = 1.2f;   // 이 거리보다 가까워지면 공격
    public float chaseRange = 8.0f;    // 이 거리 안에 들어오면 쫓아옴
<<<<<<< HEAD



    private void Start()
    {
        CurrentHp = maxHp;
    }
=======
>>>>>>> 64860cbb2631adeefaf15b18d31d7a08a7c8758d

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
<<<<<<< HEAD
        sprite = GetComponent<SpriteRenderer>();
=======
>>>>>>> 64860cbb2631adeefaf15b18d31d7a08a7c8758d
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);
<<<<<<< HEAD
        attackTimer += Time.deltaTime;

        if(!isDead)
        {
            if (distanceToPlayer <= chaseRange && distanceToPlayer > attackRange && !isAttack)
            {
                ChasePlayer();
            }
            else if (distanceToPlayer <= attackRange)
            {                
                StopAndAttack();                
            }
            else
            {
                StopMoving();
            }
        }        
=======

        if (distanceToPlayer <= chaseRange && distanceToPlayer > attackRange)
        {
            ChasePlayer();
        }
        else if (distanceToPlayer <= attackRange)
        {
            StopAndAttack();
        }
        else
        {
            StopMoving();
        }

>>>>>>> 64860cbb2631adeefaf15b18d31d7a08a7c8758d
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        CurrentHp -= damage;
        attackTimer = 0;

        if(CurrentHp > 0)
        {
            StartCoroutine(hurtRoutine());
        }
        else
        {
            Die();
        }
    }

    

    IEnumerator hurtRoutine()
    {        
        anim.SetBool("isHurt", true);
        yield return new WaitForSeconds(0.05f);
        anim.speed = 0f;
        yield return new WaitForSeconds(0.2f);
        anim.speed = 1f;
        anim.SetBool("isHurt", false);
    }

    void Die()
    {
        isDead = true;
        
        anim.SetTrigger("isDead");
        StartCoroutine(BlinkAndDieRoutine());
    }

    void ChasePlayer()
    {
        agent.isStopped = false;
        agent.SetDestination(target.position);
        anim.SetBool("isWalking", true);
    }
    void StopAndAttack()
    {
        agent.isStopped = true;
        anim.SetBool("isWalking", false);
        if (attackTimer >= attackInterval)
            StartCoroutine(AttackRoutine());
    }
    void StopMoving()
    {
        agent.isStopped = true;
        anim.SetBool("isWalking", false);
    }

    IEnumerator AttackRoutine()
    {
        if (isAttack) yield break;
        isAttack = true;       
        anim.SetBool("isAttack", true);
        yield return new WaitForSeconds(0.3f);
        attackBox.SetActive(true);
        yield return new WaitForSeconds(1f);
        attackBox.SetActive(false);
        anim.SetBool("isAttack", false);
        isAttack = false;
        attackTimer = 0f;
    }

    IEnumerator BlinkAndDieRoutine()
    {
        yield return new WaitForSeconds(0.8f);
        for(int i = 0; i < blinkCount; i++)
        {
            SetAlpha(0.2f);
            yield return new WaitForSeconds(0.15f);

            SetAlpha(1.0f);
            yield return new WaitForSeconds(0.15f);
        }

        Destroy(gameObject);
    }

    void SetAlpha(float alpha)
    {
        if(sprite != null)
        {
            Color color = sprite.color;
            color.a = alpha;
            sprite.color = color;
        }
    }

    void ChasePlayer()
    {
        agent.isStopped = false;
        agent.SetDestination(target.position);
        anim.SetBool("isWalking", true);
    }
    void StopAndAttack()
    {
        agent.isStopped = true;
        anim.SetBool("isWalking", false);
        StartCoroutine(AttackRoutine());
    }
    void StopMoving()
    {
        agent.isStopped = true;
        anim.SetBool("isWalking", false);
    }

    IEnumerator AttackRoutine()
    {
        if (isAttack) yield break;
        isAttack = true;
        yield return new WaitForSeconds(1f);        
        anim.SetBool("isAttack", true);
        yield return new WaitForSeconds(0.3f);
        attackBox.SetActive(true);
        yield return new WaitForSeconds(1f);
        attackBox.SetActive(false);
        anim.SetBool("isAttack", false);
        isAttack = false;
    }
}
