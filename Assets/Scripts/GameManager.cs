using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameOver = false;
    public Player player;
    public PlayerJump jump;
    private int coin = 0;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (isGameOver)
        {
            UIManager.Instance.insertCoin.text = $"INSERT COIN: {coin}";

            if (Keyboard.current.cKey.wasPressedThisFrame)
            {
                coin++;                                              
                StartCoroutine(RestartGameRoutine());                
            }
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;
        player.enabled = false;
        StartCoroutine(GameOverAnimRoutine());                        
    }

    IEnumerator GameOverAnimRoutine()
    {
        isGameOver = true;
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;                
        UIManager.Instance.ShowGameOverPanel();
    }

    void RestartGame()
    {
        player.enabled = true;
        isGameOver = false;
        Time.timeScale = 1f;
        coin--;
        player.CurrentHp = player.maxHp;
        UIManager.Instance.HideGameOverPanel();
        jump.RestartJump();
    }

    IEnumerator RestartGameRoutine()
    {
        yield return new WaitForSecondsRealtime(2f);
        RestartGame();
    }
}
