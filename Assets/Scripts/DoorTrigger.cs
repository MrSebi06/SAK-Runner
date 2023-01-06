using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Rigidbody>())
        {
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
            if (door.isOpen)
            {
                door.Close();
            }
        }
    }
}
