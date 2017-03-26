using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
	public float startingSpeed;

	private float currentSpeed;

    void Start()
    {
        StartCoroutine (SpawnWaves());
		currentSpeed = startingSpeed;
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds (startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
				//spawn new enemy
                Vector3 spawnPosition = new Vector3(transform.position.x + Random.Range(-spawnValues.x, spawnValues.x),
					transform.position.y + Random.Range(-spawnValues.y, spawnValues.y), transform.position.z);
                Quaternion spawnRotation = Quaternion.identity;
                GameObject enemy = Instantiate(hazard, spawnPosition, spawnRotation);

				//set the new enemy's speed
				enemy.GetComponent<Rigidbody>().velocity = transform.forward * -currentSpeed;
				yield return new WaitForSeconds(spawnWait);
            }

			//make the next wave more difficult
			hazardCount += 2;
			spawnWait *= 0.9f;
			currentSpeed += 0.2f*startingSpeed;

            yield return new WaitForSeconds (waveWait);
        }
    }
}
