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
        healthSlider.maxValue = GameManager.Instance.player.maxHp;
    }

    private void Update()
    {
        healthSlider.value = GameManager.Instance.player.CurrentHp;
    }
}