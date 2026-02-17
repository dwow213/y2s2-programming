using UnityEngine;

public class AnimalCollision : MonoBehaviour
{
    
    //destroys the animal object if player collides with it

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("destroying the thingamajig");
            Destroy(gameObject);
        }
    }
}
