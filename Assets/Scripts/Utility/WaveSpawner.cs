using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private GameObject[] getCount;
    public Text waveCountdownText;

    private int waveIndex = 1;

    void Update()
    {
        getCount = GameObject.FindGameObjectsWithTag("Enemy");


        if(countdown <= 1f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        else
        {
            waveCountdownText.text = "Remaining: " + getCount.Length.ToString();
        }

        if(getCount.Length <= 0)
        {
            //waveCountdownText.text = "Round " + waveIndex + " in " + Mathf.Round(countdown).ToString() + "/" + Mathf.Round(timeBetweenWaves);
            waveCountdownText.text = "Wave " + waveIndex+ " in " + Mathf.Round(countdown).ToString()+" sec";
            countdown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave()
    { 
        waveIndex++;
        for (int i = 0; i < waveIndex * waveIndex; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(0.3f);
        }
        //Debug.Log("Wave " + waveIndex + " Incoming!");
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
