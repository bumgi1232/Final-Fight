using Unity.Cinemachine;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public CinemachineCamera[] stageCameras;

    public int currentStage;

    private void Start()
    {
        ChangeStage(0);
    }

    public void ChangeStage(int index)
    {
        if (index < 0 || index >= stageCameras.Length)
            return;

        currentStage = index;

        for (int i = 0; i < stageCameras.Length; i++)
        {
            stageCameras[i].Priority = 10;
        }

        stageCameras[index].Priority = 20;
    }
}
