using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Datacontroller : MonoBehaviour 
{
	public RoundData[] allRoundData;


	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad (gameObject);

		SceneManager.LoadScene ("zscenemenuscreen");
	}

	public RoundData GetCurrentRoundData()
	{
		return allRoundData [0];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
