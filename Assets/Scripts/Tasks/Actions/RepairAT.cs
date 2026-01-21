using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class RepairAT : ActionTask 
	{
		public BBParameter<Transform> lightTowerTargetBBP;
		public BBParameter<float> scanRadiusBBP;
		public BBParameter<float> initialRadiusBBP;

		public float repairRate = 25f;
		public float fullyRepairedThreshold = 100f;

		private Blackboard lightTowerBB;
		private float repairValue;

		protected override void OnExecute()
		{
			lightTowerBB = lightTowerTargetBBP.value.GetComponentInParent<Blackboard>();
			repairValue = lightTowerBB.GetVariableValue<float>("repairValue");

			lightTowerTargetBBP.value = null;
			scanRadiusBBP.value = initialRadiusBBP.value;
		}

        protected override void OnUpdate()
        {
			repairValue += repairRate * Time.deltaTime;
			lightTowerBB.SetVariableValue("repairValue", repairValue);

			if (repairValue > fullyRepairedThreshold)
			{
				EndAction(true);
			}
        }
	}
}