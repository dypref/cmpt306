using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemList : MonoBehaviour {
	private GameObject itemList;

	[SerializeField] private GameObject[] LevelObjects;
	[SerializeField] private GameObject EmptySlot;

	void Start () {

		for(int i=0; i<LevelObjects.Length; i++){
			GameObject curSlot = Instantiate (EmptySlot, gameObject.transform) as GameObject;
			GameObject curObject = Instantiate (LevelObjects[i], curSlot.transform) as GameObject;

			//normalising slot
			curSlot.transform.localScale = Vector3.one;

			//normalising object
			curObject.transform.parent = null;
			curObject.transform.localScale = Vector3.one;
			curObject.transform.SetParent (curSlot.transform);
			curObject.transform.localPosition = Vector3.zero;

			//preventing object from falling out of list
			if (curObject.transform.tag == "PhysBlock") {
				curObject.GetComponent<Rigidbody2D>().isKinematic = true;
			}
		}
	}
}
