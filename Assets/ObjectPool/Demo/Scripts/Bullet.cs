using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public Explosion explosionPrefab;
	public float shootDistance;
	public float shootSpeed;
	
	void OnEnable()
	{
		StartCoroutine(Shoot());
	}

	void OnDisable()
	{
		StopAllCoroutines();
	}

	IEnumerator Shoot()
	{
		float travelledDistance = 0;
		while (travelledDistance < shootDistance)
		{
			travelledDistance += shootSpeed * Time.deltaTime;
			transform.position += transform.forward * (shootSpeed * Time.deltaTime);
			yield return 0;
		}

		//Spawn a pooled explosion prefab
		explosionPrefab.Spawn(transform.position);

		//Recycle this pooled bullet instance
		gameObject.Recycle();
	}
}
