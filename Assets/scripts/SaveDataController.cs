using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;


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

	public static MyClass CreateFromJSON(string jsonString)
	 {
			 return JsonUtility.FromJson<MyClass>(jsonString);
	 }

	public void writeData(Array array) {
		string path1 = null;
		path1 = "./Assets/data/saved_player.json";
		using (StreamWriter sw = new StreamWriter(path1))
            {
                foreach (MyClass obj in array)
                {
                    sw.WriteLine(JsonUtility.ToJson(obj));
                }
            }
		UnityEditor.AssetDatabase.Refresh ();
	}
	public Array readData() {
		string path1 = null;
		const Int32 BufferSize = 128;
		MyClass obj = null;
		MyClass[] array = {};
		path1 = "./Assets/data/saved_player1.json";
		using (var fileStream = File.OpenRead(path1))
		  using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize)) {
		    String line;
		    while ((line = streamReader.ReadLine()) != null)
					print(line.GetType());
					obj = JsonUtility.FromJson<MyClass>(line);
					print(CreateFromJSON(line));
		  }
		return array;
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
		writeData(array);
		readData();
}

}
