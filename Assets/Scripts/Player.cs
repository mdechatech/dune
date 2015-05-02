using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public static int skiBoundary;

	public int speed;
	public int leftSkiDirection;
	public int rightSkiDirection;
	public int direction {
		get { return leftSkiDirection + rightSkiDirection; }
	}
	public int height;

	void Start () {
		skiBoundary = 5;
		speed = 10;
		leftSkiDirection = 0;
		rightSkiDirection = 0;
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
