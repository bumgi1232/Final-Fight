using UnityEngine;

public class PunchBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.TakeDamage(1);
        }
        if(collision.CompareTag("Box"))
        {
            BoxCrush boxCrush = collision.GetComponent<BoxCrush>();
            boxCrush.CrushBox();
        }
    }
}
