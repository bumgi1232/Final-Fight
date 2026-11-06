using UnityEngine;
using UnityEngine.UI;

public class TargetHealthUi : MonoBehaviour
{
    public GameObject targetCanvus;
    public Slider healthSlider;
    public Enemy enemy;

    private void Awake()
    {
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
