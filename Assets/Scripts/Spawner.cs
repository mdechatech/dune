using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
	public GameObject[] obstaclePrefabs;
	public GameObject[] effectPrefabs;
	public List<GameObject> obstacles;
	public List<GameObject> effects;

	private Player player;

	void Awake() {
		player = GameObject.Find ("Player").GetComponent<Player> ();
	}

	void Start () {
		
	}
	// Update is called once per frame
	void FixedUpdate () {
		int temp = Random.Range (0, 5);
		if (temp == 0)
			obstacles.Add (Instantiate (obstaclePrefabs [Random.Range (0, obstaclePrefabs.Length-1)]));

		temp = Random.Range (0, 2);
		if (temp == 0)
			effects.Add (Instantiate (effectPrefabs [Random.Range(0, effectPrefabs.Length)]));
	
		obstacles.Add (Instantiate (obstaclePrefabs [obstaclePrefabs.Length - 1]));

		for (int i = obstacles.Count-1; i >= 0; i--) {
			Obstacle obstacle = obstacles[i].GetComponent<Obstacle>();
			if (obstacle.distance < 200){
				if(!obstacle.hasCollided)
				{
					player.onHitObstacle(obstacle);
					obstacle.hasCollided = true;
				}
			}
			if(obstacle.distance < 10)
			{
				Destroy(obstacles[i]);
				obstacles.RemoveAt(i);
			}
		}
		for (int i = effects.Count-1; i >= 0; i--) {
			if (effects[i].GetComponent<Effect>().distance < 100){
				Destroy(effects[i]);
				effects.RemoveAt(i);
			}
		}
	}
}
