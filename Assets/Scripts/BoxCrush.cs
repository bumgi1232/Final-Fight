using UnityEngine;

public class BoxCrush : MonoBehaviour
{
    public GameObject prefab;
    public GameObject box;

    public void CrushBox()
    {
        box.SetActive(false);
        Vector3 CherryPos = new Vector3(transform.position.x, transform.localPosition.y -1, transform.position.z);
        Instantiate(prefab, CherryPos, Quaternion.identity);
    }
}
