using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DisplayText : MonoBehaviour {

	public TextMesh name_text;

	private string testName = "moin";

  public float targetTime = 0.0f ;
  public int minutes = 0 ;
	// Use this for initialization
	void Start () {
		//time
		float translation = Time.deltaTime * 10;
    transform.Translate(0, 0, translation);

		var tmp = transform.position;
		print(tmp.x);
		name_text.text = "Position:"+ tmp.x + "Time:" + translation;

	}

	// Update is called once per frame
	void Update () {

		float translation = Time.deltaTime;
    // transform.Translate(0, 0, translation);

		targetTime += Time.deltaTime;
		if(targetTime > 60) {
			targetTime = 0.0f;
			minutes = minutes + 1;
		}
		decimal decimalValue = Math.Round((decimal)targetTime, 1);
		print(decimalValue);
		var tmp = transform.position;
		name_text.text = "Position:"+ tmp.x + "Time:"+minutes+ ":" + decimalValue;

	}
}
