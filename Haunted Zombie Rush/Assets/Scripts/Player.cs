using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour {

	[SerializeField] private float jumpForce = 100f; //2
	// instead of dragging audio clip to audio source directly
	// you create a separate audio clip to easily play different sounds.
	[SerializeField] private AudioClip sfxJump; //3
	[SerializeField] private AudioClip sfxDeath;

	private Animator anim; //1
	private Rigidbody rigidBody; //2
	private AudioSource audioSource; //3

	private bool jump = false; //2

	void Awake () {
		Assert.IsNotNull (sfxJump);
		Assert.IsNotNull (sfxDeath);
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> (); //1
		rigidBody = GetComponent<Rigidbody> (); //2
		audioSource = GetComponent<AudioSource> (); //3
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			anim.Play ("Jump"); //1
			audioSource.PlayOneShot (sfxJump); //3, playoneshot means play once
			rigidBody.useGravity = true; //2
			jump = true; //1
		}
	}

	void FixedUpdate () { //2
		if (jump == true) { //2
			jump = false;//2
			rigidBody.velocity = new Vector2 (0, 0); //2
			rigidBody.AddForce (new Vector2 (0, jumpForce), ForceMode.Impulse);//2
		}
	}

	//4, all 4 - build in collision detector
	void OnCollisionEnter (Collision collision) { 
		if (collision.gameObject.tag == "obstacle") {
			rigidBody.AddForce (new Vector2 (-50, 20), ForceMode.Impulse);
			rigidBody.detectCollisions = false;
			audioSource.PlayOneShot (sfxDeath);
		}
	}
}
