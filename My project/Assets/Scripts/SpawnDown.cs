using UnityEngine;

public class SpawnDown : MonoBehaviour  
{
    //enscaptulation
   [SerializeField] private GameObject dog;
    private int delay = 1;
    private int spawnRate = 6;

    private void Start()
    {
        InvokeRepeating("SpawnDog",delay,spawnRate);
    }

    void SpawnDog()
    {
        Vector3 pos = new Vector3(Random.Range(-25, 25), 0, -20);
        Instantiate(dog,pos,dog.transform.rotation); 
    }
}