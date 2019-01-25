﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {
	public Text answerText;
	public Text[] questionsText;

	enum Stat : byte {
		None,
		Cats,
		Dogs
	}

	class DialogQuestion {
		Stat linkedStat;
		public string[] questions;
		public List<DialogAnswer> answers;

		public DialogQuestion(Stat linkedStat, string[] questions, List<DialogAnswer> answers) {
			this.linkedStat = linkedStat;
			this.questions = questions;
			this.answers = answers;
		}
	}

	class DialogAnswer {
		public sbyte minRange, maxRange;
		public string answer;

		public DialogAnswer(sbyte min, sbyte max, string answer) {
			minRange = min;
			maxRange = max;
			this.answer = answer;
		}
	}

	List<DialogQuestion> dialogs = new List<DialogQuestion>() {
		new DialogQuestion(
			Stat.Cats, 
			new string[]{ 
				"Cat1",
				"Cat2",
				"Cat3",
				"Cat4",
				"Cat5",
			}, 
			new List<DialogAnswer>(){
				new DialogAnswer(-100,	-50,    "-100, -50"),
				new DialogAnswer(-49,	-1,     "-49,  -1"),
				new DialogAnswer(0,		0,		"0"),
				new DialogAnswer(1,		50,		"1, 50"),
				new DialogAnswer(51,	100,	"51, 100"),
			}
		),

		new DialogQuestion(
			Stat.Dogs,
			new string[]{
				"Dog1",
				"Dog2",
				"Dog3",
				"Dog4",
				"Dog5",
			},
			new List<DialogAnswer>(){
				new DialogAnswer(-100,  -50,    "-100, -50"),
				new DialogAnswer(-49,   -1,     "-49,  -1"),
				new DialogAnswer(0,     0,      "0"),
				new DialogAnswer(1,     50,     "1, 50"),
				new DialogAnswer(51,    100,    "51, 100"),
			}
		),

	};

	int choosedAnswer;

	void Start() {
		int[][] choosed = new int[questionsText.Length][];

		for(int i = 0; i < questionsText.Length; ++i){
			choosed[i] = new int[2];

			int choosedDialog = Random.Range(0, dialogs.Count);
			int choosedQuestion = Random.Range(0, dialogs[choosedDialog].questions.Length);

			questionsText[i].text = dialogs[choosedDialog].questions[choosedQuestion];
		}
	}

	void Update() {
		
	}

	public void ChooseQuestion(byte question){

	}

}