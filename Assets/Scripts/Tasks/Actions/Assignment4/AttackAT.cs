using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class AttackAT : ActionTask 
	{
		public BBParameter<GameObject> targetAnimalBBP;
		public BBParameter<AudioSource> eagleAttackSoundBBP;
		public float moveSpeed= 7f;
		public float hitDistance = 1f;

		NavMeshAgent aiAgent;
		
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() 
		{
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() 
		{
            aiAgent = agent.GetComponent<NavMeshAgent>();
			eagleAttackSoundBBP.value.Play();

			aiAgent.updatePosition = false;
            aiAgent.updateRotation = false;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() 
		{
			agent.gameObject.transform.position = Vector3.MoveTowards(agent.gameObject.transform.position, targetAnimalBBP.value.transform.position, moveSpeed * Time.deltaTime);
			agent.gameObject.transform.LookAt(targetAnimalBBP.value.transform);

			Vector3 distance = targetAnimalBBP.value.transform.position - agent.gameObject.transform.position;
			if (distance.magnitude < hitDistance)
			{
				EndAction();
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() 
		{
            aiAgent.updatePosition = true;
            aiAgent.updateRotation = true;
        }

		//Called when the task is paused.
		protected override void OnPause() 
		{
			
		}
	}
}