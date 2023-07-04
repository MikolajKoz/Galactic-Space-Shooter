using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesBar : MonoBehaviour
{
    public GameObject heart;
    public List<Image> hearts;

    PlayerLives playerLives;

    // Start is called before the first frame update
    void Start()
    {
        playerLives = PlayerLives.instance;
        playerLives.DamageTaken += UpdateLives;
        playerLives.LivesUpgraded += AddLives;
        for (int i = 0; i < playerLives.maxLives; i++)
        {
            GameObject h = Instantiate(heart, this.transform);
            hearts.Add(h.GetComponent<Image>());
        }
    }

    void UpdateLives()
    {
        int heartFill = playerLives.Lives;
        //hearts.Reverse();
        foreach (Image heart in hearts)
        {
            heart.fillAmount = heartFill;
            heartFill -= 1;
        }
    }

    void AddLives()
    {
        foreach (Image heart in hearts)
        {
            Destroy(heart.gameObject);
        }
        hearts.Clear();

		for (int i = 0; i < playerLives.maxLives; i++)
		{
			GameObject h = Instantiate(heart, this.transform);
			hearts.Add(h.GetComponent<Image>());
		}
	}
}
