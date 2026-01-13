using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UI;


namespace NodeCanvas.Tasks.Actions {

	public class Eat : ActionTask {

		public Texture[] textureArray;
		public RawImage barUI;
		public int barStatus;
        float timer;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			timer = 0;
			barStatus = 5;
			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			timer += Time.deltaTime;
			barUI.texture = textureArray[barStatus];

            if (barStatus <= 0)
                EndAction(true);

            if (timer < 3)
				return;

			timer = 0;
			barStatus -= 1;
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}