using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class RandomWaitCT : ConditionTask 
	{

		public float minEndTime = 5;
		public float maxEndTime = 12;

		public float timer;
		public float endTime;

		//Called whenever the condition gets enabled.
		protected override void OnEnable() 
		{
			timer = 0;
			endTime = Random.Range(minEndTime, maxEndTime);
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() 
		{
			timer += Time.deltaTime;
			if (timer >= endTime)
				return true;
			return false;
		}
	}
}