using UnityEngine;
using System.Collections;

public class ItemMenu : MonoBehaviour {

    private bool isDown = false;
    private int targetHeight;
    private static int topHeight;
    private static int bottomHeight;
    public Transform relative;
    private int moveSpeed = 5;


	// Use this for initialization
	void Start () {

        topHeight = 330;
        bottomHeight = 230;
        targetHeight = topHeight;
	}
	

	void FixedUpdate () {

        if (transform.localPosition.y != targetHeight)
        {
            
            if (isDown)
            {
                transform.Translate(Vector3.down * moveSpeed, relative);
            }
            else{
                transform.Translate(Vector3.up * moveSpeed, relative);
            }
            
        }
	}

    public void HideAndShow() {

        isDown = !isDown;
        if (isDown) {

            targetHeight = bottomHeight;
        }
        else {

            targetHeight = topHeight;
        }
    }


}
