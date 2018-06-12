using UnityEngine;
using UnityEngine.SceneManagement;

public class CountLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int i = SceneManager.GetActiveScene().buildIndex;
        GetComponent<GUIText>().text = "1-" + i;
    }
}	
