using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingHandler : MonoBehaviour
{
    public SandwichHandler sandwichHandler;

    public List<IToppingCommand> toppingCommands = new List<IToppingCommand>();
    private int index;

    public void AddCommand(IToppingCommand command)
    {
        toppingCommands.Add(command);
        index = toppingCommands.Count - 1;
    }

    public void IterateCommands(bool undo)
    {
        if(undo == true)
        {
            toppingCommands[index].Undo();
            index--;
            if(index < 0)
                index = 0;
        }
        else
        {
            toppingCommands[index].Redo();
            index++;
            if(index >= toppingCommands.Count)
                index = toppingCommands.Count - 1;
        }
    }

    #region methods to link to buttons in the scene

    public void AddEgg()
    {
        IToppingCommand command = new AddEggCommand(sandwichHandler, this, Order.Topping.egg);
        command.Execute();
    }

    public void AddAvocado()
    {
        IToppingCommand command = new AddAvocadoCommand(sandwichHandler, this, Order.Topping.avocado);
        command.Execute();
    }

    public void AddHam()
    {
        IToppingCommand command = new AddHamCommand(sandwichHandler, this, Order.Topping.ham);
        command.Execute();
    }

    public void AddCheese()
    {
        IToppingCommand command = new AddCheeseCommand(sandwichHandler, this, Order.Topping.cheese);
        command.Execute();
    }

    public void AddBBQSauce()
    {
        IToppingCommand command = new AddBBQSauceCommand(sandwichHandler, this, Order.Topping.bbq_sauce);
        command.Execute();
    }

    public void AddKetchup()
    {
        IToppingCommand command = new AddKetchupCommand(sandwichHandler, this, Order.Topping.ketchup);
        command.Execute();
    }

    public void AddMayonnaise()
    {
        IToppingCommand command = new AddMayonnaiseCommand(sandwichHandler, this, Order.Topping.mayonnaise);
        command.Execute();
    }

    public void AddTomato()
    {
        IToppingCommand command = new AddTomatoCommand(sandwichHandler, this, Order.Topping.tomato);
        command.Execute();
    }

    public void AddLettuce()
    {
        IToppingCommand command = new AddLettuceCommand(sandwichHandler, this, Order.Topping.lettuce);
        command.Execute();
    }

    #endregion
}
