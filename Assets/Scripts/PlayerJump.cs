using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public Transform visualSprite;
    public GameObject kickCollider;

    public float jumpForce = 8f;
    public float gravity = -15f;

    float jumpHeight = 0f;
    float jumpVelocity = 0f;
    bool isJumping = false;

    Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (isJumping && !GameManager.Instance.isGameOver)
        {
            jumpVelocity += gravity * Time.deltaTime;
            jumpHeight += jumpVelocity * Time.deltaTime;

            if (jumpHeight <= 0f)
            {
                jumpHeight = 0f;
                isJumping = false;
                jumpVelocity = 0f;

                kickCollider.SetActive(false);
                anim.SetBool("isJumping", false);
            }

            if (visualSprite != null)
            {
                visualSprite.localPosition = new Vector3(0f, jumpHeight, 0f);
            }
        }
    }

    void OnJump()
    {
        if(!isJumping && !GameManager.Instance.isGameOver)
        {
            isJumping = true;
            jumpVelocity = jumpForce;
            kickCollider.SetActive(true);

            anim.SetBool("isJumping", true);
        }
    }

    public void RestartJump()
    {
        if (!isJumping)
        {
            isJumping = true;
            jumpVelocity = jumpForce;
            kickCollider.SetActive(true);

            anim.SetBool("isJumping", true);
        }
    }

}
