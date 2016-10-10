using UnityEngine;
using System.Collections;

public class WaterTransparency : MonoBehaviour {

	// Use this for initialization
	void Start () {

        // Color transparent = GetComponent<SpriteRenderer>().color;

	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .7f);
	}
}
