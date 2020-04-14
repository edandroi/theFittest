using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
	public Transform player;

	public float distanceFromPlayer;

	public float zValue = -10f;

	public float lerpSpeed = .2f;
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		transform.position = Vector3.Lerp(transform.position, player.position + new Vector3(distanceFromPlayer, 0, 0), lerpSpeed);
		transform.position = new Vector3(transform.position.x, transform.position.y, zValue);
	}
}
