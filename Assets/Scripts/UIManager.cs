using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI 컴포넌트 연결")]
    public GameObject gameOverPanel;
    public GameObject gameClearPanel;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void ShowGameOverPanel()
    {
        if(gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void ShowGameClearPanel()
    {
        if (gameClearPanel != null)
        {
            gameClearPanel.SetActive(true);
        }
    }
}
