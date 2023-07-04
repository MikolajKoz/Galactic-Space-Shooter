using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /*[SerializeField]
    private GameObject defaultEnemy;*/
    [SerializeField]
    private DefaultEnemyFactory defaultEnemyFactory;

    [SerializeField]
    private HeavyEnemyFactory heavyEnemyFactory;

    [SerializeField]
    private float defaultEnemyInterval = 3.5f;

    [SerializeField]
    private float heavyEnemyInterval = 7f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy(defaultEnemyInterval, defaultEnemyFactory));
        StartCoroutine(SpawnEnemy(heavyEnemyInterval, heavyEnemyFactory));
    }

    private IEnumerator SpawnEnemy(float interval, EnemyFactory factory)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            factory.CreateEnemy(new Vector3(Random.Range(-8f, 8f), 5.3f, 0));

        }
        /*yield return new WaitForSeconds(interval);*/
        /*GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-8f, 8f), 5.5f, 0), enemy.transform.rotation);
        StartCoroutine(spawnEnemy(interval, enemy));*/

    }
}
