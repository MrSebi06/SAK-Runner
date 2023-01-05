using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public Transform player;
    public Rigidbody bullet;
    public float bulletRate;

    private LayerMask ignored;
    private bool _playerVisible;

    void Start()
    {
        InvokeRepeating("SpawnBullet", 1.0f, bulletRate);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation((player.position - transform.position).normalized);
    }

    void SpawnBullet()
    {
        Rigidbody bulletInstance;
        
        bulletInstance = Instantiate(bullet, transform.position + transform.forward, transform.rotation);
        bulletInstance.AddForce(transform.forward * 2, ForceMode.VelocityChange);
    }
}
