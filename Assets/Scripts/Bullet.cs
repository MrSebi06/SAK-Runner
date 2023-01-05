using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime;
    public Rigidbody rb;
    
    private float initializationTime;
    
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
