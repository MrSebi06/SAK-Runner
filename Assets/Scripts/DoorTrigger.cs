using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Rigidbody>())
        {
            Debug.Log("Open !");
            if (!door.isOpen)
            {
                door.Open();
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<Rigidbody>())
        {
            Debug.Log("Close !");
            if (door.isOpen)
            {
                door.Close();
            }
        }
    }
}
