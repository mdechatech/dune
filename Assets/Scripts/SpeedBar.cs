using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeedBar : MonoBehaviour {

	[SerializeField]
	private Player player;

	[SerializeField]
	private Image bar;

	[SerializeField]
	private int minSpeed;

	[SerializeField]
	private int maxSpeed;

	[SerializeField]
	private float smoothnessFactor;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float ratio = Mathf.Clamp ((player.speed - minSpeed) / (float)(maxSpeed - minSpeed), 0.0f, 1.0f);
		transform.localScale = Vector3.Lerp (transform.localScale,
		                                    new Vector3 (transform.localScale.x, ratio, transform.localScale.z),
		                                    Time.deltaTime * smoothnessFactor);
		bar.color = Color.Lerp (bar.color, new Color (ratio, 1.0f - ratio, 1.0f - ratio, Mathf.Clamp (ratio, 0.5f, 1.0f)),
		                       Time.deltaTime * smoothnessFactor);

	}
}
