using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;
using System.Text.RegularExpressions;

public class AMessageScriptRedone : MonoBehaviour 
{
	public KMAudio Audio;
	public KMBombInfo Bomb;
	public KMBombModule Module;
	
	public AudioClip[] SFX;

	public KMSelectable SendButton, SubmitButton;
	public KMSelectable[] Arrows;
	public SpriteRenderer[] TopRenderer, BottomRenderer;
	public SpriteRenderer Display;
	public Sprite[] Letters;
	public TextMesh[] StatusScreens;
	
	int[] RealNumbers = {0, 0, 0, 0, 0};
	int[] SequenceNumbers = {0, 0, 0, 0, 0};
	int TheCurrentNumber = 0;
	bool RightAnswer = true;
	bool Animating = false;
	
	int[] TheList = { 16, 14, 27, 15, 30, 2, 27, 15, 12, 20, 3, 18, 31, 17, 8, 4, 9, 10, 2, 27, 19, 6, 18, 27, 19, 20, 15, 2, 15, 13, 1, 31, 0, 22, 3, 25, 14, 18, 28, 9, 31, 21, 21, 4, 6, 12, 3, 21, 24, 27, 12, 12, 22, 8, 13, 26, 31, 20, 17, 19, 5, 29, 6, 4, 26, 26, 26, 6, 17, 27, 8, 14, 25, 24, 6, 10, 15, 16, 3, 25, 2, 21, 4, 30, 1, 25, 10, 16, 9, 12, 10, 1, 19, 21, 10, 30, 28, 30, 14, 18, 7, 29, 11, 24, 0, 20, 0, 22, 28, 26, 10, 5, 29, 12, 28, 6, 16, 5, 9, 5, 18, 24, 19, 8, 30, 26, 18, 23, 14, 0, 16, 9, 17, 26, 12, 24, 17, 3, 25, 15, 10, 8, 15, 1, 15, 10, 29, 27, 8, 6, 5, 26, 2, 26, 23, 23, 17, 8, 31, 12, 8, 5, 22, 3, 31, 22, 30, 9, 17, 24, 23, 30, 29, 10, 12, 22, 1, 25, 20, 22, 12, 18, 22, 7, 1, 30, 0, 19, 28, 24, 19, 2, 24, 24, 16, 26, 29, 12, 23, 5, 18, 0, 12, 15, 27, 2, 21, 18, 28, 27, 5, 10, 4, 27, 1, 30, 30, 13, 0, 29, 12, 21, 12, 16, 29, 6, 25, 7, 15, 4, 14, 11, 25, 29, 18, 10, 20, 17, 14, 15, 22, 21, 17, 28, 25, 14, 31, 16, 30, 18, 20, 20, 27, 16, 23, 29, 17, 24, 9, 5, 22, 8, 29, 12, 8, 16, 0, 20, 17, 25, 24, 10, 13, 12, 7, 9, 14, 1, 28, 1, 16, 17, 8, 30, 1, 30, 9, 27, 8, 24, 2, 27, 12, 15, 6, 17, 11, 1, 27, 8, 19, 15, 12, 30, 26, 30, 11, 25, 19, 3, 9, 10, 29, 20, 10, 25, 0, 6, 9, 20, 12, 12, 15, 29, 23, 6, 27, 18, 8, 8, 15, 11, 6, 20, 25, 3, 22, 4, 4, 25, 0, 26, 10, 11, 23, 16, 13, 12, 8, 18, 18, 12, 20, 1, 23, 14, 11, 30, 13, 25, 23, 2, 4, 29, 12, 17, 17, 18, 25, 10, 31, 3, 4, 20, 16, 7, 22, 10, 26, 14, 18, 9, 1, 26, 16, 23, 6, 22, 3, 31, 8, 15, 23, 30, 25, 4, 30, 24, 8, 0, 30, 20, 10, 17, 7, 15, 28, 9, 4, 13, 17, 4, 11, 27, 18, 2, 11, 29, 29, 18, 22, 10, 3, 20, 3, 5, 11, 8, 19, 27, 14, 10, 16, 10, 9, 31, 16, 9, 29, 31, 0, 20, 15, 24, 28, 19, 15, 2, 10, 0, 14, 13, 0, 23, 8, 4, 2, 29, 1, 26, 31, 5, 8, 0, 30, 26, 25, 25, 14, 14, 25, 7, 13, 28, 19, 6, 5, 2, 5, 2, 12, 31, 27, 17, 18, 23, 12, 5, 8, 8, 15, 10, 9, 29, 6, 14, 4, 27, 13, 22, 25, 0, 17, 3, 23, 19, 22, 25, 29, 14, 18, 15, 24, 25, 12, 22, 23, 3, 6, 27, 0, 14, 15, 11, 19, 31, 17, 10, 4, 3, 7, 5, 7, 25, 3, 5, 18, 13, 27, 29, 29, 7, 11, 26, 27, 16, 24, 19, 3, 31, 8, 31, 16, 15, 0, 11, 31, 22, 1, 2, 12, 14, 15, 9, 4, 1, 29, 7, 22, 23, 31, 13, 8, 28, 9, 20, 6, 11, 9, 9, 14, 5, 15, 4, 11, 22, 20, 3, 29, 26, 5, 1, 15, 12, 4, 15, 28, 20, 23, 20, 27, 0, 7, 17, 26, 8, 11, 13, 17, 30, 24, 31, 1, 29, 1, 0, 9, 22, 27, 5, 5, 24, 26, 23, 29, 22, 30, 10, 18, 28};
	
