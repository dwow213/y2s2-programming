using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class InitLightTowerAT : ActionTask 
	{
		public BBParameter<Light> lightBBP;
		public BBParameter<Transform> workpadBBP;

		public string workPadName = "Work Pad";
		
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() 
		{
			lightBBP.value = agent.GetComponentInChildren<Light>();
			workpadBBP.value = agent.transform.Find(workPadName);

			if (lightBBP.value != null) return null;
			else return $"InitLightTowerAT in {agent.name}: Unable to find all reference!";
		}
	}
}