using UnityEngine;

public class PlayerPlace : MonoBehaviour
{
    //for detecting which area the player is in
    //this is for the eagle so they can run away from the player if they are in the same area
    
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
