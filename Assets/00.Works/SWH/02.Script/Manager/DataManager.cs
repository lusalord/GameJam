using UnityEngine;
using System.IO;

public class DataManager
{
    string _fileName = "\\data.txt";
    string path;
    public void Init()
    {
        path = Application.persistentDataPath;
        path.Replace('/', '\\');
        path = Application.persistentDataPath + _fileName;
        FileStream fs = File.Open(path, FileMode.OpenOrCreate);


        fs.Close();
    }
}
