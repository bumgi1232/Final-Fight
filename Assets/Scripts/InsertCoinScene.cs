using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InsertCoinScene : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI insertCoin;

    private void Start()
    {
        StartCoroutine(blinkTextRoutine());
    }

    private void Update()
    {
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("Select");
        }
    }

    IEnumerator blinkTextRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            insertCoin.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            insertCoin.gameObject.SetActive(true);
        }        
    }
}
