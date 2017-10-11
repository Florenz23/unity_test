using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DisplayText : MonoBehaviour {

	public TextMesh name_text;


  public float targetTime = 0.0f ;
  public int minutes = 0 ;
	public Vector3 startPosition;
	public Vector3 recentPosition;
	// Use this for initialization
	void Start () {
		//time
		startPosition = transform.position;

	}

	string getTime() {

		targetTime += Time.deltaTime;
		if(targetTime > 60) {
			targetTime = 0.0f;
			minutes = minutes + 1;
		}
		decimal decimalValue = Math.Round((decimal)targetTime, 1);

		var stringTime = minutes + ":" + decimalValue;

		return stringTime;
	}

	string getDistance() {

		recentPosition = transform.position;
		var x1 = startPosition.x;
		var x2 = recentPosition.x;
		var y1 = startPosition.z;
		var y2 = recentPosition.z;
		var x_calc = Math.Pow((x2-x1),2);
		var y_calc = Math.Pow((y2-y1),2);
		double sum = x_calc + y_calc;
		double distance = Math.Round(Math.Sqrt(sum));
		var stringDistance = distance + "/500m";
		return stringDistance;

	}

	// Update is called once per frame
	void Update () {

		var time = getTime();
		var stringDistance = getDistance();
		name_text.text = stringDistance + "\n" + time;

	}
}
