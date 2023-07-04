using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{

    public static PlayerLives instance;

    public int maxLives;
    public int lives;

    public event Action DamageTaken;
    public event Action LivesUpgraded;

	private bool isDead;

	public GameManager gameManager;
	public GameObject explosionPrefab;

    [SerializeField] private PlayerController playerController;

	public int Lives { get { return lives; } } 

    // Start is called before the first frame update
    void Start()
    {
        lives = maxLives;
    }

	private void Awake()
	{
		if (instance == null)
		{
            instance = this;
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }

    public void TakeDamage()
    {
        lives -= 1;
        if (DamageTaken != null)
        {
            DamageTaken();
        }
        if (lives <= 0 && !isDead)
        {
            isDead = true;
			Time.timeScale = 0;
            playerController = GetComponent<PlayerController>();
            GameObject cloneExplosionPrefab = Instantiate(explosionPrefab, playerController.transform.position, Quaternion.identity);
			Destroy(playerController.gameObject);
			Destroy(cloneExplosionPrefab, 0.5f);

			gameManager.GameOver();
        }
    }

    public void UpgardeLives(int lives)
    {
        maxLives += lives;
        if (LivesUpgraded != null)
        {
            LivesUpgraded();
        }
    }
}
