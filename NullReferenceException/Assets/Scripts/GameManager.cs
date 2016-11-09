using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// The number of coins Chumpy gets
	static public int CoinCount;
	// The text that shows the number of the coins
	private Text CoinText;

	// Use this for initialization
	void Start () {
		CoinText = GameObject.Find ("Canvas/Coins").GetComponent<Text> ();
		CoinCount = 0;
	}
	
	// Update is called once per frame
	void Update () {

		// Display the coins Chumpy gets so far
		CoinText.text = "Coins: " + CoinCount;

	}

	// Exit the game, for the exit button on the main menu
	public void doExitGame() {
		Application.Quit();
	}
}
