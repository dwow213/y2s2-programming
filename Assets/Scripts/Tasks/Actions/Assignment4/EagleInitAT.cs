using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class EagleInitAT : ActionTask 
	{

		GameObject audioSources;
		public BBParameter<AudioSource> flapping;
		public BBParameter<AudioSource> quickFlapping;
		public BBParameter<GameObject> forestAreas;
		public BBParameter<GameObject> player;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() 
		{
			audioSources = GameObject.Find("AudioSources");
			flapping.value = audioSources.transform.Find("Flapping").GetComponent<AudioSource>();
            quickFlapping.value = audioSources.transform.Find("QuickFlapping").GetComponent<AudioSource>();

			player.value = GameObject.Find("Player");
			forestAreas.value = GameObject.Find("ForestsSky");

			return null;
        }
	}
}