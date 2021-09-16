using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public float velocityX = 10F;
    
    
    private Rigidbody2D _rigidbody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 30);
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.velocity = new Vector2(velocityX, _rigidbody2D.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy" )
        {
            Destroy(this.gameObject);
            Debug.Log("Murió");
        }
    }
}
