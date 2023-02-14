﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoalController : MonoBehaviour {


	public Text questionText;
	public Text scoreDisplayText;
	public SimpleObjectPool answerButtonObjectPool;
	public Transform answerButtonParent;
	public GameObject questionDisplay;
	public GameObject roundEndDisplay;

	private Datacontroller dataController;
	private RoundData currentRoundData;
	private QuestionData[] questionPool;

	private bool isRoundActive;
	private int questionIndex;
	private int playerScore;
	private List<GameObject> answerButtonGameObjects = new List<GameObject>();

	// Use this for initialization
	void Start () 
	{
		dataController = FindObjectOfType<Datacontroller> ();
		currentRoundData = dataController.GetCurrentRoundData ();
		questionPool = currentRoundData.questions;

		playerScore = 0;
		questionIndex = 0;

		ShowQuestion ();
		isRoundActive = true;

	}

	private void ShowQuestion()
	{
		RemoveAnswerButtons ();
		QuestionData questionData = questionPool [questionIndex];
		questionText.text = questionData.questionText;

		for (int i = 0; i < questionData.answers.Length; i++) 
		{
			GameObject answerButtonGameObject = answerButtonObjectPool.GetObject ();
			answerButtonGameObject.transform.SetParent (answerButtonParent);
			answerButtonGameObjects.Add (answerButtonGameObject);

			AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton> ();
			answerButton.Setup (questionData.answers [i]);
		}
	}
	private void RemoveAnswerButtons()
	{
		while (answerButtonGameObjects.Count > 0) 
		{
			answerButtonObjectPool.ReturnObject (answerButtonGameObjects [0]);
			answerButtonGameObjects.RemoveAt (0);
		}
	}

	public void AnswerButtonClicked(bool isCorrect)
	{
		if (isCorrect) 
		{
			playerScore += currentRoundData.pointAddedForCorrectAnswer;
			scoreDisplayText.text = "Score : " + playerScore.ToString ();
		}

		if (questionPool.Length > questionIndex + 1) {
			questionIndex++;
			ShowQuestion ();
		} else 
		{
			EndRound ();
		}
	}

	public void EndRound()
	{
		isRoundActive = false;

		questionDisplay.SetActive (false);
		roundEndDisplay.SetActive (true);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
