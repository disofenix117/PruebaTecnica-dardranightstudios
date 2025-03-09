using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotting : MonoBehaviour
{
    [SerializeField] float Speed=20;
    [SerializeField] AudioSource Track;
    [SerializeField] AudioClip clip;

    Rigidbody2D LazerRB;
    HUD hud;
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
        if(Other.gameObject.CompareTag("Enemy")|| Other.gameObject.CompareTag("Proyectil"))
        {
            Destroy(gameObject);
            hud.AddScore(10);
            Destroy(Other.gameObject);

        }
       
    }
    
}
