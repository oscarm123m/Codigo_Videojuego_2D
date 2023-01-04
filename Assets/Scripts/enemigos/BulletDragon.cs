using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDragon : MonoBehaviour
{

    public float speed = 2;
    public float lifeTime = 1;
    public bool left;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(left)
        {
            transform.Translate(Vector2.left*speed*Time.deltaTime);   
        }
        else
        {
            transform.Translate(Vector2.right*speed*Time.deltaTime);   
        }
    }
    
}
