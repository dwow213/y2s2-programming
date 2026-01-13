using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class CheckScaleCT : ConditionTask {

        public GameObject selfGameObject;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			selfGameObject = agent.gameObject;
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			if (selfGameObject.transform.localScale.x <= 0.25f)
			{
				selfGameObject.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
				return true;
			}
			else 
				return false;
		}
	}
}