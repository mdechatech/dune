using UnityEngine;
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

	void Awake()
	{
		objects = new List<Transform>();
		timers = new List<float> ();
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
		} else {
			objects.Add (transform);
			timers.Add(time);
		}
	}

	public void removeObject(int index)
	{
		objects.RemoveAt (index);
		timers.RemoveAt (index);
		Destroy(objects[index].gameObject);
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
	}
}
