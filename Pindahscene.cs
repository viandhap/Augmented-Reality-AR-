using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;

public class Pindahscene : MonoBehaviour
{
	public float scalingSpeed = 0.03f;
	public float rotationSpeed = 70.0f;
	public float translationSpeed = 5.0f;
	//	public GameObject Model;


	public void CloseAppButton ()
	{
		Application.Quit ();
	}

	public void LoadScene(string scenename){
		SceneManager.LoadScene (scenename);
	}
		
}