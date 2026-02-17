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

        protected override string OnInit() 
		{
			return null;
		}

		protected override void OnExecute() 
		{
			
			//get the next forest area eagle should move to
			selectedAreaBBP.value++;

			if (selectedAreaBBP.value >= forestAreasBBP.value.transform.childCount)
			{
				selectedAreaBBP.value = 0;
			}

		}

		protected override void OnUpdate()
		{
           //plays a quick flapping sound
			if (!quickFlappingBBP.value.isPlaying)
            {
                quickFlappingBBP.value.Play();
                Debug.Log("quick flapping sound played");
            }

			//move to the next forest area
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
	}
}