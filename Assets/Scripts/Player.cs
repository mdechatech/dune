using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {
	[Header("Objects")]

	[SerializeField]
	private GameObject leftSki;

	[SerializeField]
	private GameObject rightSki;

	[Header("Controls")]

	[SerializeField]
	private int skiIntervals = 4;

	[SerializeField]
	private float xAcceleration = 1.0f;

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

	[Header("UI")]
	[SerializeField]
	private Text scoreText;

	[HideInInspector]
	public int speed;
	[HideInInspector]
	public int leftSkiDirection;
	[HideInInspector]
	public int rightSkiDirection;
	public int direction {
		get { return leftSkiDirection + rightSkiDirection; }
	}

	[HideInInspector]
	public float xSpeed;
	[HideInInspector]
	public float ySpeed;

	private float targetXSpeed;

	[HideInInspector]
	public float height;

	[HideInInspector]
	public int score;

	void Start () {
		scoreText.text = "0";

		speed = 10;
		leftSkiDirection = 0;
		rightSkiDirection = 0;
		height = 0;
		xSpeed = targetXSpeed = 0.0f;
		ySpeed = 0;

		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (leftSkiLeftKey) && leftSkiDirection > -skiIntervals) {
			leftSkiDirection--;
		} else if (Input.GetKeyDown (leftSkiRightKey) && leftSkiDirection < skiIntervals) {
			leftSkiDirection++;
		} else if (Input.GetKeyDown (rightSkiLeftKey) && rightSkiDirection > -skiIntervals) {
			rightSkiDirection--;
		} else if (Input.GetKeyDown (rightSkiRightKey) && rightSkiDirection < skiIntervals) {
			rightSkiDirection++;
		}
	

		if (Mathf.Abs (leftSkiDirection - rightSkiDirection) > skiIntervals) {
			Debug.Log("is kill");
		}
	}

	void FixedUpdate()
	{
		float leftSkiAngle = (45.0f / (float)(skiIntervals)) * -leftSkiDirection;
		float rightSkiAngle = (45.0f / (float)(skiIntervals)) * -rightSkiDirection;
		float totalSkiAngle = (45.0f / (float)(skiIntervals)) * (leftSkiDirection + rightSkiDirection) / 2.0f;

		leftSki.transform.eulerAngles = new Vector3 (0.0f, 0.0f, Mathf.LerpAngle (leftSki.transform.eulerAngles.z, leftSkiAngle, 0.1f));
		rightSki.transform.eulerAngles = new Vector3 (0.0f, 0.0f, Mathf.LerpAngle (rightSki.transform.eulerAngles.z, rightSkiAngle, 0.1f));

		if (height < 0.0f) {
			height = 0.0f;
			ySpeed = 0.0f;
		}

		if (height == 0.0f) {
			targetXSpeed = Mathf.Cos ((totalSkiAngle + 90.0f) * Mathf.Deg2Rad) * xSpeedFactor;
			xSpeed = Mathf.Lerp(xSpeed, targetXSpeed, xAcceleration * Time.fixedDeltaTime);
		} else if (height > 0.0f) {
			score++;
			scoreText.text = score.ToString();

			ySpeed -= gravity * Time.fixedDeltaTime;
			height += ySpeed * Time.fixedDeltaTime;
		}
	}

	public void onHitObstacle(Obstacle obstacle)
	{
		if (height == 0) {
			int halfWidth = obstacle.width >> 1;
			
			if ((obstacle.xPos <= halfWidth && obstacle.xPos >= -halfWidth && obstacle.type != Obstacle.obstacleType.TRACK) ||
				(obstacle.xPos >= halfWidth && obstacle.xPos <= -halfWidth)){
				switch (obstacle.type) {
				case Obstacle.obstacleType.BUMP:
					leftSkiDirection += Random.Range(-2, 3);
					leftSkiDirection = (Mathf.Abs(leftSkiDirection) % (skiIntervals + 1)) * ((leftSkiDirection < 0) ? -1 : 1);
					rightSkiDirection += Random.Range(-2, 3);
					rightSkiDirection %= (Mathf.Abs(rightSkiDirection) % (skiIntervals + 1)) * ((rightSkiDirection < 0) ? -1 : 1);
					break;
					
				case Obstacle.obstacleType.RAMP:
					ySpeed += 10 * (speed / 10.0f);
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
