using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 5;
    bool isDead = false;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
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
}
