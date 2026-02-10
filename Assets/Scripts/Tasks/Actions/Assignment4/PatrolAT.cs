using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class PatrolAT : ActionTask 
	{
		public BBParameter<AudioSource> flapping;
        public BBParameter<int> selectedArea;
        public BBParameter<GameObject> forestAreas;

		public Vector3[] circlePositions;
		int currentCirclePos;
		public float radiusFromPos;

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
			circlePositions = new Vector3[360];
            Vector3 forestAreaPos = forestAreas.value.transform.GetChild(selectedArea.value).position;

            for (int i = 0; i < circlePositions.Length; i++)
			{
				float angle = i * Mathf.Deg2Rad;
				circlePositions[i] = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radiusFromPos + forestAreaPos;
			}
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() 
		{
            NavMeshAgent aiAgent = agent.GetComponent<NavMeshAgent>();

            if (!flapping.value.isPlaying)
			{
                flapping.value.Play();
				Debug.Log("flapping sound played");
            }

			aiAgent.SetDestination(circlePositions[currentCirclePos]);

            if (aiAgent.velocity.magnitude < 0.01f)
            {
				currentCirclePos++;

				if (currentCirclePos >= circlePositions.Length)
					currentCirclePos = 0;
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