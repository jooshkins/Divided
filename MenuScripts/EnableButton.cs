using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class EnableButton : MonoBehaviour {
    public int lvl;

	void Start () {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            int highestlvl = (int)bf.Deserialize(file);
            file.Close();

            if (highestlvl >= lvl)
            {
                GetComponent<Button>().interactable = true;
            }

            else
            {
                GetComponent<Button>().interactable = false;
            }
        }
    }
}
