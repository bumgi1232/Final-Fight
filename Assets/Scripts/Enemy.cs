using NUnit.Framework.Constraints;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public bool isDead = false;
    bool isAttack = false;
    int blinkCount = 3;
    public int maxHp = 10;
    public bool isBoss;
    public int CurrentHp { get; private set; }

    public GameObject attackBox;
    Animator anim;
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    NavMeshAgent agent;

    public CountEnemy countEnemy;
    public Stage2 stage2;
    public TargetHealthUi targetHealthUi;

    private void Start()
    {
        CurrentHp = maxHp;
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {                

    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        CurrentHp -= damage;

        if(CurrentHp > 0)
        {
            StartCoroutine(hurtRoutine());
        }
        else
        {
            Die();
            targetHealthUi.HideTargetUI();
            if(!isBoss)
                countEnemy.RemoveEnemy();
            if (isBoss)
                stage2.RemoveEnemy();
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

    public void MoveToWithNav(Vector3 destination)
    {
        if (isDead) return;
        agent.isStopped = false;        
        agent.SetDestination(destination);
        anim.SetBool("isWalking", true);
    }
    public void Stop()
    {
        agent.isStopped = true;
        anim.SetBool("isWalking", false);              
    }

    public void Attack()
    {
        if (isDead) return;
        agent.isStopped = true;
        StartCoroutine(AttackRoutine());
    }


    IEnumerator AttackRoutine()
    {
        if (isAttack) yield break;
        isAttack = true;       
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttack", true);
        yield return new WaitForSeconds(0.3f);
        attackBox.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        attackBox.SetActive(false);
        yield return new WaitForSeconds(0.7f);
        anim.SetBool("isAttack", false);
        isAttack = false;
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

    public void BackStep(Vector3 destination)
    {
        if (isDead) return;
        anim.SetBool("isWalking", true);
        agent.isStopped = false;
        agent.SetDestination(destination);
    }
    
}
