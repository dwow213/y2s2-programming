using NodeCanvas.Framework;
using NodeCanvas.StateMachines;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ScanAT : ActionTask {
		public BBParameter<float> scanRadiusBBP;
		public BBParameter<Transform> lightTowerTargetBBP;

		public LayerMask scanLayer;
		public Color scanColour;
		public float scanDuration;
		public int numberOfScanCirclePoints;

		public float scanTimer;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() 
		{
			scanTimer = 0;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() 
		{
			scanTimer += Time.deltaTime;
			if (scanTimer > scanDuration)
			{
				Collider[] colliders = Physics.OverlapSphere(agent.transform.position, scanRadiusBBP.value, scanLayer);
				foreach (Collider collider in colliders)
				{
					DrawCircle(agent.transform.position, scanRadiusBBP.value, scanColour, numberOfScanCirclePoints, 1f);
					
					IBlackboard blackboard = collider.GetComponentInParent<FSMOwner>().graph.blackboard;
					float repairValue = blackboard.GetVariableValue<float>("repairValue");

                    if (repairValue == 0)
					{
						lightTowerTargetBBP = blackboard.GetVariableValue<Transform>("workpad");
					}
                }
				EndAction(true);
			}
		}

		private void DrawCircle(Vector3 center, float radius, Color colour, int numberOfPoints, float duration)
		{
			Vector3 startPoint, endPoint;
			int anglePerPoint = 360 / numberOfPoints;
			for (int i = 1; i <= numberOfPoints; i++)
			{
				startPoint = new Vector3(Mathf.Cos(Mathf.Deg2Rad * anglePerPoint * (i-1)), 0, Mathf.Sin(Mathf.Deg2Rad * anglePerPoint * (i-1)));
				startPoint = center + startPoint * radius;
				endPoint = new Vector3(Mathf.Cos(Mathf.Deg2Rad * anglePerPoint * i), 0, Mathf.Sin(Mathf.Deg2Rad * anglePerPoint * i));
				endPoint = center + endPoint * radius;
				Debug.DrawLine(startPoint, endPoint, colour, duration);
			}

			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}