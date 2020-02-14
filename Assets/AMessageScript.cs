using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;

public class AMessageScript : MonoBehaviour 
{
	public KMAudio Audio;
	public KMBombInfo Bomb;
	public KMBombModule Module;
	
	public AudioClip[] SFX;

	public KMSelectable SendButton;
	public KMSelectable SubmitButton;
	public KMSelectable LeftArrow;
	public KMSelectable RightArrow;
	
	public TextMesh[] SelectionDisplayLetters;
	public TextMesh[] LowerFirstLetter;
	public TextMesh[] LowerSecondLetter;
	public TextMesh[] LowerThirdLetter;
	public TextMesh[] LowerFourthLetter;
	public TextMesh[] LowerFifthLetter;
	public TextMesh[] UpperFirstLetter;
	public TextMesh[] UpperSecondLetter;
	public TextMesh[] UpperThirdLetter;
	public TextMesh[] UpperFourthLetter;
	public TextMesh[] UpperFifthLetter;
	
	public TextMesh[] StatusScreens;
	
	private int TheCurrentNumber = 0;
	
	private int FirstSelectionNumber = 0;
	private int SecondSelectionNumber = 0;
	private int ThirdSelectionNumber = 0;
	private int FourthSelectionNumber = 0;
	private int FifthSelectionNumber = 0;
	
	private int FirstSequence = 0;
	private int SecondSequence = 0;
	private int ThirdSequence = 0;
	private int FourthSequence = 0;
	private int FifthSequence = 0;
	
	private int FirstRealAnswer = 0;
	private int SecondRealAnswer = 0;
	private int ThirdRealAnswer = 0;
	private int FourthRealAnswer = 0;
	private int FifthRealAnswer = 0;
	
	private int TheAnswer = 0;
	private int TheChoice = 0;
	
