using UnityEngine;
using System.Collections;

public static class DataManager {

	public static void LoadData(string theme, int level, int isFinished, int star) {
	
	}
	
	// isFinished: 1 for next level is unlocked
	// star: the number of coins you get
	public static void SaveData(string theme, int level, int isFinished, int star) {
		
		PlayerPrefs.SetInt(theme + "Level" + level.ToString() + "isFinished", isFinished);
		
		// no star statics then update data
		if (!PlayerPrefs.HasKey("starOf" + theme + "Level" + level.ToString()) ||
			PlayerPrefs.GetInt("starOf" + theme + "Level" + level.ToString()) < star) {
				
			PlayerPrefs.SetInt("starOf" + theme + "Level" + level.ToString(), star);
		}
		
	}
 
}
