using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class ReturnAT : ActionTask 
	{

        public BBParameter<AudioSource> flappingBBP;
		public BBParameter<AudioSource> eatingSoundBBP;
        public BBParameter<GameObject> targetAnimalBBP;

		NavMeshAgent aiAgent;

		protected override void OnExecute()
        {
			targetAnimalBBP.value = null;
			aiAgent = agent.GetComponent<NavMeshAgent>();

            //play an eating sound
			eatingSoundBBP.value.Play();
		}

		protected override void OnUpdate() 
		{
            //plays flapping sound constantly
            if (!flappingBBP.value.isPlaying)
            {
                flappingBBP.value.Play();
                Debug.Log("flapping sound played");
            }

            //make eagle go back to mountain and wait
			Vector3 newPos = new Vector3(0, agent.transform.position.y, 0);
            aiAgent.SetDestination(newPos);

            if (aiAgent.velocity.magnitude < 0.1f)
            {
                EndAction();
            }
        }
	}
}