using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class SaveDataController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SaveItemInfo();
	}

	// Update is called once per frame
	void Update () {

	}
	public void SaveItemInfo(){
		string path = null;
		path = "./data/saved_player.json";
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
