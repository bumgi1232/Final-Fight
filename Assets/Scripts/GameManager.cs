using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Score = 0;
    public bool isGameOver = false;
    public Player player;

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
        if(Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame && isGameOver)
        {
            RestartGame();           
        }
    }

    public void GameOver()
    {
        player.enabled = false;
        UIManager.Instance.ShowGameOverPanel();
        StartCoroutine(GameOverAnimRoutine());        
    }

    IEnumerator GameOverAnimRoutine()
    {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
        isGameOver = true;
    }

    void RestartGame()
    {
        player.enabled = true;
        isGameOver = false;
        Time.timeScale = 1f;
        player.CurrentHp = player.maxHp;
        SceneManager.LoadScene("InGameScene");        
    }
}
