using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileIO : MonoBehaviour
{
    private static List<string> nameList;
    private static Sprite[] baseArr, faceArr, glassesArr, hairArr, teethArr, tieArr;
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
        baseArr = Resources.LoadAll<Sprite>("Art/NPC/Base");
        faceArr = Resources.LoadAll<Sprite>("Art/NPC/Face");
        glassesArr = Resources.LoadAll<Sprite>("Art/NPC/Glasses");
        hairArr = Resources.LoadAll<Sprite>("Art/NPC/Hair");
        teethArr = Resources.LoadAll<Sprite>("Art/NPC/Teeth");
        tieArr = Resources.LoadAll<Sprite>("Art/NPC/Tie");
    }

    void Start()
    {
        PopulateLists();
    }

    public static List<string> GetNameList()
    {
        return nameList;
    }

    public static List<Sprite[]> GetSpriteLists()
    {
        return new List<Sprite[]> { baseArr, faceArr, glassesArr, hairArr, teethArr, tieArr };
    }
}
