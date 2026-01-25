using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;


namespace NodeCanvas.Tasks.Actions {

	public class InitializeRacers : ActionTask 
	{
        public BBParameter<List<Transform>> destinationsBBP;
        public BBParameter<int> moveSpeedBBP;
        public BBParameter<float> stoppingDistance;
        public BBParameter<GameObject> targetRacer;

        public int initialMoveSpeed;
        public string destinationName;
        public string targetRacerName;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() 
        {
            for (int i = 0; i < destinationsBBP.value.Count; i++)
            {
                destinationsBBP.value[i] = GameObject.Find(destinationName + (i + 1)).GetComponent<Transform>();
            }
            moveSpeedBBP.value = initialMoveSpeed;
            stoppingDistance.value = 0.1f;
            targetRacer = GameObject.Find(targetRacerName);

            foreach (Transform t in destinationsBBP.value)
            {
                if (t == null)
                    return $"InitRacers in {agent.name}: Unable to find all reference!";
            }

            return null;
		}
	}
}