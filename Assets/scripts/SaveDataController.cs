using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class SaveDataController : MonoBehaviour {

	// Use this for initialization
	public void Data(string speed, int time)
    {
        Speed = speed;
        Time = time;
    }
	void Start () {
		SaveItemInfo();
	}

	// Update is called once per frame
	void Update () {

	}
	public void SaveItemInfo(){
		string path = null;
		path = "./Assets/data/saved_player.json";
		Data savedData = new Data("20",10);

		// string str = ItemInfo.ToString();
		string str = "{moin:hey}";
		using (FileStream fs = new FileStream(path, FileMode.Create)){
				using (StreamWriter writer = new StreamWriter(fs)){
						writer.Write(str);
				}
		}
		UnityEditor.AssetDatabase.Refresh ();
}

}
