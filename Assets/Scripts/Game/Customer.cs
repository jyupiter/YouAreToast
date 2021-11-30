using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    // variables
    [SerializeField] private int minPatience = 30;
    [SerializeField] private int maxPatience = 50;

    private float randomPatience = 0;
    private string customerName = "";
    private string sprite = ""; //TODO: make sprite actually sprite(s) and not a string
    private Order order;

    private delegate void Notify(string message);
    private event Notify NotificationEvent;

    #region constructors

    public Customer()
    {
        order = null;
    }

    public Customer(string customerName, string sprite, Order order)
    {
        SetCustomerName(customerName);
        SetSprite(sprite);
        SetOrder(order);
    }

    #endregion

    #region getters

    public string GetCustomerName()
    {
        return customerName;
    }

    public string GetSprite()
    {
        return sprite;
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

    public void SetSprite(string sprite)
    {
        this.sprite = sprite;
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
        List<string> sprites = FileIO.GetSpriteList();

        //randomly choose name
        int randomValue = GameController.r.Next(0, names.Count);
        string name = names[randomValue];

        //randomly choose sprite
        randomValue = GameController.r.Next(0, sprites.Count);
        string sprite = sprites[randomValue];

        return new Customer(name, sprite, Order.GenerateOrder());
    }
}