	//Logging
	static int moduleIdCounter = 1;
	int moduleId;
	private bool ModuleSolved;
	
	void Awake() 
	{
		moduleId = moduleIdCounter++;
		SendButton.OnInteract += delegate() { PressSendButton(); return false; };
		SubmitButton.OnInteract += delegate() { PressSubmitButton(); return false; };
		for (int k = 0; k < Arrows.Length; k++)
        {
            int Movement = k;
            Arrows[Movement].OnInteract += delegate
            {
                ArrowPress(Movement);
                return false;
            };
        }
	}
	
	void Start() 
	{	
		Module.OnActivate += ActivateModule;
	}
	
	void ActivateModule()
	{
		SequenceAndAnswer();
		Display.sprite = Letters[TheCurrentNumber];
		StartCoroutine(DisplayTime());
	}
	
	void SequenceAndAnswer()
	{
		int TheAnchor = UnityEngine.Random.Range(0, TheList.Count());
		int TheOrientation = UnityEngine.Random.Range(0, 2);
		
		if (TheAnchor >= 621 || (TheAnchor > 8 && TheAnchor < 621 && TheOrientation == 1))
		{
			for (int x = 0; x < 5; x++)
			{
				SequenceNumbers[x] = TheList[TheAnchor - x];
			}
			
			for (int y = 0; y < 5; y++)
			{
				RealNumbers[y] = TheList[TheAnchor - (y + 5)];
			}
		}
		
		else
		{
			for (int x = 0; x < 5; x++)
			{
				SequenceNumbers[x] = TheList[TheAnchor + x];
			}
			
			for (int y = 0; y < 5; y++)
			{
				RealNumbers[y] = TheList[TheAnchor + (y + 5)];
			}
		}
		Debug.LogFormat("[A Message #{0}] The initial sequence is {1}", moduleId, SequenceNumbers.Join(" "));
		Debug.LogFormat("[A Message #{0}] The continuation of the sequence is {1}", moduleId, RealNumbers.Join(" "));
	}
	
	IEnumerator DisplayTime()
	{
		for (int x = 0; x < 5; x++)
		{
			yield return new WaitForSecondsRealtime(0.6f);
			TopRenderer[x].sprite = Letters[SequenceNumbers[x]];
			Audio.PlaySoundAtTransform(SFX[2].name, transform);
		}
	}
	
