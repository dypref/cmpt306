using UnityEngine;
using System.Collections;

public static class DataManager {

	// isFinished: 1 for next level is unlocked
	// star: the number of coins you get
	public static void SaveData(int level, int isFinished, int star) {
		
		PlayerPrefs.SetInt("Level" + level.ToString() + "isFinished", isFinished);
		
		// no star statics then update data
		if (!PlayerPrefs.HasKey("starOfLevel" + level.ToString()) ||
			PlayerPrefs.GetInt("starOfLevel" + level.ToString()) < star) {
				
			PlayerPrefs.SetInt("starOfLevel" + level.ToString(), star);
		
		}
		
	}

}
