using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    // Update is called once per frame
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var x = player.transform.position.x;
        var y = player.transform.position.y;
        transform.position = new Vector3(x, y, transform.position.z);

    }
}