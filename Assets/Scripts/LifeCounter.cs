using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeCounter : MonoBehaviour {
	[SerializeField]
	private Text amount;
	public void setLives(int lives)
	{
		amount.text = lives.ToString ();
	}
}
