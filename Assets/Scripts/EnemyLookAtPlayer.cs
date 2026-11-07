using UnityEngine;

public class EnemyLookAtPlayer : MonoBehaviour
{
    SpriteRenderer sprite;
    Enemy enemy;
    GameObject player;
    public Transform playerTransform;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
        enemy = GetComponent<Enemy>();

        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    private void Update()
    {
        if (player == null) return;
        if (enemy.isDead) return;

        if (playerTransform.position.x > transform.position.x)
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
