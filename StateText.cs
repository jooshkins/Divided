using UnityEngine;
using UnityEngine.SceneManagement;

public class StateText : MonoBehaviour {
	
	public bool paused;

	void Start () {
		GetComponent<GUIText>().text = "Use your mouse to move. Go to the flashing green rectangle, press space to begin.";
		paused = true;
		Time.timeScale = 0;
	}

	void Update()
	{
		if ((Input.GetButtonDown ("Jump")) & (!(GetComponent<GUIText>().text == "You Win!"))) {
			GetComponent<GUIText>().text = "";
			paused = togglePause ();
		} 
		if ((!(GameObject.FindGameObjectWithTag ("Player"))) & (!(GetComponent<GUIText>().text == "You Win!"))) {
			GetComponent<GUIText>().text = "You Died!";
				if (Input.GetButtonDown ("Jump")) {
                Scene curscene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(curscene.buildIndex);
            }
		}
		if (GetComponent<GUIText>().text == "You Win!") {
			if (Input.GetButtonDown ("Jump")) {
                Scene curscene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(curscene.buildIndex + 1);
            }
		}
	}
	void OnGUI()
	{
		if ((paused) & (!(GetComponent<GUIText>().text == "Use your mouse to move. Go to the flashing green rectangle, press space to begin.")))
		{
			GetComponent<GUIText>().text = "Paused";
		}
	}
	bool togglePause()
	{
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
			return(true);
		}
	}
}
