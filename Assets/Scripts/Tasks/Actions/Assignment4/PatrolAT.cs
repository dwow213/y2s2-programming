using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class PatrolAT : ActionTask 
	{
		public BBParameter<AudioSource> flappingBBP;
        public BBParameter<int> selectedAreaBBP;
        public BBParameter<GameObject> forestAreasBBP;
		public BBParameter<int> lapsAmountBBP;
		public BBParameter<int> lapsDoneBBP;

		NavMeshAgent aiAgent;
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
            aiAgent = agent.GetComponent<NavMeshAgent>();

			//get circle position of new area
            UpdateCirclePositions();
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() 
		{
			
			if (!flappingBBP.value.isPlaying)
			{
                flappingBBP.value.Play();
				Debug.Log("flapping sound played");
            }

			aiAgent.SetDestination(circlePositions[currentCirclePos]);
			
            Debug.Log(aiAgent.remainingDistance);

            if (aiAgent.remainingDistance < 0.5f)
            {
				currentCirclePos++;

				if (currentCirclePos >= circlePositions.Length)
				{
                    currentCirclePos = 0;
					lapsDoneBBP.value++;
                }
					
            }

        }
		
		//gets new position for circling
		void UpdateCirclePositions()
		{
            circlePositions = new Vector3[360];
            Vector3 forestAreaPos = forestAreasBBP.value.transform.GetChild(selectedAreaBBP.value).position;

            for (int i = 0; i < circlePositions.Length; i++)
            {
                float angle = i * Mathf.Deg2Rad;
                circlePositions[i] = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radiusFromPos + forestAreaPos;
            }

            lapsAmountBBP.value = Random.Range(1, 4);
            lapsDoneBBP.value = 0;
        }
	}
}