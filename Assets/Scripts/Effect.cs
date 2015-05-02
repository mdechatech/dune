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
	
	private SpriteRenderer sprite;


	// Use this for initialization
	void Start () {
		xPos = Random.Range (-horizonWidth, horizonWidth);
		distance = horizonDistance;
		transform.localScale = new Vector3 (0.01F, 0.01F, 0.01F);
		transform.position = new Vector2 (0, 0);
		player = GameObject.Find ("Player").GetComponent<Player> ();
		
		foreach (Transform child in transform) {
			sprite = child.gameObject.GetComponent<SpriteRenderer>();
			break;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		distance -= player.speed;
		xPos -= player.direction;
		sprite.sortingOrder = -2000;
		
		transform.position = new Vector3 (xPos* (horizonDistance-distance) / 20000.0F, 3 - 5 * (horizonDistance / (float)((1+distance)*2)), 0);
		transform.localScale += new Vector3 (0.0001F * (horizonDistance-distance), 0.0001F * (horizonDistance-distance), 0.0001F * (horizonDistance-distance));
		}
}
