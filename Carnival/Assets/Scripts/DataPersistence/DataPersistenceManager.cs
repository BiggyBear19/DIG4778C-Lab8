using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File storage config")]
    [SerializeField] private string fileName;

    private TransformSaver transformSaver;
    private List<IDataPersistence> dataPersistenceObjects;

    //Gets instance publicly but can only be edited it privately in this class
    public static DataPersistenceManager instance { get; private set; }
    private FileDataHandler dataHandler;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one data persistence manager in scene");
        }
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        //Initialize transformSaver by making a new transformSaver object
        this.transformSaver = new TransformSaver();
    }

    public void LoadGame()
    {
        //load saved data from a file using data handler
        this.transformSaver = dataHandler.Load();
        

        //if no data loaded, make a new game
        if (this.transformSaver == null)
        {
            Debug.Log("No data was found. Initializing data to defaults");
            NewGame();
        }

        //push the loaded data to all other scripts that need it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(transformSaver);
        }
        Debug.Log("Loaded transform = " + transformSaver.playerTransform);
    }

    public void SaveGame()
    {
        //pass data to other scripts to update
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref transformSaver);
        }
        Debug.Log("Saved transform = " + transformSaver.playerTransform);

        //save that data to a file using the data handler
        dataHandler.Save(transformSaver);
    }

    private void OnApplicationQuit()
    {
        //SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        //Find all instances in a given scene
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
