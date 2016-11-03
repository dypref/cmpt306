using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static GameObject item;
    public Transform itemListBox;
    Vector3 startPosition;
    Transform startParent;
    bool isUI;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    #region IBeginDragHandler implementation

    public void OnBeginDrag(PointerEventData eventData)
    {

        item = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }


    #endregion

    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData)
    {

        transform.position = Input.mousePosition;
    }


    #endregion

    #region IEndDragHandler implementation

    public void OnEndDrag(PointerEventData eventData)
    {

        item = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        //if (transform.parent != startParent){
            transform.position = startPosition;
        //}
    }


    #endregion


}
