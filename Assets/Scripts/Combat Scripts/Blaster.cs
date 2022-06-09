using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    public GameObject rocketPrefab; //reference naar de rocket prefab
    public List<GameObject> spawnPositions; //list of spawnpositions waar de rocket gaat spawnen
    public GameObject target; //reference naar de target
    public IDamageable targetDamage;

    [SerializeField] public float rocketSpeed = 20f; //de snelheid van de raket

    public void Start()
    {
        targetDamage = target.GetComponent<IDamageable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //checkt of je de muis knop klikt
        {
            GameObject rocket = Instantiate(rocketPrefab, spawnPositions[Random.Range(0, 4)].transform.position, rocketPrefab.transform.rotation); // als het word geklikt spawned er een raket in 1 van de 5 spawn points en gaat het naar de target toe
            rocket.transform.LookAt(target.transform); // zorgt ervoor dat de raket naar de target kijkt
            StartCoroutine(SendHoming(rocket)); // homed de raket naar de target
        }
    }

    public IEnumerator SendHoming(GameObject rocket)
    {   //while loop lol
        while (Vector3.Distance(target.transform.position, rocket.transform.position) > 0.3f) //chekt de distance van de raket en de target. 
        {
            rocket.transform.position += (target.transform.position - rocket.transform.position).normalized * rocketSpeed * Time.deltaTime; //als de distance langer is dan 0.3 dan begint de raket met bewegen
            rocket.transform.LookAt(target.transform); //laat de raket naar de target kijken
            yield return null; // wacht op de volgende frame
        }

        targetDamage.TakeDamage(100);
        Destroy(rocket); // Als alles goed gaat, gaat de raket boom
    }
}
