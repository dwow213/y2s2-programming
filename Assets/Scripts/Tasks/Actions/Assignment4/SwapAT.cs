using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class SwapAT : ActionTask 
	{
        public BBParameter<AudioSource> quickFlappingBBP;
		public BBParameter<int> selectedAreaBBP;
		public BBParameter<GameObject> forestAreasBBP;

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
			
			selectedAreaBBP.value++;

			if (selectedAreaBBP.value >= forestAreasBBP.value.transform.childCount)
			{
				selectedAreaBBP.value = 0;
			}

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
            if (!quickFlappingBBP.value.isPlaying)
            {
                quickFlappingBBP.value.Play();
                Debug.Log("quick flapping sound played");
            }

            Vector3 agentPos = agent.gameObject.transform.position;
			Vector3 forestAreaPos = forestAreasBBP.value.transform.GetChild(selectedAreaBBP.value).position;
			NavMeshAgent aiAgent = agent.GetComponent<NavMeshAgent>();

            Vector3 newPos = new Vector3(
				forestAreaPos.x,
				agentPos.y,
				forestAreaPos.z
			);

			aiAgent.SetDestination(newPos);
			Debug.Log(aiAgent.velocity.magnitude);

			if (aiAgent.velocity.magnitude < 0.1f)
			{
				EndAction();
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() 
		{
			
		}

		//Called when the task is paused.
		protected override void OnPause() 
		{
			
		}
	}
}