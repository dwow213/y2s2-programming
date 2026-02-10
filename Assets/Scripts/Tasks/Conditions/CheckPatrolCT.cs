using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class CheckPatrolCT : ConditionTask 
	{
		public BBParameter<int> lapsAmountBB;
		public BBParameter<int> lapsDoneBB;

		public BBParameter<GameObject> playerBB;
		public BBParameter<GameObject> forestAreasBB;
		public BBParameter<int> selectedAreaBB;

		public float timer;
		public float endTimer;
		
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit()
		{
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() 
		{
			timer = 0;
			endTimer = Random.Range(1, 10);
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() 
		{
			GameObject areaPlayerIsIn = playerBB.value.GetComponent<PlayerPlace>().currentArea;

			if (areaPlayerIsIn != null)
			{
				if (areaPlayerIsIn.name == forestAreasBB.value.transform.GetChild(selectedAreaBB.value).name)
				{
					return true;
				}
			}
	
			if (lapsDoneBB.value < lapsAmountBB.value)
				return false;

            timer += Time.deltaTime;

			if (timer < endTimer)
				return false;

            return true;
		}
	}
}