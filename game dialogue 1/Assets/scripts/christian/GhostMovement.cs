using UnityEngine;

public class GhostMovement : MonoBehaviour
{

    public Vector2 startPoint;
    public Vector2 endPoint;
    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        float pingPongValue = Mathf.PingPong(Time.time * speed, 1f);
        transform.position = Vector2.Lerp(startPoint, endPoint, pingPongValue);
        
    }
}
