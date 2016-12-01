using UnityEngine;
using System.Collections;

public class elevator : MonoBehaviour {

    public Transform teleport;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D player)
    {
        if(player.tag == "Player")
        {
            player.transform.position = teleport.position;
        }
    }
}
