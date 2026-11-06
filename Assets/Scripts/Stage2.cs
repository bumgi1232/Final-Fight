using UnityEngine;

public class Stage2 : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    private int aliveEnemy;

    private void Start()
    {
        aliveEnemy = enemy.Length;
    }

    public void RemoveEnemy()
    {
        aliveEnemy--;

        print($"남은 보스 {aliveEnemy}");
        if (aliveEnemy == 0)
        {
            UIManager.Instance.ShowGameClearPanel();
        }
    }
}
