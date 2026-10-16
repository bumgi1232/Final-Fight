using UnityEngine;

public class EnemyLookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (player == null) return;

        if (player.position.x > transform.position.x)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }
    }
}
