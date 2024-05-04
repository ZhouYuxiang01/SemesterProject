using UnityEngine;
using UnityEngine.UI;

public class NotificationTrigger : MonoBehaviour
{
    public GameObject notificationUI; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            notificationUI.SetActive(true); 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            notificationUI.SetActive(false); 
        }
    }
}