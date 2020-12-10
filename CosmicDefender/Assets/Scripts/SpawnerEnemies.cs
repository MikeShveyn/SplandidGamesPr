using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemies : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfig;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
              yield return StartCoroutine(SpawnAllWaves());

        } while (looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        for(int waveCount = startingWave; waveCount < waveConfig.Count; waveCount++)
        {
            var currentWave = waveConfig[waveCount];
            yield return StartCoroutine(SpawnAllEnemiesInWawe(currentWave));
        }
    }
        
    private IEnumerator SpawnAllEnemiesInWawe(WaveConfig waveConfig)
    {
        for(int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies();enemyCount++)
        {
           var newEnemy = Instantiate(
           waveConfig.GetEnemyPrefab(),
           waveConfig.GetWayPoints()[0].transform.position,
           Quaternion.identity);

            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

           yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
       
    }

}
