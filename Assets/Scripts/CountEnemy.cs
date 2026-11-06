using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CountEnemy : MonoBehaviour
{
    [SerializeField] GameObject[] enemy;
    private int aliveEnemies;
    public StageManager stageManager;
    public GameObject stage1collider;
    public CinemachineCamera stageCameras;
    public Transform player;

    private void Start()
    {
        aliveEnemies = enemy.Length;
    }
    public void RemoveEnemy()
    {
        aliveEnemies--;

        print("남은 적: " + aliveEnemies);

        if (aliveEnemies == 0 && stageManager.currentStage == 0)
        {
            stageManager.ChangeStage(1);
            stage1collider.SetActive(false);
            StartCoroutine(ChangeCameraRoutine());
        }
    }

    IEnumerator ChangeCameraRoutine()
    {
        yield return new WaitForSeconds(2f);
        stageCameras.Follow = player;

    }
}
