using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions {

	public class CompareScore : ConditionTask 
	{
		public BBParameter<int> scoreA; //score A should be the score of the agent
		int scoreB; //score B should be the score of the other agent, specified by targetBB
        public int offsetScoreB;
        public Blackboard targetBB;

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			
			scoreB = targetBB.GetVariableValue<int>("score");

			if (scoreA.value > scoreB + offsetScoreB)
				return true;
			else
				return false;

            
		}
	}
}