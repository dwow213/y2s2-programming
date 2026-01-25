using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class InitializeBlockade : ActionTask 
	{

        public BBParameter<Vector3> initialPosBBP;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() 
		{
            initialPosBBP.value = agent.transform.position;

            return null;
		}
	}
}