using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[SerializeField]
	private Player player;

	private Vector3 originalPosition;

	void Awake()
	{
		originalPosition = transform.position;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		transform.position = originalPosition + new Vector3 (0.0f, player.height, 0.0f);
	}
}
