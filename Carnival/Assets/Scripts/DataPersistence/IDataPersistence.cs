using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence 
{
    void LoadData(TransformSaver data); //not ref because it's only reading the data
    void SaveData(ref TransformSaver data); //ref because it needs to modify the data
}
