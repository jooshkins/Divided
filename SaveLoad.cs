using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SaveLoad {

    private static int highestlvl;

    public static void Save()
    {
        int curlvl = SceneManager.GetActiveScene().buildIndex + 1;

        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bfload = new BinaryFormatter();
            FileStream fileload = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            int highestlvl = (int)bfload.Deserialize(fileload);
            fileload.Close();

            if (curlvl >= highestlvl)
            {
                BinaryFormatter bfwrite = new BinaryFormatter();
                FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
                bfwrite.Serialize(file, curlvl);
                file.Close();
            }
        }
        else
        {
            BinaryFormatter bfwrite = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
            bfwrite.Serialize(file, curlvl);
            file.Close();
        }
    }
}
