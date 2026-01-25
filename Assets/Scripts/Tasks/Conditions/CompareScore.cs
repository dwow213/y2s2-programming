using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class CompareScore : ConditionTask 
	{
		public BBParameter<int> BBscoreA; //score A should be the score of the agent
		public BBParameter<GameObject> targetGameObjectBB;
		int scoreB; //score B should be the score of the other agent, specified by targetBB
        public int offsetScoreB;
        Blackboard targetBB;

        protected override string OnInit()
        {
			targetBB = targetGameObjectBB.value.GetComponent<Blackboard>();
			return null;
        }

        //Called once per frame while the condition is active.
        //Return whether the condition is success or failure.
        protected override bool OnCheck() {
			
			scoreB = targetBB.GetVariableValue<int>("score");

			if (BBscoreA.value > scoreB + offsetScoreB)
				return true;
			else
				return false;

            
		}
	}
}