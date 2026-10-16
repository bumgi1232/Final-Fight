using UnityEngine;

public class OneWayCamera : MonoBehaviour
{
    public Transform player;
    float maxCameraX;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(player != null)
        {
            maxCameraX = transform.position.x;
        }
    }

    private void LateUpdate()
    {
        if (player == null) return;

        if(player.position.x > maxCameraX)
        {
            maxCameraX = player.position.x;
        }

        float targetX = Mathf.Max(transform.position.x, maxCameraX);

        if(player.position.x > maxCameraX)
        {
            targetX = player.position.x;
        }
        else
        {
            targetX = maxCameraX;
        }

        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
    }
}
