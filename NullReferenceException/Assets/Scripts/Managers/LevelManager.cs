using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// the name of the theme starting with a capitalized character;
	public string theme;

	// lock and unlock
	public Sprite lockIcon;
	public Sprite unlockIcon;
	private Image icon;
	
	// star get or not
	public Sprite starGet;
	public Sprite starUnget;
	private Image firstStar;
	private Image secondStar;
	private Image thirdStar;

    // button
    private Button button;

    // automatically load level
    private Vector2 touchPos;

	// Initialize a list of levels
	public List<Level> levelList = new List<Level>();
	
	// Level number
	private Text levelInfo;

	void Awake () {
	    
        // Assume I have these data;
        for (int i = 0; i < levelList.Count; i++) {
            levelList[i].isFinished = 1;
        }
            
        levelList[0].starCount = 3;

		// Initialize data.
		foreach (Level level in levelList) {
			level.isLocked = true;	
		}
		levelList[0].isLocked = false;

	}
	
	// Hide all star slots when it is locked.
	void HideStars(int index) {
		this.firstStar = GameObject.Find("Canvas/Level" + (index + 1).ToString() + "/star1").GetComponent<Image> ();
		this.firstStar.enabled = false;
		this.secondStar = GameObject.Find("Canvas/Level" + (index + 1).ToString() + "/star2").GetComponent<Image> ();
		this.secondStar.enabled = false;
		this.thirdStar = GameObject.Find("Canvas/Level" + (index + 1).ToString() + "/star3").GetComponent<Image> ();
		this.thirdStar.enabled = false;
	}

	// Use this for initialization
	void Start () {
	
		// Draw data.
		for (int i = 0; i < levelList.Count; i++) {	
			
			levelList[i].index = i;
			
			// Get data.
			if (PlayerPrefs.HasKey("Level" + i.ToString() + "isFinished")) {
				levelList[i].isFinished = PlayerPrefs.GetInt("Level" + (i + 1).ToString() + "isFinished");
                levelList[i].isLocked = false;
			}
			
			if (PlayerPrefs.HasKey("starOfLevel" + i.ToString())) {
				levelList[i].starCount = PlayerPrefs.GetInt("starOfLevel" + (i + 1).ToString());
			}
			
			levelInfo = GameObject.Find("Canvas/Level" + (levelList[i].index + 1).ToString() + "/LevelNumber").GetComponent<Text>();
			icon = GameObject.Find("Canvas/Level" + (levelList[i].index + 1).ToString()).GetComponent<Image> ();
			
			levelInfo.text = (levelList[i].index + 1).ToString();
			
			if (levelList [i].isFinished == 1) {

				// Unlock next level.
				if (i+1 < levelList.Count) {
					levelList [i + 1].isLocked = false;
				}

			}
			
			// Draw stars.							
			this.firstStar = GameObject.Find("Canvas/Level" + (levelList[i].index + 1).ToString() + "/star1").GetComponent<Image> ();
			this.secondStar = GameObject.Find("Canvas/Level" + (levelList[i].index + 1).ToString() + "/star2").GetComponent<Image> ();
			this.thirdStar = GameObject.Find("Canvas/Level" + (levelList[i].index + 1).ToString() + "/star3").GetComponent<Image> ();

			switch (levelList[i].starCount) {
				case 0:
					this.firstStar.sprite = this.starUnget;
					this.secondStar.sprite = this.starUnget;
					this.thirdStar.sprite = this.starUnget;
					break;
				case 1:
					this.firstStar.sprite = this.starGet;
					this.secondStar.sprite = this.starUnget;
					this.thirdStar.sprite = this.starUnget;
					break;
				case 2:
					this.firstStar.sprite = this.starGet;
					this.secondStar.sprite = this.starGet;
					this.thirdStar.sprite = this.starUnget;
					break;
				case 3:
					this.firstStar.sprite = this.starGet;
					this.secondStar.sprite = this.starGet;
					this.thirdStar.sprite = this.starGet;
					break;
				default:
					this.firstStar.sprite = this.starUnget;
					this.secondStar.sprite = this.starUnget;
					this.thirdStar.sprite = this.starUnget;					
					break;
			}

            button = GameObject.Find("Canvas/Level" + (levelList[i].index + 1).ToString()).GetComponent<Button>();

			// Draw lock or unlock, also adjust text alignment.
			if (levelList[i].isLocked) {
				icon.sprite = this.lockIcon;
				this.HideStars(levelList[i].index);
                button.interactable = false;
				
			} else {
				this.levelInfo.alignment = TextAnchor.UpperCenter;
				icon.sprite = this.unlockIcon;
                button.interactable = true;
				
			}

		}
	
	}

    void Update() {

        touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int convertToSceneName = 0;

        if (theme.Equals("City")) {
            convertToSceneName += 10;
        }
        else if (theme.Equals("Space")) {
            convertToSceneName += 20;
        }

        for (int i = 0; i < levelList.Count; i++) {
            if (!levelList[i].isLocked && levelList[i].level.bounds.Contains(touchPos)) {
                Debug.Log("hello " + touchPos.ToString());
                SceneManager.LoadScene("Level " + (i + 1 + convertToSceneName).ToString());
            }
        }
    }

}
