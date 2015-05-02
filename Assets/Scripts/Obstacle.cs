using UnityEngine;
using System.Collections;


public class Obstacle : MonoBehaviour {
	public enum obstacleType{
		ROCK, RAMP, BUMP, CABBAGES
	};
	private static int horizonDistance = 1000;
	private static int horizonWidth = 1000;

	public int distance;
	public int xPos;
	public int width;
	public obstacleType type;
	
	public Player player;

	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () { 
		xPos = (int) Random.Range (-horizonWidth, horizonWidth) ;
		distance = horizonDistance;
		///transform.localScale = new Vector3 (0.01F, 0.01F, 0.01F);
		player = GameObject.Find ("Player").GetComponent<Player> ();

		foreach (Transform child in transform) {
			sprite = child.gameObject.GetComponent<SpriteRenderer>();
			break;
		}
		FixedUpdate ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		distance -= player.speed;
		xPos += (int)(player.xSpeed * 100);
		sprite.sortingOrder = -distance;
		//Vector3 center = transform.
		transform.position = new Vector3 (xPos*40 / (float)horizonWidth * (horizonDistance - distance) / 500.0F, 4 - 5 * (horizonDistance / (float)((1+distance)*2)), 0);
		transform.localScale += new Vector3 (0.00001F * (horizonDistance-distance), 0.00001F * (horizonDistance-distance), 0.00001F * (horizonDistance-distance));

	}
}
