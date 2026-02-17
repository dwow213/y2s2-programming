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
		
		protected override string OnInit() 
		{
			return null;
		}

		protected override void OnExecute() 
		{
            aiAgent = agent.GetComponent<NavMeshAgent>();
			eagleAttackSoundBBP.value.Play();
			
			//disconnect ai agent from mesh temporarily
			//this is because making the eagle move towards target uses transform
			aiAgent.updatePosition = false;
            aiAgent.updateRotation = false;
        }

		protected override void OnUpdate() 
		{
			//make the eagle look and move towards target
			agent.gameObject.transform.position = Vector3.MoveTowards(agent.gameObject.transform.position, targetAnimalBBP.value.transform.position, moveSpeed * Time.deltaTime);
			agent.gameObject.transform.LookAt(targetAnimalBBP.value.transform);

			Vector3 distance = targetAnimalBBP.value.transform.position - agent.gameObject.transform.position;
			if (distance.magnitude < hitDistance)
			{
				EndAction();
			}
		}
		protected override void OnStop() 
		{
            //reconnect ai agent to mesh
			aiAgent.updatePosition = true;
            aiAgent.updateRotation = true;
        }
	}
}