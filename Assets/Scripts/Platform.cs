using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

    //ArrayList children = new ArrayList();
    Vector2 lastPos = new Vector2();

    void Init()
    {
        lastPos = transform.position;
    }

    void Update()
    {

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.parent = gameObject.transform;
        //children.Add(collision.gameObject);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = null;
        //children.Remove(collision.gameObject);
    }
}
