using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyFactory : MonoBehaviour
{
    public abstract IEnemy CreateEnemy(Vector3 position);
}
