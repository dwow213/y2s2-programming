using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class SeekTask : ActionTask 
	{
		public BBParameter<Vector3> targetPositionBBP;
		public BBParameter<Transform> seekTargetBBP;

		public float seekRadius = 4f;

		//Called once per frame while the action is active.
		protected override void OnUpdate() 
		{
			if (seekTargetBBP.value == null)
				EndAction();
			else
			{
				float distance = Vector3.Distance(agent.transform.position, seekTargetBBP.value.position);
				if (distance < seekRadius)
				{
					targetPositionBBP.value = seekTargetBBP.value.position;
				}
			}
		}
	}
}