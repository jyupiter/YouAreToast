using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class CustomerGenerationScript : MonoBehaviour
{
    public TextMeshProUGUI displayName;
    public TextMeshProUGUI displaySprite;
    public TextMeshProUGUI displayOrder;
    public TextMeshProUGUI displayToastiness;
    public TextMeshProUGUI displayPatience;

    private List<string> nameList, spriteList, breadList, toppingList;

    private bool checkForCustomer;
    private int minPatience, maxPatience;
    private float randomPatience;
    private string toppings;

    private void Start()
    {
        checkForCustomer = false;
        minPatience = 30;
        maxPatience = 50;
        ReadNames();
        ReadSprites();
        ReadBread();
        ReadToppings();
    }
    private void Update()
    {
        if (checkForCustomer == false)
        {
            CreateCustomer();
        }
        else
        {
            PatienceMeter();
        }
    }
    void ReadNames()
    {
        //Read names.txt and load all names into namesList
        string[] names = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath, "names.txt"));
        nameList = new List<string>(names);
    }
    void ReadSprites()
    {
        //Read names.txt and load all names into namesList
        string[] sprites = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath, "sprites.txt"));
        spriteList = new List<string>(sprites);
    }
    void ReadBread()
    {
        //Read bread.txt and load all items into breadsList
        string[] breads = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath, "breads.txt"));
        breadList = new List<string>(breads);
    }
    void ReadToppings()
    {
        //Read items.txt and load all items into 2 different lists
        string[] toppings = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath, "toppings.txt"));
        toppingList = new List<string>(toppings);
    }
    public void CreateCustomer()
    {
        //randomly choose name
        System.Random r = new System.Random();
        int maxValue = nameList.Count;
        int randomValue = r. Next(0, maxValue);
        displayName.text = nameList[randomValue];

        //randomly choose sprite (how to only get default ones again?)
        //find all default sprites to another list and choose 1 from there??
        //how many lists is too many lists???
        int randomSprite = r.Next(0, spriteList.Count);
        displaySprite.text = spriteList[randomSprite];

        //randomise an order
        int randomBread = r.Next(0, breadList.Count);
        int randomToppingsNumber = r.Next(2, 7);
        toppings = "";
        for (int i = 0; i < randomToppingsNumber; i++)
        {
            int randomTopping = r.Next(0, toppingList.Count);
            toppings += toppingList[randomTopping].ToString();
            if(i < randomToppingsNumber - 1)
            {
                toppings += ", ";
            }
        }

        displayOrder.text = breadList[randomBread] + ", " + toppings;

        //decide a bread toastiness
        string[] toastLevels = new string[] { "cold clammy toast", "slightly warmed toast", "well toasted toast", "burnt toast please :)"};
        int randomToastLevel = r.Next(0, toastLevels.Length);
        displayToastiness.text = toastLevels[randomToastLevel];

        //assign a patience
        randomPatience = r.Next(minPatience, maxPatience);
        displayPatience.text = randomPatience.ToString();
        
        checkForCustomer = true;
    }



    //Stuff below here should be on customer prefab (i think)
    void PatienceMeter()
    {
        //drain patience
        if(randomPatience > 0)
        {
            randomPatience -= 1 * Time.deltaTime;
        }
        else
        {
            randomPatience = 0;
        }
        displayPatience.text = randomPatience.ToString();
    }
}
