using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AnimalInitAT : ActionTask 
	{

		GameObject audioSources;
		public BBParameter<AudioSource> eatingSoundBBP;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() 
		{
            audioSources = GameObject.Find("AudioSources");
            eatingSoundBBP.value = audioSources.transform.Find("Eating").GetComponent<AudioSource>();
			return null;
		}
	}
}