using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	[SerializeField] private Transform Chumpy;
    private GameObject CameraMax, CameraMin;
    float width, height;

	void Start(){
		Chumpy = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
        CameraMin = GameObject.Find("CameraMin");
        CameraMax = GameObject.Find("CameraMax");
        height = 2 * Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
	}

	void FixedUpdate () {
		transform.position = new Vector3 (
            Mathf.Clamp(Chumpy.position.x, CameraMin.transform.position.x + (width / 2f), CameraMax.transform.position.x - (width / 2f)),
            Mathf.Clamp(Chumpy.position.y, CameraMin.transform.position.y + (height / 2f), CameraMax.transform.position.y - (height / 2f)),
			transform.position.z);


        

        
	}
}