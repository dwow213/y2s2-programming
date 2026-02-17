using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject animalPrefab;
    public GameObject animalsHolder;
    GameObject forestAreas;
    public float timer;
    public float spawnTime = 5;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        forestAreas = GameObject.Find("Forests");
        animalsHolder = GameObject.Find("Animals");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            timer = 0;
            
            //randomize spawn location
            Vector3 spawnLocation = forestAreas.transform.GetChild(Random.Range(0, 4)).transform.position;
            spawnLocation.x += Random.Range(-10, 10);
            spawnLocation.z += Random.Range(-10, 10);
            
            //spawn the animal
            GameObject animal = Instantiate(animalPrefab);
            animal.transform.position = spawnLocation;
            animal.transform.parent = animalsHolder.transform;
            
        }
    }
}