	private int[] TheList = { 16, 14, 27, 15, 30, 2, 27, 15, 12, 20, 3, 18, 31, 17, 8, 4, 9, 10, 2, 27, 19, 6, 18, 27, 19, 20, 15, 2, 15, 13, 1, 31, 0, 22, 3, 25, 14, 18, 28, 9, 31, 21, 21, 4, 6, 12, 3, 21, 24, 27, 12, 12, 22, 8, 13, 26, 31, 20, 17, 19, 5, 29, 6, 4, 26, 26, 26, 6, 17, 27, 8, 14, 25, 24, 6, 10, 15, 16, 3, 25, 2, 21, 4, 30, 1, 25, 10, 16, 9, 12, 10, 1, 19, 21, 10, 30, 28, 30, 14, 18, 7, 29, 11, 24, 0, 20, 0, 22, 28, 26, 10, 5, 29, 12, 28, 6, 16, 5, 9, 5, 18, 24, 19, 8, 30, 26, 18, 23, 14, 0, 16, 9, 17, 26, 12, 24, 17, 3, 25, 15, 10, 8, 15, 1, 15, 10, 29, 27, 8, 6, 5, 26, 2, 26, 23, 23, 17, 8, 31, 12, 8, 5, 22, 3, 31, 22, 30, 9, 17, 24, 23, 30, 29, 10, 12, 22, 1, 25, 20, 22, 12, 18, 22, 7, 1, 30, 0, 19, 28, 24, 19, 2, 24, 24, 16, 26, 29, 12, 23, 5, 18, 0, 12, 15, 27, 2, 21, 18, 28, 27, 5, 10, 4, 27, 1, 30, 30, 13, 0, 29, 12, 21, 12, 16, 29, 6, 25, 7, 15, 4, 14, 11, 25, 29, 18, 10, 20, 17, 14, 15, 22, 21, 17, 28, 25, 14, 31, 16, 30, 18, 20, 20, 27, 16, 23, 29, 17, 24, 9, 5, 22, 8, 29, 12, 8, 16, 0, 20, 17, 25, 24, 10, 13, 12, 7, 9, 14, 1, 28, 1, 16, 17, 8, 30, 1, 30, 9, 27, 8, 24, 2, 27, 12, 15, 6, 17, 11, 1, 27, 8, 19, 15, 12, 30, 26, 30, 11, 25, 19, 3, 9, 10, 29, 20, 10, 25, 0, 6, 9, 20, 12, 12, 15, 29, 23, 6, 27, 18, 8, 8, 15, 11, 6, 20, 25, 3, 22, 4, 4, 25, 0, 26, 10, 11, 23, 16, 13, 12, 8, 18, 18, 12, 20, 1, 23, 14, 11, 30, 13, 25, 23, 2, 4, 29, 12, 17, 17, 18, 25, 10, 31, 3, 4, 20, 16, 7, 22, 10, 26, 14, 18, 9, 1, 26, 16, 23, 6, 22, 3, 31, 8, 15, 23, 30, 25, 4, 30, 24, 8, 0, 30, 20, 10, 17, 7, 15, 28, 9, 4, 13, 17, 4, 11, 27, 18, 2, 11, 29, 29, 18, 22, 10, 3, 20, 3, 5, 11, 8, 19, 27, 14, 10, 16, 10, 9, 31, 16, 9, 29, 31, 0, 20, 15, 24, 28, 19, 15, 2, 10, 0, 14, 13, 0, 23, 8, 4, 2, 29, 1, 26, 31, 5, 8, 0, 30, 26, 25, 25, 14, 14, 25, 7, 13, 28, 19, 6, 5, 2, 5, 2, 12, 31, 27, 17, 18, 23, 12, 5, 8, 8, 15, 10, 9, 29, 6, 14, 4, 27, 13, 22, 25, 0, 17, 3, 23, 19, 22, 25, 29, 14, 18, 15, 24, 25, 12, 22, 23, 3, 6, 27, 0, 14, 15, 11, 19, 31, 17, 10, 4, 3, 7, 5, 7, 25, 3, 5, 18, 13, 27, 29, 29, 7, 11, 26, 27, 16, 24, 19, 3, 31, 8, 31, 16, 15, 0, 11, 31, 22, 1, 2, 12, 14, 15, 9, 4, 1, 29, 7, 22, 23, 31, 13, 8, 28, 9, 20, 6, 11, 9, 9, 14, 5, 15, 4, 11, 22, 20, 3, 29, 26, 5, 1, 15, 12, 4, 15, 28, 20, 23, 20, 27, 0, 7, 17, 26, 8, 11, 13, 17, 30, 24, 31, 1, 29, 1, 0, 9, 22, 27, 5, 5, 24, 26, 23, 29, 22, 30, 10, 18, 28};

	private int RankNumber = 0;
	
	private bool SolvedStatus = false;

	//Logging
	static int moduleIdCounter = 1;
	int moduleId;
	private bool ModuleSolved;

	void Awake() 
	{
		moduleId = moduleIdCounter++;
		SendButton.OnInteract += delegate() { PressSendButton(); return false; };
		SubmitButton.OnInteract += delegate() { PressSubmitButton(); return false; };
		LeftArrow.OnInteract += delegate() { PressLeftArrow(); return false; };
		RightArrow.OnInteract += delegate() { PressRightArrow(); return false; };
		
	}
	
	void Start() 
	{	
		Module.OnActivate += ActivateModule;
	}
	
	void ActivateModule()
	{
		SequenceAndAnswer();
		MyDisplay();
		StartCoroutine(DisplayTime());
	}
	
