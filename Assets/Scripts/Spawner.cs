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
		int temp = Random.Range (0, 50);
		if (temp == 0)
			obstacles.Add (Instantiate (obstaclePrefabs [Random.Range (0, obstaclePrefabs.Length)]));

		temp = Random.Range (0, 50);
		if (temp == 0)
			effects.Add (Instantiate (effectPrefabs [Random.Range(0, effectPrefabs.Length)]));
	
		for (int i = obstacles.Count-1; i >= 0; i--) {
			if (obstacles[i].GetComponent<Obstacle>().distance < 0){
				Destroy(obstacles[i]);
				obstacles.RemoveAt(i);
			}
		}
		for (int i = effects.Count-1; i >= 0; i--) {
			if (effects[i].GetComponent<Effect>().distance < 0){
				Destroy(effects[i]);
				effects.RemoveAt(i);
			}
		}
	}
}
