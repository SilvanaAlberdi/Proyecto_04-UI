using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float timeDestroy = 1f;
    private GameManager gameManagerScript;

    [SerializeField] private int points;
    public ParticleSystem explosionParticle;

    void Start()
    {
        Destroy(gameObject, timeDestroy);

        gameManagerScript = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {
        if (!gameManagerScript.gameOver)
        {
            gameManagerScript.UpdateScore(points);
        }
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

        if (gameObject.CompareTag("Good"))
        {
            Destroy(gameObject);
        }else if (gameObject.CompareTag("Bad"))
        {
            Destroy(gameObject);
            gameManagerScript.missCounter += 1;

            if (gameManagerScript.missCounter >= gameManagerScript.totalMisses)
            {
                gameManagerScript.GameOver();
            }
        }

        
    }

    private void OnDestroy()
    {
        gameManagerScript.targetPositions.Remove(transform.position);
    }
}
