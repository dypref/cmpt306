using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{

    public float movementSpeed;
    public Transform startPos;
    public Transform endPos;

    private Vector3 start;
    private Vector3 end;
    private Vector3 tempPosition;




    // Use this for initialization
    void Start()
    {

        start = startPos.localPosition;
        end = endPos.localPosition;
        tempPosition = end;

    }

    // Update is called once per frame
    void Update()
    {

        movePlatform();
    }

    void movePlatform()
    {
        startPos.localPosition = Vector3.MoveTowards(startPos.localPosition, tempPosition, movementSpeed * Time.deltaTime);

        if (Vector3.Distance(startPos.localPosition, tempPosition) <= 0.1)
        {
            returnPos();
        }
    }

    void returnPos()
    {
        if (tempPosition != start)
        {
            tempPosition = start;
        }
        else
        {
            tempPosition = end;
            transform.position = startPos.position;
        }
    }
}
