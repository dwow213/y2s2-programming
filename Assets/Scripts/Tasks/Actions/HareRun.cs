using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class HareRun : ActionTask {

        public BBParameter<int> score;
        public BBParameter<int> currentPoint;
        public BBParameter<List<Transform>> destinations;
        public BBParameter<float> moveSpeed;
        public BBParameter<float> stoppingDistance;

        protected override void OnExecute()
        {
            moveSpeed.value = 7;
            //EndAction(true);
        }

        //Called once per frame while the action is active.
        protected override void OnUpdate()
        {
            Transform destination = destinations.value[0];
            if (currentPoint.value != 3)
            {
                destination = destinations.value[currentPoint.value + 1];
            }

            agent.transform.position = Vector3.MoveTowards(agent.transform.position, destination.position, moveSpeed.value * Time.deltaTime);

            if (Vector3.Distance(agent.transform.position, destination.position) < stoppingDistance.value)
            {
                agent.transform.position = destination.position;
                currentPoint.value += 1;

                if (currentPoint.value > 3)
                {
                    score.value += 1;
                    currentPoint.value = 0;
                }

            }
        }
    }
}