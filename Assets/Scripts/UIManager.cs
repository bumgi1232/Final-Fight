using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI 컴포넌트 연결")]
    public GameObject gameOverPanel;
    public GameObject gameClearPanel;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI insertCoin;

    public int countdownSeconds = 10;

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
    }

    public void ShowGameOverPanel()
    {
        if(gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            StartCoroutine(CountdownRoutine());
        }
    }
    public void HideGameOverPanel()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }


    public void ShowGameClearPanel()
    {
        if (gameClearPanel != null)
        {
            gameClearPanel.SetActive(true);
        }
    }

    public IEnumerator CountdownRoutine()
    {
        int count = countdownSeconds;
        while (count > 0)
        {
            if (countdownText != null)
            {
                countdownText.text = count.ToString();
            }

            yield return new WaitForSecondsRealtime(1f);

            count--;
        }

        countdownText.text = "0";
    }

}
