using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class DragInput : MonoBehaviour {

	private bool dragging = false;
	private GameObject curObject;
	private Vector2 offset;
	private bool kinematicDefault;
	private Rigidbody2D rb;

	public void Update (){
		
		if (Input.GetMouseButton(0)) {
			
			DragOrPickUp();
		}
		else{
			
			if (dragging) {
				
				DropItem ();
			}
		}
	}


	private void DragOrPickUp() {

		var inputPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (dragging) {

			curObject.transform.position = (Vector2)inputPosition + offset;
		}
		else {
			
			RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 10f);
			if (touches.Length > 0) {
				
				var hit = touches[0];
				if (hit.transform != null && hit.transform.tag == "Block") {
					
					dragging = true;
					curObject = hit.transform.gameObject;
					offset = (Vector2)(hit.transform.position - inputPosition);
					curObject.transform.localScale = curObject.transform.localScale * 1.5f;

					rb = curObject.GetComponent<Rigidbody2D> ();
					if (rb != null) {
						kinematicDefault = rb.isKinematic;
						rb.isKinematic = true;
					}
				}
			}
		}
	}


	private void DropItem()	{
		
		dragging = false;
		if (rb != null) {
			rb.isKinematic = kinematicDefault;
		}
		curObject.transform.localScale = curObject.transform.localScale * (2f/3f);
		curObject.transform.parent = null;
	}
}
