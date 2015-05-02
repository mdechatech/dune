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
	private float xSpeedFactor = 1.0f;

	[SerializeField]
	private float gravity = 9.81f;

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

	public float xSpeed;
	public float ySpeed;

	[HideInInspector]
	public float height;

	void Start () {
		skiBoundary = 5;
		speed = 10;
		leftSkiDirection = 0;
		rightSkiDirection = 0;
		height = 0;
		xSpeed = 0;
		ySpeed = 0;
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
	

		if (Mathf.Abs (leftSkiDirection - rightSkiDirection) >= skiBoundary) {
			Debug.Log("is kill");
		}
	}

	void FixedUpdate()
	{
		float leftSkiAngle = (45.0f / (float)(skiBoundary - 1)) * -leftSkiDirection;
		float rightSkiAngle = (45.0f / (float)(skiBoundary - 1)) * -rightSkiDirection;
		float totalSkiAngle = (45.0f / (float)(skiBoundary - 1)) * (leftSkiDirection + rightSkiDirection) / 2.0f;

		leftSki.transform.eulerAngles = new Vector3 (0.0f, 0.0f, Mathf.LerpAngle (leftSki.transform.eulerAngles.z, leftSkiAngle, 0.1f));
		rightSki.transform.eulerAngles = new Vector3 (0.0f, 0.0f, Mathf.LerpAngle (rightSki.transform.eulerAngles.z, rightSkiAngle, 0.1f));

		xSpeed = Mathf.Cos ((totalSkiAngle + 90.0f) * Mathf.Deg2Rad) * xSpeedFactor;

		if (height < 0.0f) {
			height = 0.0f;
			ySpeed = 0.0f;
		} else if (height > 0.0f) {
			ySpeed -= gravity * Time.fixedDeltaTime;
			height += ySpeed * Time.fixedDeltaTime;
		}
	}

	public void onHitObstacle(Obstacle obstacle)
	{
		if (height == 0) {
			Debug.Log ("t " + obstacle.type + ", w " + obstacle.width + ", x " + obstacle.xPos);
			int halfWidth = obstacle.width >> 1;
			
			if (obstacle.xPos <= halfWidth && obstacle.xPos >= -halfWidth) {
				switch (obstacle.type) {
				case Obstacle.obstacleType.BUMP:
					leftSkiDirection += Random.Range(-2, 3);
					leftSkiDirection = (Mathf.Abs(leftSkiDirection) % skiBoundary) * ((leftSkiDirection < 0) ? -1 : 1);
					rightSkiDirection += Random.Range(-2, 3);
					rightSkiDirection %= (Mathf.Abs(rightSkiDirection) % skiBoundary) * ((rightSkiDirection < 0) ? -1 : 1);
					break;
					
				case Obstacle.obstacleType.RAMP:
					ySpeed += 10;
					height += 0.001f;
					break;
					
				case Obstacle.obstacleType.ROCK:
					Debug.Log("Hit rock?!!?");
					break;
					
				default:
					Debug.LogWarning("Player hit an obstacle with unknown behavior.", obstacle);
					break;
				}
			}
		}
	}
}
