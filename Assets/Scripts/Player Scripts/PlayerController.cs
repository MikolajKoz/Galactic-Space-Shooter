using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float max_x, min_x;
    public int maxHealth = 100;
	public float attack_Timer = 0.35f;
    public int damage = 50;
	public static int currentHealth;
    private bool isDead;
	private float current_Attack_timer;
	private bool canAttack;

	public GameManager gameManager;

    public HealthBar healthBar;

	public GameObject explosionPrefab;

	[SerializeField]
    private GameObject player_Bullet;

    [SerializeField]
    private Transform attack_Point;

	PlayerLives playerLives;

    // Start is called before the first frame update
    void Start()
    {
        playerLives = PlayerLives.instance;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        current_Attack_timer = attack_Timer;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Attack();
    }

    void MovePlayer()
    {
        if(Input.GetAxisRaw("Horizontal") > 0f)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;

            if (temp.x > max_x)
                temp.x = max_x;

            transform.position = temp;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;

			if (temp.x < min_x)
				temp.x = min_x;

			transform.position = temp;
        }
    }

    void Attack()
    {
        attack_Timer += Time.deltaTime;
        if (attack_Timer > current_Attack_timer)
        {
            canAttack = true;
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if(canAttack)
            {
                canAttack = false;
                attack_Timer = 0f;
                Instantiate(player_Bullet, attack_Point.position, Quaternion.identity);
            }
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy Bullet")
        {
            healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0 && !isDead)
            {
				GameObject cloneExplosionPrefab = Instantiate(explosionPrefab, collision.gameObject.transform.position, Quaternion.identity);
				Destroy(collision.gameObject);
				Destroy(gameObject);
				Destroy(cloneExplosionPrefab, 0.5f);
                isDead = true;
                Time.timeScale = 0;
                gameManager.GameOver();
			}

		}
		if (collision.gameObject.tag == "Enemy")
		{
			GameObject cloneExplosionPrefab = Instantiate(explosionPrefab, collision.gameObject.transform.position, Quaternion.identity);
			Destroy(collision.gameObject);
			Destroy(cloneExplosionPrefab, 0.5f);
			playerLives.TakeDamage();
			
		}
	}
}
