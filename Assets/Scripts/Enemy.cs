using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int health = 5;
    public bool isDead = false;
    bool isAttack = false;
    [SerializeField] Transform target;
    public GameObject attackBox;
    Animator anim;
    Rigidbody2D rigid;
    NavMeshAgent agent;

    [Header("이동 및 공격 설정")]
    public float attackRange = 1.2f;   // 이 거리보다 가까워지면 공격
    public float chaseRange = 8.0f;    // 이 거리 안에 들어오면 쫓아옴

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);

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

    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        health -= damage;

        if(health > 0)
        {
            print("Hit! Enemy health: " + health);
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
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("isHurt", false);
    }

    void Die()
    {
        isDead = true;

        print("Enemy died!");
        anim.SetTrigger("isDead");
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
