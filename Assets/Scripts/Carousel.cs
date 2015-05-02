using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Carousel : MonoBehaviour {

	[SerializeField]
	private float time;

	[SerializeField]
	private Transform[] positions;

	private List<Transform> objects;

	private float[] timers;

	void Awake()
	{
		objects = new List<Transform>();
		timers = new float[positions.Length];

		for(int i = 0; i < timers.Length; i++)
		{
			timers[i] = 0.0f;
		}
	}

	public void addObject(Transform transform)
	{

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
