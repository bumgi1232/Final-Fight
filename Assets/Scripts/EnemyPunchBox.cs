using UnityEngine;

<<<<<<< HEAD
public class EnemyPunchBox : Enemy
=======
public class EnemyPunchBox : MonoBehaviour
>>>>>>> 64860cbb2631adeefaf15b18d31d7a08a7c8758d
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerHitbox"))
        {
            Player player = collision.GetComponentInParent<Player>();

<<<<<<< HEAD
            player.TakeDamage(attackPower);
=======
            player.Hurt();
>>>>>>> 64860cbb2631adeefaf15b18d31d7a08a7c8758d
        }
    }
}
