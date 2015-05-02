using UnityEngine;
using System.Collections;


public class Effect : MonoBehaviour {
	public enum effectType{
		RIPPLE_ONE, RIPPLE_TWO, RIPPLE_THREE
	};
	private static int horizonDistance = 1000;
	private static int horizonWidth = 1000;
	
	public int distance;
	public int xPos;
	public effectType type;
	
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
