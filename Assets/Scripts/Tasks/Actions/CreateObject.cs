using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {
	
	public class CreateObject : ActionTask {

		public GameObject prefab;
		float timer;
		
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			timer = 0;
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			timer = 0f;
			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			timer += Time.deltaTime;

			if (timer < 1)
				return;

			timer = 0;
			GameObject tempObject = GameObject.Find(prefab.name + "(Clone)");
			Vector3 spawnPos;

            if (tempObject == null)
            {
				spawnPos = new Vector3(0, 0, -1.41f);
            }
			else
			{
                spawnPos = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-6f, -1f));
            }

            GameObject createdObj = GameObject.Instantiate(prefab, spawnPos, Quaternion.identity);
			createdObj.transform.parent = GameObject.Find("HidingObjects").transform;

        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}