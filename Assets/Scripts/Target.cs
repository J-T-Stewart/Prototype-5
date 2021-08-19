using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public ParticleSystem explosionParticle;

    private GameManager gameManager;

    private Rigidbody targetRb;

    private float minSpeed = 12.0f;
    private float maxSpeed = 16.0f;
    private float torque = 10.0f;
    private float xRange = 4.0f;
    private float ySpawnPos = -6.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(1);
            if (gameObject.CompareTag("Bad"))
            {
                gameManager.UpdateScore(-2);
                gameManager.LoseLife();
                if (gameManager.lives == 0)
                {
                    gameManager.GameOver();

                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-torque, torque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
