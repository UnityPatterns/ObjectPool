using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
	public AnimationCurve animationCurve;
	public float duration;

	void OnEnable()
	{
		StartCoroutine(Shrink());
	}

	IEnumerator Shrink()
	{
		transform.localScale = Vector3.one;
		float elapsed = 0;
		while (elapsed < duration)
		{
			float scale = 1 - animationCurve.Evaluate(elapsed / duration);
			transform.localScale = new Vector3(scale, scale, scale);
			elapsed += Time.deltaTime;
			yield return 0;
		}

		//Recycle this pooled explosion instance
		gameObject.Recycle();
	}
}
