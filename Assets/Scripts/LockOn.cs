using UnityEngine;

public class LockOn : MonoBehaviour
{
    public TargetHealthUi targetHealthUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            targetHealthUI.ShowTargetUI();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            targetHealthUI.HideTargetUI();
        }
    }
}
