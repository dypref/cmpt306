using UnityEngine;
using System.Collections;

[System.Serializable]
public class Level {

	// The index of current level.
	public int index;
	// Is this level locked or not?
	public bool isLocked;
	// How many coins you get?
	public int starCount;
	// Is this level finished?
	public bool isFinished;

	public SpriteRenderer level;

	void Start () {
		isLocked = true;
		starCount = 0;
		isFinished = false;
	}

}