	void SequenceAndAnswer()
	{
		TheAnswer = UnityEngine.Random.Range(0, TheList.Count());
		TheChoice = UnityEngine.Random.Range(0, 2);
		
		if (TheAnswer >= 621)
		{	
			FirstSequence = TheList[TheAnswer];
			SecondSequence = TheList[TheAnswer - 1];
			ThirdSequence = TheList[TheAnswer - 2];
			FourthSequence = TheList[TheAnswer - 3];
			FifthSequence = TheList[TheAnswer - 4];
			FirstRealAnswer = TheList[TheAnswer - 5];
			SecondRealAnswer = TheList[TheAnswer - 6];
			ThirdRealAnswer = TheList[TheAnswer - 7];
			FourthRealAnswer = TheList[TheAnswer - 8];
			FifthRealAnswer = TheList[TheAnswer - 9];
		}
		else if (TheAnswer <= 8)
		{
			FirstSequence = TheList[TheAnswer];
			SecondSequence = TheList[TheAnswer + 1];
			ThirdSequence = TheList[TheAnswer + 2];
			FourthSequence = TheList[TheAnswer + 3];
			FifthSequence = TheList[TheAnswer + 4];
			FirstRealAnswer = TheList[TheAnswer + 5];
			SecondRealAnswer = TheList[TheAnswer + 6];
			ThirdRealAnswer = TheList[TheAnswer + 7];
			FourthRealAnswer = TheList[TheAnswer + 8];
			FifthRealAnswer = TheList[TheAnswer + 9];
		}
		else
		{
			if (TheChoice == 0)
			{
				FirstSequence = TheList[TheAnswer];
				SecondSequence = TheList[TheAnswer + 1];
				ThirdSequence = TheList[TheAnswer + 2];
				FourthSequence = TheList[TheAnswer + 3];
				FifthSequence = TheList[TheAnswer + 4];
				FirstRealAnswer = TheList[TheAnswer + 5];
				SecondRealAnswer = TheList[TheAnswer + 6];
				ThirdRealAnswer = TheList[TheAnswer + 7];
				FourthRealAnswer = TheList[TheAnswer + 8];
				FifthRealAnswer = TheList[TheAnswer + 9];
			}
			else 
			{
				FirstSequence = TheList[TheAnswer];
				SecondSequence = TheList[TheAnswer - 1];
				ThirdSequence = TheList[TheAnswer - 2];
				FourthSequence = TheList[TheAnswer - 3];
				FifthSequence = TheList[TheAnswer - 4];
				FirstRealAnswer = TheList[TheAnswer - 5];
				SecondRealAnswer = TheList[TheAnswer - 6];
				ThirdRealAnswer = TheList[TheAnswer - 7];
				FourthRealAnswer = TheList[TheAnswer - 8];
				FifthRealAnswer = TheList[TheAnswer - 9];
			}
		}
		
	}
	
	void MyDisplay()
	{
		SelectionDisplayLetters[TheCurrentNumber].text = "A";
	}
	
	void FirstTime()
	{
		UpperFirstLetter[FirstSequence].text = "A";
		UpperSecondLetter[SecondSequence].text = "A";
		UpperThirdLetter[ThirdSequence].text = "A";
		UpperFourthLetter[FourthSequence].text = "A";
		UpperFifthLetter[FifthSequence].text = "A";
	}
	
	void FirstChain()
	{
		FirstSelectionNumber = FirstSelectionNumber + TheCurrentNumber;
		Audio.PlaySoundAtTransform(SFX[1].name, transform);
		LowerFirstLetter[FirstSelectionNumber].text = "A";
		RankNumber = RankNumber + 1;
	}
	
	void SecondChain()
	{
		SecondSelectionNumber = SecondSelectionNumber + TheCurrentNumber;
		Audio.PlaySoundAtTransform(SFX[1].name, transform);
		LowerSecondLetter[SecondSelectionNumber].text = "A";
		RankNumber = RankNumber + 1;
	}
	
	void ThirdChain()
	{
		ThirdSelectionNumber = ThirdSelectionNumber + TheCurrentNumber;
		Audio.PlaySoundAtTransform(SFX[1].name, transform);
		LowerThirdLetter[ThirdSelectionNumber].text = "A";
		RankNumber = RankNumber + 1;
	}
	
