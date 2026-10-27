using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Score = 0;
    public bool isGameOver = false;
    public Player player;
    public GameObject gameOverUi;

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

    public void GameOver()
    {
        player.enabled = false;
        gameOverUi.SetActive(true);
    }
}
