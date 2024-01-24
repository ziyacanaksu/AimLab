using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile: MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    private Rigidbody bulletRigidbody;
    // Start is called before the first frame update
    private void Awake(){
        bulletRigidbody = GetComponent<Rigidbody>();
    }
    private void Start(){
        float speed = 10f;
        bulletRigidbody.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<TargetObstacle>()){
            Debug.Log("target çarptı");
            Destroy(gameObject);

        }
        else
        {
        Instantiate(particle,transform.position,Quaternion.identity);
        Destroy(gameObject);

        }

        
    }
}
