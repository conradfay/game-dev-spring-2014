using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

    void Init()
    {

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
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = null;
    }
}
