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
		transform.localScale = new Vector3 (0.01F, 0.01F, 0.01F);
		transform.position = new Vector2 (0, 0);
		player = GameObject.Find ("Player").GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		distance -= player.speed;
		xPos -= player.direction;
		
		//transform.position = new Vector2 (xPos/(float)horizonWidth * Screen.width, distance/(float)horizonDistance * Screen.height);
		transform.localScale += new Vector3 (0.01F, 0.01F, 0.01F);
	}
}
