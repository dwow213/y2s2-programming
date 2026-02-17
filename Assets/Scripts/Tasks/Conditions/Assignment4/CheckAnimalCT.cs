using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class CheckAnimalCT : ConditionTask 
	{

		public BBParameter<GameObject> animalsBBP;
		public float huntRadius;
		public BBParameter<GameObject> targetAnimalBBP;


		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit()
		{
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() 
		{
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() 
		{
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() 
		{
			//gets the animals every frame
			//might be expensive i know
			List<GameObject> animalsList = GetAnimals();

			//check if an animal is within radius of the eagle
			foreach (GameObject animal in animalsList)
			{
				//get animal's position and set its y-coord to be equal to eagle
				//that way the magnitude won't factor in the y-coord
				Vector3 animalPos = animal.transform.position;
				animalPos.y = agent.transform.position.y;

				//get the distance between animal and agent
				Vector3 distance = animalPos - agent.transform.position;
				
				//eagle starts hunting this animal if within radius
				if (distance.magnitude < huntRadius)
				{
					targetAnimalBBP.value = animal;
					return true;
				}
			}
			
			return false;
		}

		List<GameObject> GetAnimals()
		{
			List<GameObject> animalsList = new List<GameObject>();

			for (int i = 0; i < animalsBBP.value.transform.childCount; i++)
			{
				animalsList.Add(animalsBBP.value.transform.GetChild(i).gameObject);
			}

			return animalsList;
		}
	}
}