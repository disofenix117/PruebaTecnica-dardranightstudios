using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraPos : MonoBehaviour
{
    [SerializeField] Camera Cam;
    Vector2 MouseTarget;
    // Start is called before the first frame update
    void Awake()
    {
        Cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        

        transform.position = (Vector2)Cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
