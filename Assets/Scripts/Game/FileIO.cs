using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileIO : MonoBehaviour
{
    private static List<string> nameList, spriteList;
    private List<string> ReadTextDataToList(string textFileInput)
    {
        string[] data =
        File.ReadAllLines
        (
            Path.Combine
            (
                Application.streamingAssetsPath,
                textFileInput
            )
        );
        return new List<string>(data);
    }

    private void PopulateLists()
    {
        nameList = ReadTextDataToList("names.txt");
        spriteList = ReadTextDataToList("sprites.txt");
    }

    void Start()
    {
        PopulateLists();
    }

    public static List<string> GetNameList()
    {
        return nameList;
    }

    public static List<string> GetSpriteList()
    {
        return spriteList;
    }
}
