using UnityEngine;
using System.Collections;

public class BuildingTransparency : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D building)
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    void OnTriggerExit2D(Collider2D building)
    {
        GetComponent<SpriteRenderer>().enabled = true;
    }
}
