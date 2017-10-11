using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;


public class PlayerInfo
{
    public float x;
    public float y;
    public float z;

    public static PlayerInfo CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<PlayerInfo>(jsonString);
    }
}

public class SaveDataController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// SaveItemInfo();
	}

	// Update is called once per frame
	void Update () {

	}
	public void writeData(List<PlayerInfo> array) {
		string path1 = null;
		path1 = "./Assets/data/saved_player.json";
		using (StreamWriter sw = new StreamWriter(path1))
            {
                foreach (PlayerInfo obj in array)
                {
                    sw.WriteLine(JsonUtility.ToJson(obj));
                }
            }
		UnityEditor.AssetDatabase.Refresh ();
	}
	public List<PlayerInfo> readData() {
		string path1 = "./Assets/data/saved_player.json";
		const Int32 BufferSize = 128;
		PlayerInfo player = new PlayerInfo();
		List<PlayerInfo> array = new List<PlayerInfo>();
		//PlayerInfo[] array = {};
		int counter = 0;
		using (var fileStream = File.OpenRead(path1))
		  using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize)) {
				for (var i = 0; i<99999; i++){
					string read_line = streamReader.ReadLine();
					if (read_line != null){
						player = PlayerInfo.CreateFromJSON(read_line);
						array.Add(player);
					} else {
						i = 99999;
					}
				}
		  }
		return array;
	}
	public void SaveItemInfo(){
		string path = null;
		string str = "";
		path = "./Assets/data/saved_player.json";
		PlayerInfo myObject = new PlayerInfo();
		myObject.x = 1.0f;
		myObject.y = 2.0f;
		myObject.z = 3.0f;
		List<PlayerInfo> array = new List<PlayerInfo>();
		array.Add(myObject);
		array.Add(myObject);
		writeData(array);
		readData();
}

}