	void FourthChain()
	{
		FourthSelectionNumber = FourthSelectionNumber + TheCurrentNumber;
		Audio.PlaySoundAtTransform(SFX[1].name, transform);
		LowerFourthLetter[FourthSelectionNumber].text = "A";
		RankNumber = RankNumber + 1;
	}
	
	void FifthChain()
	{
		FifthSelectionNumber = FifthSelectionNumber + TheCurrentNumber;
		Audio.PlaySoundAtTransform(SFX[1].name, transform);
		LowerFifthLetter[FifthSelectionNumber].text = "A";
		RankNumber = RankNumber + 1;
	}
	
	void PressLeftArrow()
	{
		if (SolvedStatus == true)
		{
			LeftArrow.AddInteractionPunch(0.2f);
			Audio.PlaySoundAtTransform(SFX[0].name, transform);
		}
		
		else if (SolvedStatus == false)
		{
			LeftArrow.AddInteractionPunch(0.2f);
			Audio.PlaySoundAtTransform(SFX[0].name, transform);
			SelectionDisplayLetters[TheCurrentNumber].text = "";
			TheCurrentNumber = ((TheCurrentNumber - 1) + 32) % 32;
			MyDisplay();
		}
    }

	void PressRightArrow()
	{
		if (SolvedStatus == true)
		{
			RightArrow.AddInteractionPunch(0.2f);
			Audio.PlaySoundAtTransform(SFX[0].name, transform);
		}
		
		else if (SolvedStatus == false)
		{
			RightArrow.AddInteractionPunch(0.2f);
			Audio.PlaySoundAtTransform(SFX[0].name, transform);
			SelectionDisplayLetters[TheCurrentNumber].text = "";
			TheCurrentNumber = (TheCurrentNumber + 1) % 32;
			MyDisplay();
			
		}
    }
	
	void PressSendButton()
	{
		if (SolvedStatus == true)
		{
			SendButton.AddInteractionPunch(0.2f);
			Audio.PlaySoundAtTransform(SFX[0].name, transform);
		}
		
		else if (SolvedStatus == false)
		{
			SendButton.AddInteractionPunch(0.2f);
			if (RankNumber == 0)
			{
				FirstChain();
			}
			else if (RankNumber == 1)
			{
				SecondChain();
			}
			else if (RankNumber == 2)
			{
				ThirdChain();
			}
			else if (RankNumber == 3)
			{
				FourthChain();
			}
			else if (RankNumber == 4)
			{
				FifthChain();
			}
			else
			{
				Audio.PlaySoundAtTransform(SFX[0].name, transform);
				SendButton.AddInteractionPunch(0.2f);
			}
		}
	}

	void PressSubmitButton()
	{
		if (SolvedStatus == true)
		{
			SubmitButton.AddInteractionPunch(0.2f);
			Audio.PlaySoundAtTransform(SFX[0].name, transform);
		}
		
		else if (SolvedStatus == false)
		{
			SubmitButton.AddInteractionPunch(0.2f);
			if (RankNumber != 5)
			{
				Audio.PlaySoundAtTransform(SFX[0].name, transform);
			}
		
		
			else
			{	
				Audio.PlaySoundAtTransform(SFX[0].name, transform);
				StartCoroutine(Inspection());
				RankNumber = RankNumber + 1;
			}
		}
	}
	
	void AnswerGathering()
	{
		if (!ModuleSolved)
			{
				if (FirstSelectionNumber == FirstRealAnswer && SecondSelectionNumber == SecondRealAnswer && ThirdSelectionNumber == ThirdRealAnswer && FourthSelectionNumber == FourthRealAnswer && FifthSelectionNumber == FifthRealAnswer)
				{
					StartCoroutine(CorrectResponse());
				}
				else
				{
					StartCoroutine(IncorrectResponse());
				}
			}
	}
	
