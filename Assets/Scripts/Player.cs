using UnityEngine;
using System.Collections;

#define skiBoundary 5

public class Player : MonoBehaviour {
	public int speed;
	public int leftSkiDirection;
	public int rightSkiDirection;
	public int getDirection {
		get { return leftSkiDirection + rightSkiDirection; }
	}
	public int height;
	// Use this for initialization
	void Start () {
		speed = 10;
		direction = 0;
		height = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q) && leftSkiDirection > -skiBoundary) {
			leftSkiDirection--;
		} else if (Input.GetKeyDown (KeyCode.W) && leftSkiDirection < skiBoundary) {
			leftSkiDirection++;
		} else if (Input.GetKeyDown (KeyCode.O) && rightSkiDirection > -skiBoundary) {
			rightSkiDirection--;
		} else if (Input.GetKeyDown (KeyCode.P) && rightSkiDirection < skiBoundary) {
			rightSkiDirection++;
		}

		if (height == 0) {

		}


	}
}
