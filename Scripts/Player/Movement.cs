using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float vel = 5.0f;
    [SerializeField] RectTransform CanvasHUD;
    float Hor, Ver;


    void Update()
    {
        movement();
    }
    void movement()
    {
        Hor = Input.GetAxis("Horizontal"); 
        Ver = Input.GetAxis("Vertical"); 
        
        Vector2 Mov = new Vector2(Hor, Ver) * vel * Time.deltaTime;
        Vector2 NewPos = (Vector2)transform.position + Mov;
        Vector3[] canvasCorners = new Vector3[4];
        CanvasHUD.GetWorldCorners(canvasCorners);


        float halfWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        float halfHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;

        NewPos.x = Mathf.Clamp(NewPos.x, canvasCorners[0].x + halfWidth, canvasCorners[2].x - halfWidth);
        NewPos.y = Mathf.Clamp(NewPos.y, canvasCorners[0].y + halfHeight, canvasCorners[1].y - halfHeight);

        transform.position = NewPos;

    }
}
