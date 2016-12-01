using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// The number of coins Chumpy gets
	static public int CoinCount;
	// The text that shows the number of the coins
	private Text CoinText;
    private Text levelText;
	
	// Stars
	private Image leftStar;
	private Image middleStar;
	private Image rightStar;
	
	// For right navigation
    public string sceneName;
    public string theme;
    public string currentLevel;
    public string nextLevel;

	// Everything about the result of current level
	private GameObject result;

	void Awake() {
		result = GameObject.Find("Canvas/Result");
		levelText = GameObject.Find("Canvas/Current Level").GetComponent<Text>();
		CoinText = GameObject.Find ("Canvas/Coins").GetComponent<Text> ();
	}
	
	// Use this for initialization
	void Start () {
		result.SetActive(false);
        levelText.text = theme + " - " + currentLevel;
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
			// other.enabled = false;
			GetResult();

//            // Save data
//            DataManager.SaveData(sceneName, 1, CoinCount);
		}
			
	}
	
	// Fetch result when Chumpy died or passed the level
	public void GetResult() {
		
		// Show result
		result.SetActive(true);
		
		// Save data
		DataManager.SaveData(sceneName, 1, CoinCount);
		Debug.Log(sceneName);
		Debug.Log(CoinCount);
		Debug.Log(PlayerPrefs.GetInt("starOfLevel 21"));
		
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
				
	}
	
	public void goCurrentLevel() {
		SceneManager.LoadScene(this.sceneName.ToString());
	}

    public void goNextLevel() {
        SceneManager.LoadScene(this.nextLevel.ToString());
    }

    public void goSelectionMenu() {
        SceneManager.LoadScene(this.theme.ToString());
    }


}
