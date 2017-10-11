using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OponentController : MonoBehaviour {

	public float speed = 1;
	public Vector3 position;


	private Rigidbody rb;

	void Start ()
	{
			position = new Vector3 (2.0f, 2.0f, 2.0f);
			transform.position = position;

	}

}
