using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IntroControl : MonoBehaviour
{
    public SpriteRenderer SelectBar;
    Color color;

    private void Start()
    {
        color = SelectBar.color;

    }

    private void Update()
    {
        BlinkSelectBar();
    }

    void BlinkSelectBar()
    {
        StartCoroutine(BlinkRoutine());
    }

    IEnumerator BlinkRoutine()
    {
        yield return new WaitForSeconds(1f);
        color.a = 0.5f;
        yield return new WaitForSeconds(1f);
        print("alpha value change");
        color.a = 1f;
    }
}
