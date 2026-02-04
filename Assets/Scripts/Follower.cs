using NodeCanvas.Framework;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Blackboard blackboard;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Friendly"))
        {
            blackboard.SetVariableValue("seekTarget", other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Friendly"))
        {
            blackboard.SetVariableValue("seekTarget", null);
        }
    }
}
