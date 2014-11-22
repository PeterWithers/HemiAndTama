using UnityEngine;
using System.Collections;

public class SceneBuilder : MonoBehaviour {
    int textIndex = 0;
    TextAsset gameLevelTxt;
    // Use this for initialization
    void Start () {
    	Transform spawnPoint = transform;
    	gameLevelTxt = Resources.Load ("gamelevel") as TextAsset;
    	Debug.Log (gameLevelTxt.text);
    	while (textIndex < gameLevelTxt.text.Length) {
			if (gameLevelTxt.text [textIndex] == 'B') {
					spawnPoint = instantiateGameObject ("Base", spawnPoint);
			} else if (gameLevelTxt.text [textIndex] == 'M') {
					spawnPoint = instantiateGameObject ("mezzanine", spawnPoint);
			} else if (gameLevelTxt.text [textIndex] == 'L') {
					spawnPoint = instantiateGameObject ("Tube 90 container", spawnPoint);
			} else if (gameLevelTxt.text [textIndex] == 'T') {
					spawnPoint = instantiateGameObject ("Tee tube", spawnPoint);
			} else if (gameLevelTxt.text [textIndex] == 'I') {
					spawnPoint = instantiateGameObject ("Tube container", spawnPoint);
			} else {
                            break;
			}
		}
    }

    private Transform instantiateGameObject (string name, Transform spawnPoint) {
		textIndex++;
    	print (name);
	GameObject instance = Instantiate (Resources.Load<GameObject> (name), spawnPoint.position, spawnPoint.rotation) as GameObject;
		instance.transform.Rotate(Vector3.up * getRotation());
		return instance.GetComponentsInChildren<SceneContinuation>()[0].getSpawnPoint();
    }

	private int getRotation() {
		int returnValue = 0;
		int numberIndex = 0;
			while (gameLevelTxt.text[textIndex + numberIndex] <= '9') {
			numberIndex++;
		}
		if (numberIndex > 0) {
			returnValue = (int)System.Convert.ToDecimal (gameLevelTxt.text.Substring(textIndex, numberIndex));
			textIndex += numberIndex;
		}
		return returnValue;
	}

// Update is called once per frame
    void Update () {
    }
}
