using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform[] spawnPoints; 

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);

            Instantiate(ballPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
        }
    }
}
