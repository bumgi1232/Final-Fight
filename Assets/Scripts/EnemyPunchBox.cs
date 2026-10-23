using UnityEngine;

public class EnemyPunchBox : Enemy
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerHitbox"))
        {
            Player player = collision.GetComponentInParent<Player>();

            player.TakeDamage(attackPower);
        }
    }
}
