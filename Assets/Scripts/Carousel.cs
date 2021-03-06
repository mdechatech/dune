﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Carousel : MonoBehaviour {
	
	public GameObject trickBase;

	[SerializeField]
	private float time;

	[SerializeField]
	private Transform[] positions;

	[SerializeField]
	private float animationSpeed = 5.0f;

	private List<Transform> objects;
	private List<float> timers;

	private List<Transform> garbage;

	void Awake()
	{
		objects = new List<Transform>();
		timers = new List<float> ();

		garbage = new List<Transform> ();
	}

	public Trick addTrick(string description, int score)
	{
		Trick trick = GameObject.Instantiate (trickBase).GetComponent<Trick> ();
		trick.description.text = description; trick.score.text = score.ToString ();
		trick.transform.SetParent (transform, false);
		addObject (trick.transform);
		return trick;
	}

	public void addObject(Transform transform)
	{
		transform.SetParent (this.transform);

		if (objects.Count == positions.Length) {
			removeObject (0);
		}

		objects.Add (transform);
		timers.Add(time);
	}

	public void removeObject(int index)
	{
		Destroy (objects [index].gameObject, 1.0f);
		garbage.Add (objects [index]);

		objects.RemoveAt (index);
		timers.RemoveAt (index);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = objects.Count - 1; i >= 0; i--)
		{
			timers[i] -= Time.deltaTime;
			objects[i].position = Vector3.Lerp(objects[i].position, positions[i].position, Time.deltaTime * animationSpeed);

			if(timers[i] <= 0.0f)
			{
				removeObject(i);
			}
		}

		for(int i = garbage.Count - 1; i >= 0; i--)
		{
			if(garbage[i].gameObject != null)
			{
				garbage[i].position = Vector3.Lerp(garbage[i].position, garbage[i].position - new Vector3(100.0f, 0.0f, 0.0f),
				                                   Time.deltaTime * animationSpeed * 10.0f);
			} else {
				garbage.RemoveAt(i);
			}
		}
	}
}
