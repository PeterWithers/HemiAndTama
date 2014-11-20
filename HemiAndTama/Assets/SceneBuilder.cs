using UnityEngine;
using System.Collections;

public class SceneBuilder : MonoBehaviour {
    // Use this for initialization
    void Start () {
    	Transform spawnPoint = transform;
    	TextAsset gameLevelTxt = Resources.Load ("gamelevel") as TextAsset;
    	Debug.Log (gameLevelTxt.text);
    	int textIndex = 0;
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
            }
            textIndex++;
	}
    }

    private Transform instantiateGameObject (string name, Transform spawnPoint)
    {
    	print (name);
	GameObject instance = Instantiate (Resources.Load<GameObject> (name), spawnPoint.position, spawnPoint.rotation) as GameObject;
	return spawnPoint; //instance.GetComponentsInChildren<ConnectorPoint>().;
    }

// Update is called once per frame
    void Update () {
    }
}
