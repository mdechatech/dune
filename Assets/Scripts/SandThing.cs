using UnityEngine;
using System.Collections;

enum objectType{
	ROCK, RAMP, TREE, CABBAGES, RIPPLE_ONE, RIPPLE_TWO, RIPPLE_THREE
};

public class SandThing : MonoBehaviour {

	public int distance;
	public int xPos;
	public int width;
	objectType type;
	bool collidable;

	public void create(int setX, objectType setType){
		xPos = setX;
		type = setType;
		switch (type) {
		case objectType.ROCK:
			break;
		case objectType.RAMP:
			break;
		case objectType.TREE:
			break;
		case objectType.CABBAGES:
			break;
		case objectType.RIPPLE_ONE:
			break;
		case objectType.RIPPLE_TWO:
			break;
		case objectType.RIPPLE_THREE:
			break;
		}
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
