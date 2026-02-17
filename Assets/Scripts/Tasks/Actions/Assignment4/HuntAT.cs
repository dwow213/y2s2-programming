using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class HuntAT : ActionTask 
	{
        public BBParameter<AudioSource> flappingBBP;
        public BBParameter<GameObject> targetAnimalBBP;

        NavMeshAgent aiAgent;
        public Vector3[] circlePositions;
        int currentCirclePos;
        public float radiusFromPos;

        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            aiAgent = agent.GetComponent<NavMeshAgent>();

            //get circle position of new area
            UpdateCirclePositions();
        }

        protected override void OnUpdate()
        {
            //constantly update circle positions if allowed. typically for moving targets
            UpdateCirclePositions();

            if (!flappingBBP.value.isPlaying)
            {
                flappingBBP.value.Play();
                Debug.Log("flapping sound played");
            }

            aiAgent.SetDestination(circlePositions[currentCirclePos]);

            Debug.Log(aiAgent.remainingDistance);

            if (aiAgent.remainingDistance < 0.5f)
            {
                currentCirclePos++;

                if (currentCirclePos >= circlePositions.Length)
                {
                    currentCirclePos = 0;
                }

            }

        }

        //gets new position for circling
        void UpdateCirclePositions()
        {
            circlePositions = new Vector3[360];
            Vector3 targetAnimalPos = targetAnimalBBP.value.transform.position;

            for (int i = 0; i < circlePositions.Length; i++)
            {
                float angle = i * Mathf.Deg2Rad;
                circlePositions[i] = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radiusFromPos + targetAnimalPos;
            }
        }
    }
}