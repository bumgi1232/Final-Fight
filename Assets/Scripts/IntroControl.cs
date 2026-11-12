using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Unity.AppUI.UI;
using NUnit.Framework.Constraints;

public class IntroControl : MonoBehaviour
{
    public SpriteRenderer SelectBar;
    public CanvasGroup canvasGroup;

    private void Start()
    {
        BlinkSelectBar();
    }

    private void Update()
    {
        
    }

    void BlinkSelectBar()
    {
        StartCoroutine(BlinkRoutine());
    }

    IEnumerator BlinkRoutine()
    {
        while (true)
        {
            SetAlpha(0.0f);
            yield return new WaitForSeconds(0.3f);
            SetAlpha(1.0f);
            yield return new WaitForSeconds(0.3f);
        }
    }
    public IEnumerator BlinkPanelRoutine()
    {
            canvasGroup.alpha = 1f;
            yield return new WaitForSeconds(0.01f);
            canvasGroup.alpha = 0f;
            yield return new WaitForSeconds(0.05f);        
    }

    void SetAlpha(float alpha)
    {
        Color color = SelectBar.color;
        color.a = alpha;
        SelectBar.color = color;
    }
}
