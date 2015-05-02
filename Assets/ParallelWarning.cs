using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(RectTransform), typeof(CanvasGroup))]
public class ParallelWarning : MonoBehaviour {

	private CanvasGroup group;

	public bool on;

	[SerializeField]
	private Transform bar;

	void Awake()
	{
		group = GetComponent<CanvasGroup> ();
	}

	public void activate()
	{
		on = true;
	}

	public void deactivate()
	{
		on = false;
	}

	public void fill(float ratio)
	{
		bar.transform.localScale = new Vector3(ratio, 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (on) {
			group.alpha = Mathf.Lerp (group.alpha, 1.0f, Time.deltaTime * 10.0f);
		} else {
			group.alpha = Mathf.Lerp(group.alpha, 0.0f, Time.deltaTime * 10.0f);
		}
	}
}
