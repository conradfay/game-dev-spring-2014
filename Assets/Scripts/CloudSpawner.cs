using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour {

    public Cloud cloudPrefab;
    public float density = 1.0f;
    public float lowerDistanceBound = 1.0f;
    public float upperDistanceBound = 2.0f;
	public Vector2 spawnRectBottomLeft;
	public Vector2 spawnRectTopRight;
    public float baseSpeed = 0.2f;
    public Color subtractiveColor = Color.gray;

	// Use this for initialization
	void Start () {
        int numClouds = (int)(spawnRectTopRight.x - spawnRectBottomLeft.x * density);
        for (int i = 0; i < numClouds; i++)
        {
            float posX = Random.Range(spawnRectBottomLeft.x, spawnRectTopRight.x);
            float posY = Random.Range(spawnRectBottomLeft.y, spawnRectTopRight.y);
            float distance = Random.Range(lowerDistanceBound, upperDistanceBound);
            Cloud spawnedCloud = GameObject.Instantiate(cloudPrefab, new Vector3(posX, posY, 0), Quaternion.identity) as Cloud;
            spawnedCloud.startPosX = spawnRectBottomLeft.x;
            spawnedCloud.endPosX = spawnRectTopRight.x;
            spawnedCloud.speed = 1 / distance * baseSpeed;
            spawnedCloud.transform.localScale = spawnedCloud.transform.localScale / distance;
            spawnedCloud.GetComponent<SpriteRenderer>().color -= subtractiveColor * distance / upperDistanceBound;
            Color color = spawnedCloud.GetComponent<SpriteRenderer>().color;
            spawnedCloud.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1.0f);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
