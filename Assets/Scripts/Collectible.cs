using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Collectible : MonoBehaviour
{
    public int score;
    private Vector3 randomSpawn;
    [SerializeField] float minimumDistance = 2f;
    // Start is called before the first frame update
    void Start()
    {
        RandomizeSpawn();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void RandomizeSpawn()
    {
        Vector3 newSpawn = new Vector3();
        newSpawn.x = Random.Range(-9f, 9f);
        newSpawn.y = Random.Range(-4.5f, 4.5f);

        while (Vector3.Distance(transform.position, newSpawn) < minimumDistance)
        {
            newSpawn.x = Random.Range(-9f, 9f);
            newSpawn.y = Random.Range(-4.5f, 4.5f);
        }

        randomSpawn = newSpawn;
        transform.position = randomSpawn;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player")) 
        {
            GameEvents.CollectibleEarned.Invoke();
            score++;
            RandomizeSpawn();
        }
    }
}
