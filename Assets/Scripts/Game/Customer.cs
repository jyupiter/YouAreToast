using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer
{
    // variables
    [SerializeField] private int minPatience = 30;
    [SerializeField] private int maxPatience = 50;

    private Patience patience;
    private string customerName = "";
    private Order order;

    private List<int> spritesToUse =
        new List<int>
        {
            0, // base
            0, // face (happy -> impatient -> upset)
            0, // glasses
            0, // hair
            0, // teeth
            0  // tie
        };

    private delegate void Notify(string message);
    private event Notify NotificationEvent;

    #region constructors

    public Customer()
    {
        order = null;
    }

    public Customer(string customerName, List<int> spritesToUse, Order order)
    {
        SetCustomerName(customerName);
        SetSpritesToUse(spritesToUse);
        SetOrder(order);
    }

    #endregion

    #region getters

    public string GetCustomerName()
    {
        return customerName;
    }

    public List<int> GetSpritesToUse()
    {
        return spritesToUse;
    }

    public Order GetOrder()
    {
        return order;
    }



    #endregion

    #region setters

    public void SetCustomerName(string customerName)
    {
        this.customerName = customerName;
    }

    public void SetSpritesToUse(List<int> spritesToUse)
    {
        this.spritesToUse = spritesToUse;
    }

    public void SetOrder(Order order)
    {
        this.order = order;
    }

    //TODO: make patience actually do things
    public void SetPatience() { }

    #endregion

    public static Customer GenerateCustomer()
    {
        List<string> names = FileIO.GetNameList();
        List<Sprite[]> sprites = FileIO.GetSpriteLists();

        //randomly choose name
        int randomValue = GameController.r.Next(0, names.Count);
        string name = names[randomValue];

        return new Customer(name, GenerateAppearance(sprites), Order.GenerateOrder());
    }

    private static List<int> GenerateAppearance(List<Sprite[]> sprites)
    {
        List<int> temp = new List<int> { 0, 0, 0, 0, 0, 0 };

        for(int i = 0; i < sprites.Count; i++)
        {
            if(i == 1)
                temp[i] = 0;
            else
                temp[i] = GameController.r.Next(0, sprites[i].Length);
        }

        return temp;
    }

    public static List<Sprite> IntsToSprites(List<int> spritesToUse, List<Sprite[]> sprites)
    {
        List<Sprite> temp = new List<Sprite>
        {
            sprites[0][spritesToUse[0]],
            sprites[1][spritesToUse[1]],
            sprites[2][spritesToUse[2]],
            sprites[3][spritesToUse[3]],
            sprites[4][spritesToUse[4]],
            sprites[5][spritesToUse[5]],
        };

        return temp;
    }
}
