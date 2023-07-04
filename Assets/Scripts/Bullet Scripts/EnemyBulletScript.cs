using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
	public float speed = 5f;
	public int damage = 20;

    // Update is called once per frame
    void Update()
    {
		Move();
    }
	void Move()
	{
		Vector3 temp = transform.position;
		temp.y -= speed * Time.deltaTime;
		transform.position = temp;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Boundary")
		{
			Destroy(gameObject);
		}
		if (collision.gameObject.tag == "Player")
		{
			PlayerController.currentHealth -= damage;
			Destroy(gameObject);
		}
	}
}