	IEnumerator Inspection()
	{
		Animating = true;
		for (int x = 0; x < 5; x++)
		{
			if (BottomRenderer[x].sprite != Letters[RealNumbers[x]])
			{
				string[] pos = { "1st", "2nd", "3rd", "4th", "5th" };
				Debug.LogFormat("[A Message #{0}] The {1} font style sent for the continuation of the sequence was incorrect. Strike! Resetting...", moduleId, pos[x]);
				RightAnswer = false;
				break;
			}
		}
		if (RightAnswer)
			Debug.LogFormat("[A Message #{0}] All font styles sent for the continuation of the sequence were correct. Module solved!", moduleId);

		for (int x = 0; x < 5; x++)
		{
			yield return new WaitForSecondsRealtime(0.6f);
			TopRenderer[x].sprite = null;
			BottomRenderer[x].sprite = null;
			Audio.PlaySoundAtTransform(SFX[1].name, transform);
		}
		yield return new WaitForSecondsRealtime(0.6f);
		
		if (RightAnswer)
		{
			StartCoroutine(CorrectResponse());
		}
		
		else
		{
			StartCoroutine(IncorrectResponse());
		}
	}
	
	IEnumerator CorrectResponse()
	{
		yield return new WaitForSecondsRealtime(0.6f);
		string[] ModuleSolvedText = {"MODULE", "SOLVED"};
		for (int x = 0; x < 2; x++)
		{
			for (int y = 0; y < ModuleSolvedText[x].Length; y++)
			{
				StatusScreens[x].text += ModuleSolvedText[x][y].ToString();
				Audio.PlaySoundAtTransform(SFX[0].name, transform);
				yield return new WaitForSecondsRealtime(0.1f);
			}
		}
		Display.sprite = null;
		StatusScreens[2].text = "!";
		Module.HandlePass();
		ModuleSolved = true;
	}
	
	IEnumerator IncorrectResponse()
	{
		yield return new WaitForSecondsRealtime(0.6f);
		string[] ModuleSolvedText = {"TRY", "AGAIN"};
		for (int x = 0; x < 2; x++)
		{
			for (int y = 0; y < ModuleSolvedText[x].Length; y++)
			{
				StatusScreens[x].text += ModuleSolvedText[x][y].ToString();
				Audio.PlaySoundAtTransform(SFX[0].name, transform);
				yield return new WaitForSecondsRealtime(0.1f);
			}
		}
		yield return new WaitForSecondsRealtime(0.5f);
		StatusScreens[0].text = "";
		StatusScreens[1].text = "";
		Module.HandleStrike();
		ActivateModule();
		RightAnswer = true;
		Animating = false;
	}
	
	void PressSendButton()
	{
		SendButton.AddInteractionPunch(0.2f);
		if (!ModuleSolved && !Animating)
		{
			for (int x = 0; x < 5; x++)
			{
				if (BottomRenderer[x].sprite == null)
				{
					Debug.LogFormat("[A Message #{0}] Sent the font style {1}", moduleId, TheCurrentNumber);
					Audio.PlaySoundAtTransform(SFX[2].name, transform);
					BottomRenderer[x].sprite = Display.sprite;
					return;
				}
			}
			Audio.PlaySoundAtTransform(SFX[0].name, transform);
		}
	}
	
	void PressSubmitButton()
	{
		SubmitButton.AddInteractionPunch(0.2f);
		Audio.PlaySoundAtTransform(SFX[0].name, transform);
		if (!ModuleSolved && !Animating)
		{
			for (int x = 0; x < 5; x++)
			{
				if (BottomRenderer[x].sprite == null)
				{
					return;
				}	
			}
			Debug.LogFormat("[A Message #{0}] Pressed submit, verifying answer...", moduleId, TheCurrentNumber);
			StartCoroutine(Inspection());
		}
	}
	
