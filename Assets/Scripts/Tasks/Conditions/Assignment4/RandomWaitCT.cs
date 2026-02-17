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

		protected override void OnEnable() 
		{
			timer = 0;
			endTime = Random.Range(minEndTime, maxEndTime);
		}

		protected override bool OnCheck() 
		{
			timer += Time.deltaTime;
			if (timer >= endTime)
				return true;
			return false;
		}
	}
}