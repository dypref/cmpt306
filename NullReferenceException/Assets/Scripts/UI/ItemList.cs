using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemList : MonoBehaviour {
	private GameObject _itemList;

	[SerializeField] private GameObject[] LevelObjects;
	[SerializeField] private GameObject EmptySlot;

	void Start () {

		for(int i=0; i<LevelObjects.Length; i++){
			GameObject _curSlot = Instantiate (EmptySlot, gameObject.transform) as GameObject;
			GameObject _curObject = Instantiate (LevelObjects[i]) as GameObject;

			_curObject.SetActive (false);

			DragHandler dragHandler = _curSlot.AddComponent<DragHandler>();
			dragHandler.curObject = _curObject;

			_curSlot.GetComponent<Image> ().sprite = _curObject.GetComponent<SpriteRenderer> ().sprite;
			_curSlot.transform.localScale = Vector3.one;

		}
	}
}
