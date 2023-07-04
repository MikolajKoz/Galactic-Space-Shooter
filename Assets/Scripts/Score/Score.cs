using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
	public TextMeshProUGUI moneyText;
	public static int money;
    public static float score;
    public float speedOfTimer;
	private void Start()
	{
		money = 0;
		score = 0f;
		speedOfTimer = 10f;
	}
	// Update is called once per frame
	void Update()
    {
		scoreText.text = "Score: " + (int)score;
		score += speedOfTimer * Time.deltaTime;
		moneyText.text = "$$$: " + money;
    }
}
