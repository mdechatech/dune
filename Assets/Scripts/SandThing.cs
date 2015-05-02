using UnityEngine;
using System.Collections;

enum objectType{
	ROCK, RAMP, TREE, CABBAGES
};

public class SandThing : MonoBehaviour {

	public int distance;
	public int xPos;
	public int width;
	obstacleType type;
	bool collidable;

	public void create(int setX, obstacleType setType){
		xPos = setX;
		type = setType;
	}

	public Player player;

	// Use this for initialization
	void Start () {
		distance = horizonDistance;
		player = GameObject.Find ("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		distance -= player.speed;
		xPos -= player.getDirection ();
	}
}
