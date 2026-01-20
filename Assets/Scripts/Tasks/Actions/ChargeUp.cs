using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ChargeUp : ActionTask 
    {

        public BBParameter<int> currentPoint;
        public BBParameter<List<Transform>> destinations;
        public BBParameter<float> moveSpeed;
        public BBParameter<float> stoppingDistance;

        protected override void OnExecute()
        {
            moveSpeed.value = 5;

            //make the player go back to the previous point
            currentPoint.value -= 1;
            if (currentPoint.value < 0)
                currentPoint = 3;

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

            //simply stop the agent if they are on their target
            if (Vector3.Distance(agent.transform.position, destination.position) < stoppingDistance.value)
            {
                agent.transform.position = destination.position;

            }
        }
    }
}