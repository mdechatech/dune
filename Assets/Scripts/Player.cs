using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public static int skiBoundary;

	[Header("Objects")]

	[SerializeField]
	private GameObject leftSki;

	[SerializeField]
	private GameObject rightSki;

	[Header("Controls")]

	[SerializeField]
	private KeyCode leftSkiLeftKey;

	[SerializeField]
	private KeyCode leftSkiRightKey;

	[SerializeField]
	private KeyCode rightSkiLeftKey;

	[SerializeField]
	private KeyCode rightSkiRightKey;

	[HideInInspector]
	public int speed;
	[HideInInspector]
	public int leftSkiDirection;
	[HideInInspector]
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
		if (Input.GetKeyDown (leftSkiLeftKey) && leftSkiDirection > -skiBoundary) {
			leftSkiDirection--;
		} else if (Input.GetKeyDown (leftSkiRightKey) && leftSkiDirection < skiBoundary) {
			leftSkiDirection++;
		} else if (Input.GetKeyDown (rightSkiLeftKey) && rightSkiDirection > -skiBoundary) {
			rightSkiDirection--;
		} else if (Input.GetKeyDown (rightSkiRightKey) && rightSkiDirection < skiBoundary) {
			rightSkiDirection++;
		}

		if (height == 0) {

		}


	}

	void FixedUpdate()
	{
		float leftSkiAngle = (45.0f / (float)(skiBoundary - 1)) * -leftSkiDirection;
		float rightSkiAngle = (45.0f / (float)(skiBoundary - 1)) * -rightSkiDirection;

		leftSki.transform.eulerAngles = new Vector3 (0.0f, 0.0f, Mathf.LerpAngle (leftSki.transform.eulerAngles.z, leftSkiAngle, 0.1f));
		rightSki.transform.eulerAngles = new Vector3 (0.0f, 0.0f, Mathf.LerpAngle (rightSki.transform.eulerAngles.z, rightSkiAngle, 0.1f));
	}
}
