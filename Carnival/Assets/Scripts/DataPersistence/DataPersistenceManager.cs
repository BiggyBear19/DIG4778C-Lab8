using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    private GameData gameData;

    //Gets instance publicly but can only be edited it privately in this class
    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one data persistence manager in scene");
        }
        instance = this;
    }

    private void Start()
    {
        LoadGame();
    }

    public void NewGame()
    {
        //Initialize gameData by making a new GameData object
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //load saved data from a file using data handler

        //if no data loaded, make a new game
        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initializing data to defaults");
        }
    }

    public void SaveGame()
    {
        //pass data to other scripts to update
        //save that data to a file using the data handler
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
