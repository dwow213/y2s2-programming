using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions {

	public class ModulusCheck : ConditionTask 
	{

		public BBParameter<int> turtleScore;
		public int modulusNum;

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() 
		{
			if (turtleScore.value % modulusNum == 0 && turtleScore.value != 0)
				return true;

			return false;
		}
	}
}