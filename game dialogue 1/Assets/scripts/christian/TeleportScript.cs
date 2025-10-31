using UnityEngine;



public class TeleportScript : MonoBehaviour
{
public Transform destination;
    
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        

        if(trigger.CompareTag("Player")){
            //Transform playerTransform = playerObject.transform;
            trigger.transform.position = destination.position;
            Debug.Log("ok");
        }
        
    }
}
