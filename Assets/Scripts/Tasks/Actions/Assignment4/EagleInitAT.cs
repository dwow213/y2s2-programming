using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class EagleInitAT : ActionTask 
	{

		GameObject audioSources;
		public BBParameter<AudioSource> flappingBBP;
		public BBParameter<AudioSource> quickFlappingBBP;
        public BBParameter<AudioSource> eagleAttackSoundBBP;
		public BBParameter<AudioSource> eatingSoundBBP;
        public BBParameter<GameObject> forestAreasBBP;
		public BBParameter<GameObject> playerBBP;
		public BBParameter<GameObject> animalsBBP;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() 
		{
			audioSources = GameObject.Find("AudioSources");
			flappingBBP.value = audioSources.transform.Find("Flapping").GetComponent<AudioSource>();
            quickFlappingBBP.value = audioSources.transform.Find("QuickFlapping").GetComponent<AudioSource>();
            eagleAttackSoundBBP.value = audioSources.transform.Find("EagleAttack").GetComponent<AudioSource>();
            eatingSoundBBP.value = audioSources.transform.Find("Eating").GetComponent<AudioSource>();

            playerBBP.value = GameObject.Find("Player");
			forestAreasBBP.value = GameObject.Find("ForestsSky");

			animalsBBP.value = GameObject.Find("Animals");

			return null;
        }
	}
}