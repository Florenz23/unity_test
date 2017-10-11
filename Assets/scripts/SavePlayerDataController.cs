using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerDataController : MonoBehaviour {

	public Vector3 recentPosition;
	public int counter = 0;
	public List<PlayerInfo> array = new List<PlayerInfo>();


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void FixedUpdate (){
		// savePerformData();
	}

	void savePerformData() {
		if (counter == 1000){
			SaveDataController DataController = new SaveDataController();
			DataController.writeData(array);
			// array = new List<PlayerInfo>();
			counter = 0;
		}
		recentPosition = transform.position;
		var x = recentPosition.x;
		var y = recentPosition.y;
		var z = recentPosition.z;
		PlayerInfo myObject = new PlayerInfo();
		myObject.x = x;
		myObject.y = y;
		myObject.z = z;
		array.Add(myObject);
		array.Add(myObject);
		counter = counter + 1;
	}
}
