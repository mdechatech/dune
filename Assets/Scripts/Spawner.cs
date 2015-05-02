using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
	public GameObject[] obstaclePrefabs;
	public GameObject[] effectPrefabs;
	public List<GameObject> obstacles;
	public List<GameObject> effects;
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		int temp = Random.Range (0, 20);
		if (temp == 0)
			obstacles.Add (Instantiate (obstaclePrefabs [Random.Range (0, obstaclePrefabs.Length)]));

		temp = Random.Range (0, 10);
		if (temp == 0)
			effects.Add (Instantiate (obstaclePrefabs [Random.Range(0, effectPrefabs.Length)]));

			        

	}
}
