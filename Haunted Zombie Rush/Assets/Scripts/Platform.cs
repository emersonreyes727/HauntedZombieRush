using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	[SerializeField] private float platformSpeed;
	[SerializeField] private float resetPlatformPosition = -34.0f;
	[SerializeField] private float startPlatformPosition = 28.80f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public virtual void Update () {
		transform.Translate (Vector3.left * (platformSpeed * Time.deltaTime));

		if (transform.localPosition.x <= resetPlatformPosition) {
			Vector3 newPosition = new Vector3 (startPlatformPosition, transform.position.y, transform.position.z);
			transform.position = newPosition;
		}
	}
}
