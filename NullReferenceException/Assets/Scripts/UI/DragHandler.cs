using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{
    public static GameObject item;
	public GameObject curObject {get; set;}
	private Rigidbody2D rb;
	private bool kinematicDefault;
	public bool debug = false;

    //private Vector3 startPosition;
    //private Transform startParent;
    private bool isUI;

	public void Start(){

		rb = gameObject.GetComponent<Rigidbody2D> ();
		if (rb != null) {
			kinematicDefault = rb.isKinematic;
			rb.isKinematic = true;
			gameObject.transform.localPosition = Vector3.zero;
		}
		Debug.Log ("Test 1");
	}

    public void OnBeginDrag(PointerEventData eventData){
		Debug.Log ("Test 2");
        item = gameObject;
        //startPosition = transform.position;
        //startParent = transform.parent;
        //GetComponent<CanvasGroup>().blocksRaycasts = false;
		debug = true;
    }

    public void OnDrag(PointerEventData eventData){
		transform.position = 
			Camera.main.ScreenToWorldPoint(
				new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10));
    }

    public void OnEndDrag(PointerEventData eventData){
        item = null;	

		curObject.transform.parent = null;
		curObject.SetActive (true);

		Vector3 newPosition = 
			Camera.main.ScreenToWorldPoint(
				new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10));

		curObject.transform.position = newPosition;

		rb.isKinematic = kinematicDefault;

        //if (transform.parent != startParent){
            //transform.position = startPosition;
        //}
    }
}
