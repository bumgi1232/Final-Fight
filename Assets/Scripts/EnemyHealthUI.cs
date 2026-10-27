using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    public GameObject headCanvas;
    public Slider healthSlider;

    [Header("감지 범위")]
    public float showHealthRange = 8f;

    [SerializeField] Transform player;
    Enemy enemy;


    private void Start()
    {
        enemy = GetComponent<Enemy>();
        enemy.OnHealthChanged.AddListener(OnHealthChanged);

        if(headCanvas != null)
        {
            headCanvas.SetActive(false);
        }
    }

    void OnHealthChanged(int maxHealth, int currentHealth)
    {
        if (healthSlider == null)
        {
            return;
        }
        healthSlider.value = currentHealth / maxHealth;
    }

    //private void Update()
    //{
    //    if (this == null || enemy == null || healthSlider == null || player == null) return;
    //    float distance = Vector3.Distance(transform.position, player.position);

    //    if (distance <= showHealthRange)
    //    {
    //        if(!headCanvas.activeSelf) headCanvas.SetActive(true);
    //        TargetHealthUi.Instance.ShowTargetUI();
    //    }
    //    else
    //    {
    //        if(headCanvas.activeSelf) headCanvas.SetActive(false);
    //    }

    //}
}
