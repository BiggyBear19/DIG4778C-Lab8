using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public TransformSaver Load()
    {
        //use path.combine to account for different os's having different path separators
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        TransformSaver loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                //serialize data from the file
                string dataToLoad = "";
                //specify filemode.open since we want to read from the file
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        //load the files text into the datatoload variable as a string
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                //deserialize the data from Json back to the c# object
                loadedData = JsonUtility.FromJson<TransformSaver>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when trying to load data from file: " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }

    public void Save(TransformSaver data)
    {
        //use path.combine to account for different os's having different path separators
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            //create the directory the file will be written to if it doesnt already exist
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //serialize the c# transformSaver object to json
            string dataToStore = JsonUtility.ToJson(data, true);

            //write the serialized data to the file
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error occured when trying to save data to file: " + fullPath + "\n" + e);
        }
    }

    public int LoadScore()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        int score = 0; 

        if (File.Exists(fullPath))
        {
            try
            {
                
                using (FileStream stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    score = reader.ReadInt32(); 
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"Error loading score from binary file: {fullPath}\n{e}");
            }
        }
        else
        {
            Debug.LogWarning($"Binary score file not found at: {fullPath}");
        }

        return score;
    }

    public void SaveScore(int data)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);

        try
        {
            string directoryPath = Path.GetDirectoryName(fullPath);
            if (!string.IsNullOrEmpty(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Use BinaryWriter to save the score
            using (FileStream stream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(data); // Write the integer score to the binary file
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error saving score to binary file: {fullPath}\n{e}");
        }
    }
}
