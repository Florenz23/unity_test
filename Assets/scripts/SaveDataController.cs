using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;


public class PlayerInfo
{
    public string name;
    public int lives;
    public float health;

    public static PlayerInfo CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<PlayerInfo>(jsonString);
    }
}

public class SaveDataController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SaveItemInfo();
		string test = "{\"name\":\"Dr Charles\",\"lives\":3,\"health\":0.8}";
		PlayerInfo player = new PlayerInfo();
		PlayerInfo moin = PlayerInfo.CreateFromJSON(test);
	}

	// Update is called once per frame
	void Update () {

	}
	public void writeData(Array array) {
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
		string path1 = "./Assets/data/saved_player1.json";
		const Int32 BufferSize = 128;
		PlayerInfo player = new PlayerInfo();
		List<PlayerInfo> array = new List<PlayerInfo>();
		//PlayerInfo[] array = {};
		int counter = 0;
		using (var fileStream = File.OpenRead(path1))
		  using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize)) {
						string read_line = "";
				for (var i = 0; i<99999; i++){
					read_line = streamReader.ReadLine();
					if (read_line != null){
						player = PlayerInfo.CreateFromJSON(read_line);
						array.Add(player);
					} else {
						i = 99999;
					}
				}
		  }
		print(array.Count);
		return array;
	}
	public void SaveItemInfo(){
		string path = null;
		string str = "";
		path = "./Assets/data/saved_player.json";
		PlayerInfo myObject = new PlayerInfo();
		myObject.lives = 1;
		myObject.health = 47.5f;
		myObject.name = "Dr Charles Francis";
		PlayerInfo[] array = {myObject,myObject};
		writeData(array);
		// readData();
}

}
