using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShottingEnemy : MonoBehaviour
{
    [SerializeField] float Speed=20;
    [SerializeField] HUD hud;
    Rigidbody2D LazerRB;
    private void Awake()
    {
        LazerRB = GetComponent<Rigidbody2D>();
        hud=FindObjectOfType<HUD>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ShotProyectil(Vector2 Dir)
    {
        LazerRB.velocity = Dir*Speed;
        Destroy(gameObject, 2.5f);
    }

    private void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            hud.dead();
            Debug.Log("muerto");
        }
        if(Other.gameObject.CompareTag("Proyectil"))
        {
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
