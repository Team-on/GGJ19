﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsHolder : MonoBehaviour {
	//Стати представлені статою і протилежною їй статою
	public enum Stat : sbyte {
		Cat,
		Dog,

		Nature,
		Tech,

		Order,
		Mess,

		FuturisticInteriorDesign,
		ClassicInteriorDesign,

		//PhysicalWork,
		//MentalWork,

		//Sport,
		//Alcohol,

		//Anime,
		//Serials,
		//Action,
		//Drama,
		//Mems,
		//serfing,
		//Meme,
		//Youtube,

		LAST_STAT
	}

	public sbyte[] Stats;

	public sbyte Tired;
	const sbyte initTired = 5;

	void Start() {
		Tired = initTired;
		Stats = new sbyte[(int)Stat.LAST_STAT];

		for (int i = 0; i < (int)Stat.LAST_STAT; i += 2) {
			sbyte r = (sbyte)Random.Range(-100, 101);
			Stats[i] = r;
			Stats[i + 1] = (sbyte)-r;
		}
		
	}

	public void FillForTutorial(){
		Stats[0] = 15;
		for (int i = 1; i < (int)StatsHolder.Stat.LAST_STAT; ++i)
			Stats[i] = 0;
	}

	public void GiveAnswer() {
		--Tired;
	}

	public sbyte GetStatValue(Stat stat) {
		return Stats[(int)stat];
	}

	public override string ToString() {
		string rez = "";

		for (int i = 0; i < (int)Stat.LAST_STAT; ++i)
			rez += ((Stat)(i)).ToString() + ": " + Stats[i] + "\n";
		rez += "Tired: " + Tired.ToString();

		return rez;
	}

	public bool IsHomeSatisfying(sbyte[] statsHome) {
		int satisfy = 0;

		for (int i = 0; i < (int)Stat.LAST_STAT; ++i) {
			if (Stats[i] > 0 && statsHome[i] >= Stats[i]) 
				++satisfy;
			else if (Stats[i] < 0 && statsHome[i] >= -Stats[i]) 
				--satisfy;
		}

		return satisfy > 0;
	}
}
