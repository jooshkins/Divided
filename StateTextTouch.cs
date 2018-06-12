using UnityEngine;
using UnityEngine.SceneManagement;

public class StateTextTouch : MonoBehaviour
{
    public bool paused;
    public bool touched;

    void Start()
    {
        paused = false;
        Time.timeScale = 1f;
        touched = false;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touched = true;
        }

        if ((touched) & (!(GetComponent<GUIText>().text == "You Win!")))
        {
            GetComponent<GUIText>().text = "";
            Time.timeScale = 1f;
            paused = false;
        }
        
        if ((!(GameObject.FindGameObjectWithTag("Player"))) & (!(GetComponent<GUIText>().text == "You Win!")))
        {
            GetComponent<GUIText>().text = "You Died!";
            if (touched)
            {
                Scene curscene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(curscene.buildIndex);
            }
        }
        if (GetComponent<GUIText>().text == "You Win!")
        {
            if (touched)
            {
                int nxtlvl = SceneManager.GetActiveScene().buildIndex + 1;
                SaveLoad.Save();
                SceneManager.LoadScene(nxtlvl);
            }
        }
    }
}
