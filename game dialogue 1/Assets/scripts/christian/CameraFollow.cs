using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
    public Transform player;
    void LateUpdate() 
    {
        transform.position = player.transform.position + new Vector3(0, 1, -5);
    }
}