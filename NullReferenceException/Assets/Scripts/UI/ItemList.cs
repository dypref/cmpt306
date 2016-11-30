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

			//curObject.SetActive (false);
			//curObject.GetComponent<Rigidbody2D>().

			//curSlot.GetComponent<Image> ().sprite = curSlot.GetComponent<SpriteRenderer> ().sprite;

			curSlot.transform.localScale = Vector3.one;
			curObject.transform.parent = null;
			curObject.transform.localScale = Vector3.one;
			curObject.transform.SetParent (curSlot.transform);
			curObject.transform.localPosition = Vector3.zero;

		}
	}
}