	void ArrowPress(int Movement)
	{
		Arrows[Movement].AddInteractionPunch(0.2f);
		Audio.PlaySoundAtTransform(SFX[0].name, transform);
		if (!ModuleSolved)
		{
			if (Movement == 0)
			{
				TheCurrentNumber = ((TheCurrentNumber - 1) + 32) % 32;
				Display.sprite = Letters[TheCurrentNumber];
			}
			
			else
			{
				TheCurrentNumber = (TheCurrentNumber + 1) % 32;
				Display.sprite = Letters[TheCurrentNumber];
			}
		}
	}
	
	//twitch plays
    #pragma warning disable 414
    private readonly string TwitchHelpMessage = @"!{0} left/right (#) (slow) [Presses the left or right arrow (optionally '#' times and/or slow presses)] | !{0} send [Presses the send button] | !{0} submit [Presses the submit button]";
    #pragma warning restore 414
    IEnumerator ProcessTwitchCommand(string command)
    {
		string[] parameters = command.Split(' ');
		if (Regex.IsMatch(command, @"^\s*send\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            yield return null;
            SendButton.OnInteract();
            yield break;
        }
		
		if (Regex.IsMatch(command, @"^\s*submit\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            yield return null;
			for (int x = 0; x < 5; x++)
			{
				if (BottomRenderer[x].sprite == null)
				{
					yield return "sendtochaterror Pressing submit will only work when 5 letters have been sent!";
					yield break;
				}
			}
			yield return "strike";
			yield return "solve";
            SubmitButton.OnInteract();
        }
		
		if (Regex.IsMatch(parameters[0], @"^\s*left\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            yield return null;
			if (parameters.Length == 1)
            {
                Arrows[0].OnInteract();
            }
			
			else if (parameters.Length == 2)
            {
                int temp;
                bool check = int.TryParse(parameters[1], out temp);
				if (!check)
                {
                    yield return "sendtochaterror!f The specified number of times to press the left button '" + parameters[1] + "' is not a number!";
                    yield break;
                }
				
				if (temp < 1 || temp > 32)
                {
                    yield return "sendtochaterror The specified number of times to press the left button '" + parameters[1] + "' is under 1 or over 32!";
                    yield break;
                }
				
				for (int i = 0; i < temp; i++)
                {
                    Arrows[0].OnInteract();
                    yield return new WaitForSecondsRealtime(0.1f);
                }
			}
			
			else if (parameters.Length == 3)
            {
                int temp;
                bool check = int.TryParse(parameters[1], out temp);
				if (!check)
                {
                    yield return "sendtochaterror!f The specified number of times to press the left button '" + parameters[1] + "' is not a number!";
                    yield break;
                }
				
				if (temp < 1 || temp > 32)
                {
                    yield return "sendtochaterror The specified number of times to press the left button '" + parameters[1] + "' is under 1 or over 32!";
                    yield break;
                }
				
				if (!Regex.IsMatch(parameters[2], @"^\s*slow\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
                {
                    yield return "sendtochaterror!f A third parameter is only valid if it's 'slow'! Your parameter: '" + parameters[2] + "'.";
                    yield break;
                }
				
				for (int i = 0; i < temp; i++)
                {
                    Arrows[0].OnInteract();
					yield return "trycancel Halted slow button presses due to a request to cancel!";
					yield return new WaitForSecondsRealtime(1f);
                }
			}
			
			else if (parameters.Length > 3)
            {
                yield return "sendtochaterror Too many parameters!";
            }
		}
		
		if (Regex.IsMatch(parameters[0], @"^\s*right\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            yield return null;
			if (parameters.Length == 1)
            {
                Arrows[1].OnInteract();
            }
			
			else if (parameters.Length == 2)
            {
                int temp;
                bool check = int.TryParse(parameters[1], out temp);
				if (!check)
                {
                    yield return "sendtochaterror!f The specified number of times to press the left button '" + parameters[1] + "' is not a number!";
                    yield break;
                }
				
				if (temp < 1 || temp > 32)
                {
                    yield return "sendtochaterror The specified number of times to press the left button '" + parameters[1] + "' is under 1 or over 32!";
                    yield break;
                }
				
				for (int i = 0; i < temp; i++)
                {
                    Arrows[1].OnInteract();
                    yield return new WaitForSecondsRealtime(0.1f);
                }
			}
			
			else if (parameters.Length == 3)
            {
                int temp;
                bool check = int.TryParse(parameters[1], out temp);
				if (!check)
                {
                    yield return "sendtochaterror!f The specified number of times to press the left button '" + parameters[1] + "' is not a number!";
                    yield break;
                }
				
				if (temp < 1 || temp > 32)
                {
                    yield return "sendtochaterror The specified number of times to press the left button '" + parameters[1] + "' is under 1 or over 32!";
                    yield break;
                }
				
				if (!Regex.IsMatch(parameters[2], @"^\s*slow\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
                {
                    yield return "sendtochaterror!f A third parameter is only valid if it's 'slow'! Your parameter: '" + parameters[2] + "'.";
                    yield break;
                }
				
				for (int i = 0; i < temp; i++)
                {
                    Arrows[1].OnInteract();
					yield return "trycancel Halted slow button presses due to a request to cancel!";
                    yield return new WaitForSecondsRealtime(1f);
                }
			}
			
			else if (parameters.Length > 3)
            {
                yield return "sendtochaterror Too many parameters!";
            }
		}
	}
	
	IEnumerator TwitchHandleForcedSolve()
    {
		int ct = 5;
		for (int x = 0; x < 5; x++)
		{
			if (BottomRenderer[x].sprite == null)
			{
				ct = x;
				break;
			}
		}
		for (int x = 0; x < ct; x++)
		{
			if (BottomRenderer[x].sprite != Letters[RealNumbers[x]])
			{
				StopAllCoroutines();
				Animating = true;
				for (int q = 0; q < 5; q++)
				{
					TopRenderer[q].sprite = null;
					BottomRenderer[q].sprite = null;
				}
				string[] ModuleSolvedText = { "MODULE", "SOLVED" };
				for (int t = 0; t < 2; t++)
				{
					for (int y = 0; y < ModuleSolvedText[t].Length; y++)
					{
						StatusScreens[t].text += ModuleSolvedText[t][y].ToString();
						Audio.PlaySoundAtTransform(SFX[0].name, transform);
						yield return new WaitForSecondsRealtime(0.1f);
					}
				}
				Display.sprite = null;
				StatusScreens[2].text = "!";
				Module.HandlePass();
				ModuleSolved = true;
				yield break;
			}
		}
		if (!Animating)
		{
			for (int x = ct; x < 5; x++)
			{
				int left = TheCurrentNumber;
				int right = TheCurrentNumber;
				int ct1 = 0;
				int ct2 = 0;
				while (left != RealNumbers[x])
				{
					left--;
					if (left < 0)
						left = 31;
					ct1++;
				}
				while (right != RealNumbers[x])
				{
					right++;
					if (right > 31)
						right = 0;
					ct2++;
				}
				if (ct1 < ct2)
				{
					for (int i = 0; i < ct1; i++)
					{
						Arrows[0].OnInteract();
						yield return new WaitForSecondsRealtime(0.1f);
					}
				}
				else if (ct1 > ct2)
				{
					for (int i = 0; i < ct2; i++)
					{
						Arrows[1].OnInteract();
						yield return new WaitForSecondsRealtime(0.1f);
					}
				}
				else
				{
					int rando = UnityEngine.Random.Range(0, 2);
					for (int i = 0; i < ct2; i++)
					{
						if (rando == 0)
							Arrows[0].OnInteract();
						else
							Arrows[1].OnInteract();
						yield return new WaitForSecondsRealtime(0.1f);
					}
				}
				SendButton.OnInteract();
				yield return new WaitForSeconds(0.1f);
			}
			SubmitButton.OnInteract();
		}
		while (!ModuleSolved) { yield return true; }
	}
}