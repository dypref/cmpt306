using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// The number of coins Chumpy gets
	static public int CoinCount;
	// The text that shows the number of the coins
	private Text CoinText;
	
	// stars
	private Image leftStar;
	private Image middleStar;
	private Image rightStar;
	
	// the name of the theme starting with a capitalized character;
	public string theme;

	// Everything about the result of current level
	private GameObject result;

	void Awake() {
		// Hide result first
		result = GameObject.Find("Canvas/Result");
		result.SetActive(false);
	}
	
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
	
	// Show result
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			other.enabled = false;
			this.GetResult();
		}
			
	}
	
	// Fetch result when Chumpy died or passed the level
	public void GetResult() {
		
		// Show result
		this.result.SetActive(true);
		
		// Stars part
		this.leftStar = GameObject.Find("Canvas/Result/starLeft").GetComponent<Image> ();
		this.middleStar = GameObject.Find("Canvas/Result/starMiddle").GetComponent<Image> ();
		this.rightStar = GameObject.Find("Canvas/Result/starRight").GetComponent<Image> ();

		switch (CoinCount) {
			
			case 0:
				this.leftStar.enabled = false;
				this.middleStar.enabled = false;
				this.rightStar.enabled = false;
				break;
			
			case 1:
				this.leftStar.enabled = false;
				this.rightStar.enabled = false;
				break;
			
			case 2:
				this.middleStar.enabled = false;
				break;
			
			case 3:
				break;
				
			default:
				this.leftStar.enabled = false;
				this.middleStar.enabled = false;
				this.rightStar.enabled = false;				
				break;
				
		}
		
		// Buttons part
		
		
		
	}

}
