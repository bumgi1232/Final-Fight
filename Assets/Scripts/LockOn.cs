using UnityEngine;

public class LockOn : MonoBehaviour
{ 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            TargetHealthUi.Instance.ShowTargetUI();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TargetHealthUi.Instance.HideTargetUI();
        }
    }
}
