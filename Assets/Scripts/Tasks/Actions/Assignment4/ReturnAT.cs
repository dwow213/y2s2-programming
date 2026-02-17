using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class ReturnAT : ActionTask 
	{

        public BBParameter<AudioSource> flappingBBP;
        public BBParameter<GameObject> targetAnimalBBP;

		NavMeshAgent aiAgent;

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute()
        {
			targetAnimalBBP.value = null;
			aiAgent = agent.GetComponent<NavMeshAgent>();
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() 
		{
            if (!flappingBBP.value.isPlaying)
            {
                flappingBBP.value.Play();
                Debug.Log("flapping sound played");
            }

			Vector3 newPos = new Vector3(0, agent.transform.position.y, 0);
            aiAgent.SetDestination(newPos);

            if (aiAgent.velocity.magnitude < 0.1f)
            {
                EndAction();
            }
        }
	}
}