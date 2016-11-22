using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class LevelSelectManager : MonoBehaviour {

	public List<Level> levelList = new List<Level>();

	public Sprite zeroStar;
	public Sprite oneStar;
	public Sprite twoStar;
	public Sprite threeStar;

	void Awake () {
		
		for (int i=0; i < levelList.Count; i++) {

			levelList[i].index = i;


			if (levelList [i].isFinished) {
				// Draw stars.

				// Unlock next level.
				if (i+1 < levelList.Count) {
					levelList [i + 1].isLocked = false;
				}

			}

			if (!levelList [i].isLocked) {
				
			} else {


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
