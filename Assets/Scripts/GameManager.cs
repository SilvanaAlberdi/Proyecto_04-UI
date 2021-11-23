using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    public GameObject[] targetPrefabs;
    public Vector3 randomSpawnPos;

    private float minX = -3.75f;
    private float minY = -3.75f;
    private float spaceBetweenSquares = 2.5f;
    private int numberRows = 4;
    private float spawnRate= 2f;

    private void Start()
    {
        StartCoroutine("SpawnRandomTarget");
    }

    public Vector3 RandomSpawnPosition()
    {
        int RandomInt = Random.Range(0, 4);
        float randomPosX = minX + RandomInt * spaceBetweenSquares;
        float randomPosY = minY + RandomInt * spaceBetweenSquares;

        return new Vector3(randomPosX, randomPosY, 0);
    }

    private IEnumerator SpawnRandomTarget()
    {
        yield return new WaitForSeconds(spawnRate);

        int randomIndex = Random.Range(0, targetPrefabs.Length);
        randomSpawnPos = RandomSpawnPosition();
        Instantiate(targetPrefabs[randomIndex], randomSpawnPos, targetPrefabs[randomIndex].transform.rotation);
    }
}
