using UnityEngine;
using System.Collections;

public class ScreenBounds : MonoBehaviour {

	private float screenWidth = 0;
	private float screenHeight = 0;
	private GameObject topBound;
	private GameObject bottomBound;
	private GameObject leftBound;
	private GameObject rightBound;

	// Use this for initialization
	void Start () {
		// Boundary prefab, which is just a box collider.
		GameObject boundary = new GameObject();
		boundary.AddComponent<BoxCollider2D>();
		// Instantiate each wall of the bounds.
		topBound = GameObject.Instantiate(boundary) as GameObject;
		topBound.transform.Rotate(new Vector3(0, 0, 90));
		topBound.name = "TopBound";
		bottomBound = GameObject.Instantiate(boundary) as GameObject;
		bottomBound.transform.Rotate(new Vector3(0, 0, 90));
		bottomBound.name = "BottomBound";
		leftBound = GameObject.Instantiate(boundary) as GameObject;
		leftBound.name = "LeftBound";
		rightBound = GameObject.Instantiate(boundary) as GameObject;
		rightBound.name = "RightBound";
		// Destroy original.
		DestroyImmediate(boundary);
	}
	
	// Update is called once per frame
	void Update () {
		// If window size has changed, re-position boundaries.
		if (Screen.width != screenWidth || Screen.height != screenHeight) {
			// Get screen width and height in pixels.
			screenWidth = Screen.width;
			screenHeight = Screen.height;
			// Convert screen width and height to world coordinates.
			float screenWorldHeight = camera.orthographicSize;
			float screenWorldWidth = screenWorldHeight * Screen.width / Screen.height;
			// Position and scale bounds so that they lie on the edges of the screen.
			topBound.transform.position = new Vector3(screenWorldWidth, 0, 0);
			topBound.transform.localScale = new Vector3(screenWorldHeight * 2, 0, 1);
			bottomBound.transform.position = new Vector3(-screenWorldWidth, 0, 0);
			bottomBound.transform.localScale = new Vector3(screenWorldHeight * 2, 0, 1);
			leftBound.transform.position = new Vector3(0, screenWorldHeight, 0);
			leftBound.transform.localScale = new Vector3(screenWorldWidth * 2, 0, 1);
			rightBound.transform.position = new Vector3(0, -screenWorldHeight, 0);
			rightBound.transform.localScale = new Vector3(screenWorldWidth * 2, 0, 1);
		}	
	}
}
