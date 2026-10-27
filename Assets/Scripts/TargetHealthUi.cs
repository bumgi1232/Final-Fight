using UnityEngine;
using UnityEngine.UI;

public class TargetHealthUi : MonoBehaviour
{
    public static TargetHealthUi Instance { get; private set; }

    public GameObject targetSlider;
    public Slider healthSlider;

    private Transform currentTarget;
    private Enemy enemy;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        if(targetSlider != null)
        {
            targetSlider.SetActive(false);
        }
    }

    private void Update()
    {
        if(currentTarget != null && enemy != null)
        {
            healthSlider.value = enemy.CurrentHp;
        }
    }

    public void ShowTargetUI(Transform target, Enemy enemyHealth)
    {
        currentTarget = target;
        enemy = enemyHealth;

        if(targetSlider != null)
        {
            targetSlider.SetActive(true);
        }

        healthSlider.maxValue = enemyHealth.maxHp;
        healthSlider.value = enemy.CurrentHp;
    }

    public void HideTargetUI()
    {
        currentTarget = null;
        enemy = null;

        if(targetSlider != null)
        {
            targetSlider.SetActive(false);
        }
    }
}
