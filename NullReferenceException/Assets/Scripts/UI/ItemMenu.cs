using UnityEngine;
using System.Collections;

public class ItemMenu : MonoBehaviour
{

    private bool isDown = false;
    private bool isMoving = false;
    private float leftToMove;
    private float steps;
    public RectTransform relative;
    private float animationTime = 30;
    private float xScale;

    void FixedUpdate(){
        if (isMoving){
			if (isDown){
                transform.Translate(Vector3.down * steps, relative);
            } else{
                transform.Translate(Vector3.up * steps, relative);
            }
            
			leftToMove -= steps;
            
			if (leftToMove <= 0){
                isMoving = !isMoving;
            }
        }
    }

    public void HideAndShow(){
        if (!isMoving){
            isMoving = true;
            isDown = !isDown;
            leftToMove = relative.transform.localScale.y * ((RectTransform)transform).rect.height;
            steps = leftToMove / animationTime;
        }
    }
}
