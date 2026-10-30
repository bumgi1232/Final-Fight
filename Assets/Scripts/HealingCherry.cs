using UnityEngine;

public class HealingCherry : MonoBehaviour
{
    int healed = 5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.player.CurrentHp += healed;
            Destroy(gameObject);
        }
    }
}
