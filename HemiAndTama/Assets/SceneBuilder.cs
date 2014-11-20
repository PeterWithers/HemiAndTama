using UnityEngine;
using System.Collections;

public class SceneBuilder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Transform spawnPoint = transform;
		TextAsset gameLevelTxt= Resources.Load("gamelevel") as TextAsset;
		Debug.Log(gameLevelTxt.text);

		//string[] lines = System.IO.File.ReadAllLines(file);
		//foreach (string line in lines){
		if (gameLevelTxt.text.StartsWith("B")){
				//Rigidbody clone = Instantiate(starPrefab, spawnPoint.position, spawnPoint.rotation) as Rigidbody;
				//spawnPoint = clone.transform;	
//			GameObject instance = Instantiate(Resources.Load("Base", typeof(GameObject)));
			GameObject instance = Instantiate(Resources.Load<GameObject>("Base")) as GameObject;
			print("B");
		} else if (gameLevelTxt.text.StartsWith("M")){
			print("M");
		} else if (gameLevelTxt.text.StartsWith("L")){
			print("L");
		} else if (gameLevelTxt.text.StartsWith("T")){
			print("T");
		} else if (gameLevelTxt.text.StartsWith("I")){
			print("I");
			}
/*		for (int i = 0; i < lines.Length; i++)  {
			string[] stringsOfLine = Regex.Split(lines[i], " ");
			levelBase[i] = stringsOfLine;
		}
		return levelBase;
*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
