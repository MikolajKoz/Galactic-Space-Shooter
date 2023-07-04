using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    public int Damage { get; set; }
    public void MoveEnemy();
    public void Shoot();
}
