using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class BlockadeMove : ActionTask 
	{
		public BBParameter<float> moveSpeedBBP;
		public BBParameter<Vector3> initialPosBBP;
        public BBParameter<float> stoppingDistance;
        public float endpointOffset;
		
		Vector3 endPos;

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
        protected override void OnExecute() 
		{
            endPos = initialPosBBP.value;
            endPos.x += endpointOffset;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() 
		{
			agent.transform.position = Vector3.MoveTowards(agent.transform.position, endPos, moveSpeedBBP.value * Time.deltaTime);
			if (Vector3.Distance(agent.transform.position, endPos) < stoppingDistance.value)
			{
				EndAction(true);
			}

        }

		//Called when the task is disabled.
		protected override void OnStop() 
		{
			moveSpeedBBP.value = Random.Range(1, 6);
		}
	}
}