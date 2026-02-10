using UnityEngine;

public class PlayerPlace : MonoBehaviour
{
    public GameObject currentArea;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentArea = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        currentArea = other.gameObject;
    }
}
