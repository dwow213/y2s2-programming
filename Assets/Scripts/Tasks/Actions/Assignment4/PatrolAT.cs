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

		protected override void OnExecute() 
		{
            aiAgent = agent.GetComponent<NavMeshAgent>();

			//get circle position of new area
            UpdateCirclePositions();
		}

		protected override void OnUpdate() 
		{
			
			//plays flapping sound constantly
			if (!flappingBBP.value.isPlaying)
			{
                flappingBBP.value.Play();
				Debug.Log("flapping sound played");
            }

			//make eagle move according to the circle positions
			aiAgent.SetDestination(circlePositions[currentCirclePos]);

			//go to the next position in the circle if we are close enough
            if (aiAgent.remainingDistance < 0.5f)
            {
				currentCirclePos++;

				//if a full revolution is complete, increase the amound of laps
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