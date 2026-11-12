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
    public Transform SelectBar;
    IntroControl introControl;

    private int bar = 1;


    private void Awake()
    {
        introControl = GetComponent<IntroControl>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Update()
    {
        MoveSelectBar();
    }

    IEnumerator FadeRoutine()
    {        
        fadeCanvasGroup.alpha = 1f;

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("InGameScene");
    }

    void OnMove(InputValue value)
    {
        float inputDir = value.Get<float>();

        if (inputDir < 0)
        {
            if (bar > 0)
            {
                bar--;
            }
            else
            {
                bar = 2;
            }
        }
        else if (inputDir > 0)
        {
            if (bar < 2)
            {
                bar++;
            }
            else
            {
                bar = 0;
            }
        }
    }
    
    void MoveSelectBar()
    {
        switch (bar)
        {
            case 0:
                SelectBar.position = new Vector3(-5.08f, -0.11f, 0f);
                break;
            case 1:
                SelectBar.position = new Vector3(-0.01f, -0.11f, 0f);
                break;
            case 2:
                SelectBar.position = new Vector3(5f, -0.11f, 0f);
                break;
        }
    }

    void OnSelect()
    {
        if (bar == 1)
        {
            StartCoroutine(FadeRoutine());
        }       
        else
        {
            StartCoroutine(introControl.BlinkPanelRoutine());
        }
    }
}
