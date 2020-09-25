using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager; 
    [SerializeField] private CountComet countComet;

    [SerializeField] private string filePath;

    public static SaveManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        gameManager = FindObjectOfType<GameManager>();   
        countComet = FindObjectOfType<CountComet>();
        filePath = Application.persistentDataPath + "data.gamesave";

        LoadGame();
        SaveGame();
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Create);

        Save save = new Save();
        save.coins = gameManager.coins;
        save.bestPoint = gameManager.bestPoint;
        save.isSound = gameManager.isSound;
        save.timeInPlay = gameManager.timeInPlay;
        save.countComet = countComet.countComet;
        bf.Serialize(fs, save);
        fs.Close();
    }

    public void LoadGame()
    {
        if (!File.Exists(filePath))
        {
            return;
        }


        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);

        Save save = (Save)bf.Deserialize(fs);

        gameManager.coins = save.coins;
        gameManager.bestPoint = save.bestPoint;
        gameManager.isSound = save.isSound;
        gameManager.timeInPlay = save.timeInPlay;
        countComet.countComet = save.countComet;

        fs.Close();

        gameManager.RefreshText();
    }

}

[System.Serializable]
public class Save
{
    public int coins;
    public int bestPoint;
    public bool isSound;
    public float timeInPlay;
    public int countComet;

}