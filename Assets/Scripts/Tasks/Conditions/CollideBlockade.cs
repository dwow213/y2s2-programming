using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


namespace NodeCanvas.Tasks.Conditions {

	//collision checks based on the distance between the points rather than actual collision boxes and rigidbodies
	//just didnt feel like adding a rigidbody for this 
	public class CollideBlockade : ConditionTask 
	{
        public BBParameter<List<Transform>> blockadesBBP;
		public float stoppingDistance;

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() 
		{
			
			foreach (Transform blockade in blockadesBBP.value)
			{
                //change destinations once we're within a certain distance of our current destination
                if (Vector3.Distance(agent.transform.position, blockade.position) < stoppingDistance)
                {
					return true;
                }
            }

            return false;
		}
	}
}