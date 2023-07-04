using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemyFactory : EnemyFactory
{
	[SerializeField]
	private EnemyScript enemyPrefab;

	public override IEnemy CreateEnemy(Vector3 position)
	{
		GameObject instance = Instantiate(enemyPrefab.gameObject, position, enemyPrefab.transform.rotation);
		EnemyScript newEnemy = instance.GetComponent<EnemyScript>();

		return newEnemy;
	}
}
