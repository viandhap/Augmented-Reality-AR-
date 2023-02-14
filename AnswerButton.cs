using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class AnswerButton : MonoBehaviour {

	public Text answerText;

	private AnswerData answerData;
	private SoalController soalController;

	// Use this for initialization
	void Start () 
	{
		soalController = FindObjectOfType<SoalController> ();
	}
	
	public void Setup(AnswerData data)
	{
		answerData = data;
		answerText.text = answerData.answerText;
	}


	public void HandleClick()
	{
		soalController.AnswerButtonClicked (answerData.isCorrect);
	}
}
