using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    Slider healthSlider;

    private void Awake()
    {
        healthSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        if(GameManager.Instance != null && GameManager.Instance.player != null)
        {
            healthSlider.maxValue = 10;
        }
    }

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.player != null)
        {
            healthSlider.value = GameManager.Instance.player.CurrentHp;
        }
    }
}
