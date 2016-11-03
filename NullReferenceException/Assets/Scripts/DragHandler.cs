using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{
    public static GameObject item;
	public GameObject curObject {get; set;}

    Vector3 startPosition;
    Transform startParent;
    bool isUI;

    public void OnBeginDrag(PointerEventData eventData){
        item = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        //GetComponent<CanvasGroup>().blocksRaycasts = false;
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

        //if (transform.parent != startParent){
            //transform.position = startPosition;
        //}
    }
}
