using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed = 5;
    [SerializeField] RectTransform CanvasHUD;
    Vector2 PosF;
    float range = 2;
    private void Awake()
    {
        CanvasHUD = GameObject.Find("Canvas").GetComponent<RectTransform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        NewPos();
        
    }
    void NewPos()
    {

        Vector3[] canvasCorners = new Vector3[4];
        CanvasHUD.GetWorldCorners(canvasCorners);


        float halfWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        float halfHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;

        PosF = new Vector2(Random.Range(canvasCorners[0].x + halfWidth, canvasCorners[2].x - halfWidth), Random.Range(canvasCorners[0].y + halfHeight, canvasCorners[1].y - halfHeight));
     //   Debug.Log(PosF);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, PosF, Speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, PosF) < range)
        {
            NewPos();

        }

    }
}
