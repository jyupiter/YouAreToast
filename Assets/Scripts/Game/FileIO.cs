using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static Order;

public class FileIO : MonoBehaviour
{
    private static List<string> nameList;
    private static Sprite[] baseArr, faceArr, glassesArr, hairArr, teethArr, tieArr, briocheArr, bagelArr, englishMuffinArr, toppingsArr;
    
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
        briocheArr = Resources.LoadAll<Sprite>("Art/Breads/Brioche");
        bagelArr = Resources.LoadAll<Sprite>("Art/Breads/Bagel");
        englishMuffinArr = Resources.LoadAll<Sprite>("Art/Breads/English_Muffin");
        toppingsArr = Resources.LoadAll<Sprite>("Art/Toppings");
    }

    void Awake()
    {
        PopulateLists();
    }

    public static List<string> GetNameList()
    {
        return nameList;
    }

    public static List<Sprite[]> GetCustomerSpriteLists()
    {
        return new List<Sprite[]> { baseArr, faceArr, glassesArr, hairArr, teethArr, tieArr };
    }

    public static Sprite[] GetBriocheSprites()
    {
        return briocheArr;
    }

    public static Sprite[] GetBagelSprites()
    {
        return bagelArr;
    }

    public static Sprite[] GetEnglishMuffinSprites()
    {
        return englishMuffinArr;
    }

    public static Sprite[] GetToppingsSprites()
    {
        return toppingsArr;
    }

    public static Sprite[] GetToppingsSprites(Stack<Topping> toppings, int count)
    {

        Sprite[] output = new Sprite[count];

        if(count < 1)
            return output;

        Topping[] temp = toppings.ToArray();

        for(int i = 0; i < toppings.Count; i++)
        {
            output[i] = ToppingNameToSprite(GetToppingsSprites(), temp[i]);
        }

        return output;
    }

    private static Sprite ToppingNameToSprite(Sprite[] toppingSprites, Topping topping)
    {
        Sprite output = null;
        string toppingName = topping.ToString();

        foreach(Sprite s in toppingSprites)
        {
            if(s.name.ToLower() == toppingName)
            {
                output = s;
                break;
            }
        }

        return output;
    }
}
