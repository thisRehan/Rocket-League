using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Car"))
        {
            Vector3 forceDirection = transform.position - other.transform.position;
            rb.GetComponent<Rigidbody>().AddForce(forceDirection * 2, ForceMode.Impulse);
        }
    }
}
