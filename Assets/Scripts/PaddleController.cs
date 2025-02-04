using UnityEngine;

public class PaddleController : MonoBehaviour
{
    
    public float speed = 0f;
    public KeyCode upKey;
    public KeyCode downKey;

    private Rigidbody rb;
    private float upperBoundary = 12.99f;
    private float lowerBoundary = -12.99f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        //if upKey is pressed and within upper boundary
        if (Input.GetKey(upKey) && position.z < upperBoundary)
        {
            position.z = position.z + (speed * Time.deltaTime);
        }
        
        //if downKey is pressed and within lower boundary
        if (Input.GetKey(downKey) && position.z > lowerBoundary)
        {
            position.z = position.z - (speed * Time.deltaTime);
        }
        
        transform.position = position;
    }
}