	IEnumerator DisplayTime()
	{
		yield return new WaitForSeconds(0.6f);
		UpperFirstLetter[FirstSequence].text = "A";
		Audio.PlaySoundAtTransform(SFX[1].name, transform);
		yield return new WaitForSeconds(0.6f);
		UpperSecondLetter[SecondSequence].text = "A";
		Audio.PlaySoundAtTransform(SFX[1].name, transform);
		yield return new WaitForSeconds(0.6f);
		UpperThirdLetter[ThirdSequence].text = "A";
		Audio.PlaySoundAtTransform(SFX[1].name, transform);
		yield return new WaitForSeconds(0.6f);
		UpperFourthLetter[FourthSequence].text = "A";
		Audio.PlaySoundAtTransform(SFX[1].name, transform);
		yield return new WaitForSeconds(0.6f);
		UpperFifthLetter[FifthSequence].text = "A";
		Audio.PlaySoundAtTransform(SFX[1].name, transform);
	}
	
	IEnumerator Inspection()
	{
		yield return new WaitForSeconds(0.6f);
		LowerFirstLetter[FirstSelectionNumber].text = "";
		UpperFirstLetter[FirstSequence].text = "";
		Audio.PlaySoundAtTransform(SFX[2].name, transform);
		yield return new WaitForSeconds(0.6f);
		LowerSecondLetter[SecondSelectionNumber].text = "";
		UpperSecondLetter[SecondSequence].text = "";
		Audio.PlaySoundAtTransform(SFX[2].name, transform);
		yield return new WaitForSeconds(0.6f);
		LowerThirdLetter[ThirdSelectionNumber].text = "";
		UpperThirdLetter[ThirdSequence].text = "";
		Audio.PlaySoundAtTransform(SFX[2].name, transform);
		yield return new WaitForSeconds(0.6f);
		LowerFourthLetter[FourthSelectionNumber].text = "";
		UpperFourthLetter[FourthSequence].text = "";
		Audio.PlaySoundAtTransform(SFX[2].name, transform);
		yield return new WaitForSeconds(0.6f);
		LowerFifthLetter[FifthSelectionNumber].text = "";
		UpperFifthLetter[FifthSequence].text = "";
		Audio.PlaySoundAtTransform(SFX[2].name, transform);
		yield return new WaitForSeconds(0.6f);
		AnswerGathering();
	}
		
		
	IEnumerator CorrectResponse()
	{
		yield return new WaitForSeconds(0.6f);
		StatusScreens[0].text = "M";
		Audio.PlaySoundAtTransform(SFX[0].name, transform);
		yield return new WaitForSeconds(0.1f);
		StatusScreens[0].text = "MO";
		Audio.PlaySoundAtTransform(SFX[0].name, transform);
		yield return new WaitForSeconds(0.1f);
		StatusScreens[0].text = "MOD";
		Audio.PlaySoundAtTransform(SFX[0].name, transform);
		yield return new WaitForSeconds(0.1f);
		StatusScreens[0].text = "MODU";
		Audio.PlaySoundAtTransform(SFX[0].name, transform);
		yield return new WaitForSeconds(0.1f);
		StatusScreens[0].text = "MODUL";
		Audio.PlaySoundAtTransform(SFX[0].name, transform);
		yield return new WaitForSeconds(0.1f);
		StatusScreens[0].text = "MODULE";
		Audio.PlaySoundAtTransform(SFX[0].name, transform);
		yield return new WaitForSeconds(0.1f);
		StatusScreens[1].text = "S";
		Audio.PlaySoundAtTransform(SFX[0].name, transform);
		yield return new WaitForSeconds(0.1f);
		StatusScreens[1].text = "SO";
		Audio.PlaySoundAtTransform(SFX[0].name, transform);
		yield return new WaitForSeconds(0.1f);
		StatusScreens[1].text = "SOL";
		Audio.PlaySoundAtTransform(SFX[0].name, transform);
		yield return new WaitForSeconds(0.1f);
		StatusScreens[1].text = "SOLV";
		Audio.PlaySoundAtTransform(SFX[0].name, transform);
		yield return new WaitForSeconds(0.1f);
		StatusScreens[1].text = "SOLVE";
		Audio.PlaySoundAtTransform(SFX[0].name, transform);
		yield return new WaitForSeconds(0.1f);
		StatusScreens[1].text = "SOLVED";
		Audio.PlaySoundAtTransform(SFX[0].name, transform);
		SelectionDisplayLetters[TheCurrentNumber].text = "";
		StatusScreens[2].text = "!";
		Module.HandlePass();
		SolvedStatus = true;
	}	
		
