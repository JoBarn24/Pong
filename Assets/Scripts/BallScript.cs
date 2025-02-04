using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = new Vector3(speed,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.linearVelocity.magnitude < speed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * speed;
        } 
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            float paddleHeight = 4f;
            float factor = (transform.position.z - other.transform.position.z) / (paddleHeight/2);

            Vector3 paddle = other.contacts[0].normal;
            Vector3 newDirection = Vector3.Reflect(rb.linearVelocity, paddle);

            newDirection.z += factor * speed;
            
            float currentSpeed = rb.linearVelocity.magnitude;
            float newSpeed = rb.linearVelocity.magnitude;
            
            rb.linearVelocity = newDirection.normalized * newSpeed * 1.2f;
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            Vector3 wall = Vector3.right;
            Vector3 newDirection = Vector3.Reflect(rb.linearVelocity, wall);
            
            float currentSpeed = rb.linearVelocity.magnitude;
            float newSpeed = rb.linearVelocity.magnitude;
            
            rb.linearVelocity = newDirection.normalized * newSpeed;
        }
    }
}

