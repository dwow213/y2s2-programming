using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class InitializeCollision : ActionTask 
	{
		public BBParameter<List<Transform>> blockadesBBP;
		public string blockadeName;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() 
		{
            for (int i = 0; i < blockadesBBP.value.Count; i++)
            {
                blockadesBBP.value[i] = GameObject.Find(blockadeName + (i + 1)).GetComponent<Transform>();
            }

            foreach (Transform t in blockadesBBP.value)
            {
                if (t == null)
                    return $"InitCollisions in {agent.name}: Unable to find all reference!";
            }

            return null;
		}
	}
}