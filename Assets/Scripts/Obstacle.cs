using UnityEngine;
using System.Collections;


public class Obstacle : MonoBehaviour {
	public enum obstacleType{
		ROCK, RAMP, TREE, CABBAGES
	};
	private static int horizonDistance = 1000;
	private static int horizonWidth = 1000;

	public int distance;
	public int xPos;
	public int width;
	public obstacleType type;
	
	public Player player;

	// Use this for initialization
	void Start () { 
		xPos = Random.Range (-horizonWidth, horizonWidth);
		distance = horizonDistance;
		player = GameObject.Find ("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		distance -= player.speed;
		xPos -= player.direction;


	}
}
