using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


namespace NodeCanvas.Tasks.Actions {

	public class Walk : ActionTask 
	{

		public BBParameter<int> score;
		public BBParameter<int> currentPoint;
		public BBParameter<List<Transform>> destinations;
		public int setSpeed;
		public BBParameter<float> moveSpeed;
        public BBParameter<float> stoppingDistance;

        protected override void OnExecute() 
		{
			moveSpeed.value = setSpeed;
			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() 
		{
            //set destination to the next point
            Transform destination = destinations.value[0];
			if (currentPoint.value != 3)
			{
                destination = destinations.value[currentPoint.value + 1];
            }

			//move agent to the destination
			agent.transform.position = Vector3.MoveTowards(agent.transform.position, destination.position, moveSpeed.value * Time.deltaTime);

			//change destinations once we're within a certain distance of our current destination
			if (Vector3.Distance(agent.transform.position, destination.position) < stoppingDistance.value)
			{
				agent.transform.position = destination.position;
				currentPoint.value += 1;

				//if we're back on starting point, increase the score
				if (currentPoint.value > 3)
				{
					score.value += 1;
					currentPoint.value = 0;
				}
					
			}
		}
	}
}