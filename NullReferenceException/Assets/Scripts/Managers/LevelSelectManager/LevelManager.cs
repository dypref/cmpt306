using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	// Icons for lock and unlock
	[SerializeField]
	public Sprite lockIcon;
	[SerializeField] 
	public Sprite unlockIcon;
	
	
	public List<Level> levelList = new List<Level>();
	private Text levelInfo;
	// Use text until icon works
	private Text lockInfo;
	private Image icon;
	


	void Awake () {
		
		// Assume I have these data
		PlayerPrefs.SetInt("starOfLevel0", 1);
		Debug.Log(PlayerPrefs.HasKey("starOfLevel0"));
		
		// Initialize data.
		foreach (Level level in levelList) {
			level.isLocked = true;	
		}
		levelList[0].isLocked = false;
		
		// Draw data.
		for (int i = 0; i < levelList.Count; i++) {	
			
			levelList[i].index = i;
			
			if (PlayerPrefs.HasKey("Level" + i.ToString() + "isFinished")) {
				levelList[i].isFinished = PlayerPrefs.GetInt("Level" + i.ToString() + "isFinished");
			}
			
			if (PlayerPrefs.HasKey("starOfLevel" + i.ToString())) {
				levelList[i].starCount = PlayerPrefs.GetInt("starOfLevel" + i.ToString());
				Debug.Log(PlayerPrefs.GetInt("starOfLevel" + i.ToString()));
			}
			
			levelInfo = GameObject.Find("Canvas/Level" + (levelList[i].index + 1).ToString() + "/LevelNumber").GetComponent<Text>();
			lockInfo = GameObject.Find("Canvas/Level" + (levelList[i].index + 1).ToString() + "/IsLocked").GetComponent<Text>();
			icon = GameObject.Find("Canvas/Level" + (levelList[i].index + 1).ToString()).GetComponent<Image> ();
			
			levelInfo.text = (levelList[i].index + 1).ToString();
			// levelInfo.text = levelList[i].isLocked.ToString();
			if (levelList [i].isFinished == 1) {
				
				//testText += levelList[i].starCount.ToString() + levelList[i].isLocked.ToString();
				
				// Draw stars.
				switch (levelList[i].starCount) {
					case 0:
						
						break;
					case 1:
						
						break;
					case 2:
						
						break;
					case 3:
						
						break;
					default:
						break;
				}

				// Unlock next level.
				if (i+1 < levelList.Count) {
					levelList [i + 1].isLocked = false;
				}
				Debug.Log("Can I be here?");

			}

			
			if (levelList[i].isLocked) {
				lockInfo.text = "Locked";
			} else {
				lockInfo.text = levelList[i].starCount.ToString();
			}
		}
		

		
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
//		if (Input.GetMouseButtonUp (0)) {
//			for (int i = 0; i < levelList.Count; i++) {
//				if (!levelList [i].isLocked) {
//					Application.LoadLevel (levelList [i].index);
//				}
//			}
//		}

	}

}
