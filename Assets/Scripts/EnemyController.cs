using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private int pared = 0;
    private int direccion = 0;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if ( pared == 1)
        {
            if (direccion == 0)
            {
                _renderer.flipX = false;
                
                _rigidbody.velocity = new Vector2(10,_rigidbody.velocity.y);
             
                Debug.Log(pared);
                direccion = 1;
                pared = 0;
                Debug.Log(pared);
                
                Debug.Log("Corre ->");
            }
            else
            {
                _renderer.flipX = true;
                
                _rigidbody.velocity = new Vector2(-10, _rigidbody.velocity.y);
                pared = 0;
                direccion = 0;
                Debug.Log("Corre <-");
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pared" )
        {
            pared = 1;
            Debug.Log("Toco Pared");
        }
        
        if (collision.gameObject.tag == "bullet" )
        {
           Destroy(this.gameObject);
           Debug.Log("Enemigo Desaparece");
        }
    }
}

