using NUnit.Framework.Constraints;
using System.Collections;
using Unity.AppUI.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SceneManagement;

public class InGameLoad : MonoBehaviour
{
    [SerializeField] private CanvasGroup fadeCanvasGroup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
        InputSystem.onAnyButtonPress.CallOnce(ctrl =>
        {
            //Debug.Log($"눌린 버튼{ctrl.name}");
            StartCoroutine(FadeRoutine());
        });*/
    }

    IEnumerator FadeRoutine()
    {        
        fadeCanvasGroup.alpha = 1f;

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("InGameScene");
    }
}
