using UnityEngine;

public class SortingLayer : MonoBehaviour
{
    SpriteRenderer sprite;

    public float yOffset = 0f;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        sprite.sortingOrder = -(int)((transform.position.y + yOffset) * 100);
    }
}
