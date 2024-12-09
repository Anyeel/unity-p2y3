using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject originalEnemy;
    [SerializeField] GameObject strongEnemy;
    private int randomNumber;
    [SerializeField] Transform[] spawnPoints; // array
    [SerializeField] Quaternion rotation = Quaternion.identity;
    private int spawnPointIndex;


    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        GameEvents.CollectibleEarned.AddListener(Spawn);
        GameEvents.PlayerHurt.AddListener(Spawn);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Spawn()
    {
        randomNumber = Random.Range(1, 3);
        if (randomNumber == 1)
        {
            SpawnEnemy(originalEnemy);
        }
        else if (randomNumber == 2)
        {
            SpawnEnemy(strongEnemy);
        }
    }
    void SpawnEnemy(GameObject whichEnemy)
    {
        spawnPointIndex = Random.Range(0, spawnPoints.Length);
        GameObject.Instantiate(whichEnemy, spawnPoints[spawnPointIndex].position, rotation);
    }
}
