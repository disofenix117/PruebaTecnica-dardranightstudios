using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    [Range(1.0f, 10.0f)] public float RotSpeed = 8;
    [SerializeField] ShottingEnemy AmmoPrefab;
    [SerializeField] Transform ShotPos;
    Vector2 PlayerTarget;
    bool isAlive, flag;
    // Start is called before the first frame update
    void Awake()
    {
        isAlive = false;
        flag = true;
    }
    void Start()
    {
        PlayerTarget = (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position;
        isAlive = PlayerTarget != null ? true : false;

    }

    private void Update()
    {
        PlayerTarget = (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position;
        if (PlayerTarget != null)
        {
            Vector2 Dir = PlayerTarget - (Vector2)transform.position;
            transform.up = Vector2.MoveTowards(transform.up, Dir, RotSpeed * Time.deltaTime);
            if ((flag))
            {
                ShottingEnemy Ammo = Instantiate(AmmoPrefab, ShotPos.position, transform.rotation);
                Ammo.ShotProyectil(transform.up);
                StartCoroutine(Wait(1.2f));

            }

        }
        else
        {
            StopAllCoroutines();
        }

    }
    IEnumerator Wait(float delay)
    {
        flag = false;
        yield return new WaitForSeconds(delay);
        flag = true;
    }

}