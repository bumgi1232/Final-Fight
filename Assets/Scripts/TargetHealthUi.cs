using UnityEngine;
using UnityEngine.UI;

public class TargetHealthUi : MonoBehaviour
{
    public static TargetHealthUi Instance { get; private set; }

    public GameObject targetCanvus;
    public Slider healthSlider;
    public Enemy enemy;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        if(targetCanvus != null)
        {
            targetCanvus.SetActive(false);
        }
    }

    private void Update()
    {
        if(enemy != null)
        healthSlider.value = enemy.CurrentHp;
    }

    public void ShowTargetUI()
    {

        if(targetCanvus != null)
        {
            targetCanvus.SetActive(true);
        }

        healthSlider.maxValue = enemy.maxHp;
        healthSlider.value = enemy.CurrentHp;
    }

    public void HideTargetUI()
    {
        if(targetCanvus != null)
        {
            targetCanvus.SetActive(false);
        }
    }
}
