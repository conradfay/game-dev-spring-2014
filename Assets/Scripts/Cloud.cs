using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {

    public float speed = 1.0f;
    public float startPosX;
    public float endPosX;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        if (transform.position.x > endPosX)
            transform.position = new Vector3(startPosX, transform.position.y, transform.position.z);
	}
}
