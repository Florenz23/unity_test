using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


public class SaveDataController : MonoBehaviour {

		public class MyClass{
	    public int level;
	    public float timeElapsed;
	    public string playerName;
	}

	// Use this for initialization
	void Start () {
		SaveItemInfo();
	}

	// Update is called once per frame
	void Update () {

	}
	public void SaveItemInfo(){
		string path = null;
		string str = "";
		path = "./Assets/data/saved_player.json";
		MyClass myObject = new MyClass();
		myObject.level = 1;
		myObject.timeElapsed = 47.5f;
		myObject.playerName = "Dr Charles Francis";
		MyClass[] array = {myObject,myObject};

		for (int i=0; i<array.Length; i++){
			str = str + JsonUtility.ToJson(array[i]);
		}

		// string str = "{moin:hey}";
		using (FileStream fs = new FileStream(path, FileMode.Create)){
				using (StreamWriter writer = new StreamWriter(fs)){
						writer.Write(str);
						writer.Write(str);
				}
		}
		UnityEditor.AssetDatabase.Refresh ();
}

}
