using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    public GameObject[] targetPrefabs;
    public Vector3 randomSpawnPos;
    public List<Vector3> targetPositions;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    private float minX = -3.75f;
    private float minY = -3.75f;
    private float spaceBetweenSquares = 2.5f;
    private int numberRows = 4;
    private float spawnRate= 0.5f;
    private int score;
    public int missCounter;
    public int totalMisses = 3;

    private void Start()
    {
        StartCoroutine("SpawnRandomTarget");
        score = 0;
        UpdateScore(0);
        missCounter = 0;
        gameOverText.gameObject.SetActive(false);
    }

    private void Update()
    {
        scoreText.text = $"Score: {score}";
    }

    public Vector3 RandomSpawnPosition()
    {
        int RandomIntX = Random.Range(0, numberRows);
        int RandomIntY = Random.Range(0, numberRows);
        float randomPosX = minX + RandomIntX * spaceBetweenSquares;
        float randomPosY = minY + RandomIntY * spaceBetweenSquares;

        return new Vector3(randomPosX, randomPosY, 0);
    }

    private IEnumerator SpawnRandomTarget()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(spawnRate);

            int randomIndex = Random.Range(0, targetPrefabs.Length);
            randomSpawnPos = RandomSpawnPosition();

            while (targetPositions.Contains(randomSpawnPos))
            {
                randomSpawnPos = RandomSpawnPosition();
            }

            Instantiate(targetPrefabs[randomIndex], randomSpawnPos, targetPrefabs[randomIndex].transform.rotation);
            targetPositions.Add(randomSpawnPos);
        }
        
    }

    public void UpdateScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = $"Score: {score}";
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.gameObject.SetActive(true);
    }
}