	IEnumerator IncorrectResponse()
	{
		yield return new WaitForSeconds(0.6f);
		StatusScreens[0].text = "T";
		Audio.PlaySoundAtTransform(SFX[0].name, transform);
		yield return new WaitForSeconds(0.1f);
		StatusScreens[0].text = "TR";
		Audio.PlaySoundAtTransform(SFX[0].name, transform);
		yield return new WaitForSeconds(0.1f);
		StatusScreens[0].text = "TRY";
		Audio.PlaySoundAtTransform(SFX[0].name, transform);
		yield return new WaitForSeconds(0.1f);
		StatusScreens[1].text = "A";
		Audio.PlaySoundAtTransform(SFX[0].name, transform);
		yield return new WaitForSeconds(0.1f);
		StatusScreens[1].text = "AG";
		Audio.PlaySoundAtTransform(SFX[0].name, transform);
		yield return new WaitForSeconds(0.1f);
		StatusScreens[1].text = "AGA";
		Audio.PlaySoundAtTransform(SFX[0].name, transform);
		yield return new WaitForSeconds(0.1f);
		StatusScreens[1].text = "AGAI";
		Audio.PlaySoundAtTransform(SFX[0].name, transform);
		yield return new WaitForSeconds(0.1f);
		StatusScreens[1].text = "AGAIN";
		Audio.PlaySoundAtTransform(SFX[0].name, transform);
		yield return new WaitForSeconds(0.5f);
		StatusScreens[0].text = "";
		StatusScreens[1].text = "";
		Module.HandleStrike();
		Reset();
	}

	void Reset()
	{
		LowerFirstLetter[FirstSelectionNumber].text = "";
		LowerSecondLetter[SecondSelectionNumber].text = "";
		LowerThirdLetter[ThirdSelectionNumber].text = "";
		LowerFourthLetter[FourthSelectionNumber].text = "";
		LowerFifthLetter[FifthSelectionNumber].text = "";
		
		UpperFirstLetter[FirstSequence].text = "";
		UpperSecondLetter[SecondSequence].text = "";
		UpperThirdLetter[ThirdSequence].text = "";
		UpperFourthLetter[FourthSequence].text = "";
		UpperFifthLetter[FifthSequence].text = "";
		
		FirstSelectionNumber = 0;
		SecondSelectionNumber = 0;
		ThirdSelectionNumber = 0;
		FourthSelectionNumber = 0;
		FifthSelectionNumber = 0;
	
		FirstSequence = 0;
		SecondSequence = 0;
		ThirdSequence = 0;
		FourthSequence = 0;
		FifthSequence = 0;
	
		FirstRealAnswer = 0;
		SecondRealAnswer = 0;
		ThirdRealAnswer = 0;
		FourthRealAnswer = 0;
		FifthRealAnswer = 0;
		
		FirstSelectionNumber = 0;
		SecondSelectionNumber = 0;
		ThirdSelectionNumber = 0;
		FourthSelectionNumber = 0;
		FifthSelectionNumber = 0;
	
		TheAnswer = 0;
		TheChoice = 0;
		
		RankNumber = 0;
		
		ActivateModule();
	}
}
