using UnityEngine;
using System.Diagnostics;

public class Timer : MonoBehaviour {

	private Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
	private GUIText stateText;
	
	void Awake () {
		stateText = GameObject.Find("State_Text_GUI").GetComponent<GUIText>();
	}

	void Update () {
		if ((stateText.text == "You Died!") || (stateText.text == "You Win!") || (stateText.text == "Paused") || (stateText.text == "Touch to began. Go to the green rectangle.")) {
			stopWatch.Stop();
		} 
		else {
			stopWatch.Start();
			string timerText = string.Format("{0:00}:{1:00}.{2:00}",
			                                 stopWatch.Elapsed.Minutes, stopWatch.Elapsed.Seconds,
			                                 stopWatch.Elapsed.Milliseconds / 10);
			GetComponent<GUIText>().text = timerText;
		}
	}
}
