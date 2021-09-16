using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    public GameObject bullet;
    
    // Start is called before the first frame update
    void Start()
    {

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) )
        {
            _spriteRenderer.flipX= false;
            setRunAnimation();
            _rigidbody2D.velocity = new Vector2(10,_rigidbody2D.velocity.y);
        }
        else
        {
            setIdleAnimation();
            _rigidbody2D.velocity = new Vector2(0,_rigidbody2D.velocity.y);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _spriteRenderer.flipX = true;
            setRunAnimation();
            _rigidbody2D.velocity = new Vector2(-10,_rigidbody2D.velocity.y);
        }
        
        if (Input.GetKeyUp(KeyCode.C))
        {
            var position = new Vector2(transform.position.x, transform.position.y);
            Instantiate(bullet, position, bullet.transform.rotation);
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow)  || Input.GetKeyDown(KeyCode.Space) )
        {
            var upSpeed = 30f;
            _rigidbody2D.velocity = Vector2.up * upSpeed;

            setJumpAnimation();
            
        }
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Coin" )
        {
            
            Debug.Log("Sumar Puntaje");
        }
    }
    
    private void setIdleAnimation(){
        _animator.SetInteger("Estado",0);
    }

    private void setRunAnimation(){
        _animator.SetInteger("Estado",1);
    }
    
    private void setJumpAnimation(){
        _animator.SetInteger("Estado",2);
    }
    
    private void setSlideAnimation(){
        _animator.SetInteger("Estado",3);
    }
    
}
