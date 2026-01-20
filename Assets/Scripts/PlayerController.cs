using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
            velocity += Vector3.left;

        if (Input.GetKey(KeyCode.RightArrow))
            velocity += Vector3.right;

        if (Input.GetKey(KeyCode.UpArrow))
            velocity += Vector3.forward;

        if (Input.GetKey(KeyCode.DownArrow))
            velocity += Vector3.back;

        print(velocity);
        transform.position += velocity * moveSpeed * Time.deltaTime;
        constrainPosition();
    }

    void constrainPosition()
    {
        Vector3 newPos = transform.position;

        if (transform.position.x < -8)
            newPos.x = -8;
        if (transform.position.x > 8)
            newPos.x = 8;

        if (transform.position.z < -4)
            newPos.z = -4;
        if (transform.position.z > 4)
            newPos.z = 4;

        transform.position = newPos;
    }
}
