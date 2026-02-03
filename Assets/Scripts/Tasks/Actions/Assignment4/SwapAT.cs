using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SwapAT : ActionTask 
	{

        public BBParameter<AudioSource> quickFlapping;
		public BBParameter<int> selectedArea;
		public BBParameter<GameObject> forestAreas;

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
			quickFlapping.value.Play();
			Debug.Log("quick flapping sound played");
			selectedArea.value++;

			if (selectedArea.value >= forestAreas.value.transform.childCount)
			{
				selectedArea.value = 0;
			}

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			Vector3 agentPos = agent.gameObject.transform.position;
			Vector3 forestAreaPos = forestAreas.value.transform.GetChild(selectedArea.value).position;

			Vector3 newPos = new Vector3(
				forestAreaPos.x,
				agentPos.y,
				forestAreaPos.z
			);

			agent.gameObject.transform.position = newPos;
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