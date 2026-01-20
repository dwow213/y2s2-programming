using UnityEngine;

public class SetCamera : MonoBehaviour
{
    public Transform cameraHolder;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = cameraHolder.position;
        transform.forward = -cameraHolder.up;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
