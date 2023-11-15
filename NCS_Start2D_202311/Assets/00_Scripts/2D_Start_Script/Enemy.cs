using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 v3 = Vector3.left;
    private Vector3 veR = Vector3.right;
    public float speed = 2f;
    public Animator mosion;
    Vector3 scaleVec = Vector3.one;
    public SpriteRenderer sr;
    private int HP = 50;
    private int MaxHP = 50;
    private int Power = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        HP = 50;
        mosion = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(v3 * Time.deltaTime * speed);
        
        if (v3.x != 0)
        {
            scaleVec.x = v3.x;
            StartCoroutine(Moving());
            mosion.SetBool("IsMove", true);
            
        }
        else
        {
            mosion.SetBool("IsMove", false);
            
        }
    }

    IEnumerator Moving()
    {
        yield return new WaitForSeconds(3);
        speed = 2f;
        sr.flipX = true;
        scaleVec.x = veR.x;
        transform.Translate(veR * Time.deltaTime * speed);
        
    }

    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Transform playerTransform = other.transform;
            float playerY = playerTransform.position.y;
            float enemyY = transform.position.y;
            if (playerY > enemyY)
            {
                Hit();
                sr.color = Color.red;
                StartCoroutine(ColorChangle());
            }
            else
            {
                sr.color = Color.white;
            }
        }
        
    }
    
    public void Hit()
    {
        HP -= 10;
        
        Debug.Log($"적채력 : {HP}");
        if (HP == 0)
        {
            Debug.Log("Enemy 사망했습니다");
            gameObject.SetActive(false);
        }
    }

    IEnumerator ColorChangle()
    {
        yield return new WaitForSeconds(0.5f);
        sr.color = Color.white;
    }

    
    
    
}
