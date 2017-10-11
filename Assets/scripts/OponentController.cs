using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OponentController : MonoBehaviour {

	public float speed = 1;
	public Vector3 position;
	public float x;
	public float y;
	public float z;
	public int counter = 0;
	public List<PlayerInfo> array;

	private Rigidbody rb;

	void Start ()
	{
			SaveDataController DataController = new SaveDataController();
			array = DataController.readData();
			print(array.Count);
	}

	void move() {
		x = array[counter].x	;
		y = array[counter].y	;
		z = array[counter].z;
		position = new Vector3 (x, y, z);
		transform.position = position;
		counter = counter + 1;
	}

	void FixedUpdate() {
		move();
	}

}
