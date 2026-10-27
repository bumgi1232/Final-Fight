using UnityEngine;

public class EnemyLookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    SpriteRenderer sprite;
    Enemy enemy;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (player == null) return;
        if (enemy.isDead) return;

        if (player.position.x > transform.position.x)
        {
            sprite.flipX = false;
            enemy.attackBox.transform.localPosition = new Vector3(0f, 0f, 0f);
        }
        else
        {
            sprite.flipX = true;
            enemy.attackBox.transform.localPosition = new Vector3(-0.9f, 0f, 0f);
        }        

        

    }
}
