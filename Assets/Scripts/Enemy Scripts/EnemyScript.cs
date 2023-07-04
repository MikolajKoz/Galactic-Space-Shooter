using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour, IEnemy
{
    public float speed = 3f;
	public float attackTimer = 1000f;
	public int health = 50;
	public int damage = 20;
	private float currentAtackTimer;
	private bool canAttack;
	private float startAttackDelay = 0.5f;
	private bool canStartAttack;

	public int Damage {  get => damage; set => damage = value; }

	public GameObject enemyBullet;

	[SerializeField]
	private Transform attackPoint;

	[SerializeField]
	private PlayerController player;

	[SerializeField]
	private GameObject explosionPrefab;

	PlayerLives playerLives;

	// Start is called before the first frame update
	void Start()
    {
		playerLives = PlayerLives.instance;
		currentAtackTimer = attackTimer;
	}

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
		Shoot();
    }

	public void MoveEnemy()
	{
		Vector3 temp = transform.position;
		temp.y -= speed * Time.deltaTime;
		transform.position = temp;
	}

	public void Shoot()
	{
		attackTimer += Time.deltaTime;
		if (attackTimer > startAttackDelay)
		{
			canStartAttack = true;
		}
		if (attackTimer > currentAtackTimer && canStartAttack)
		{
			canAttack = true;
		}
		if (canAttack)
		{
			canAttack = false;
			attackTimer = 0f;
			Instantiate(enemyBullet, attackPoint.position, enemyBullet.transform.rotation);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Boundary")
		{
			playerLives.TakeDamage();
			Destroy(gameObject);
		}
		if (collision.gameObject.tag == "Player Bullet")
		{
			health -= player.damage;
			Destroy(collision.gameObject);
			if (health <= 0)
			{
				Score.score += 10;
				Score.money += 10;
				GameObject cloneExplosionPrefab = Instantiate(explosionPrefab, collision.gameObject.transform.position, Quaternion.identity);
				Destroy(collision.gameObject);
				Destroy(gameObject);
				Destroy(cloneExplosionPrefab, 0.5f);
			}
		}
	}
}
