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

    public void AddEgg()
    {
        IToppingCommand command = new AddEggCommand(sandwichHandler.sandwich, this);
        AddCommand(command);
    }

    public void AddAvocado()
    {
        IToppingCommand command = new AddAvocadoCommand(sandwichHandler.sandwich, this);
        AddCommand(command);
    }

    public void AddHam()
    {
        IToppingCommand command = new AddHamCommand(sandwichHandler.sandwich, this);
        AddCommand(command);
    }

    public void AddCheese()
    {
        IToppingCommand command = new AddCheeseCommand(sandwichHandler.sandwich, this);
        AddCommand(command);
    }

    public void AddBBQSauce()
    {
        IToppingCommand command = new AddBBQSauceCommand(sandwichHandler.sandwich, this);
        AddCommand(command);
    }

    public void AddKetchup()
    {
        IToppingCommand command = new AddKetchupCommand(sandwichHandler.sandwich, this);
        AddCommand(command);
    }

    public void AddMayonnaise()
    {
        IToppingCommand command = new AddMayonnaiseCommand(sandwichHandler.sandwich, this);
        AddCommand(command);
    }

    public void AddTomato()
    {
        IToppingCommand command = new AddTomatoCommand(sandwichHandler.sandwich, this);
        AddCommand(command);
    }

    public void AddLettuce()
    {
        IToppingCommand command = new AddLettuceCommand(sandwichHandler.sandwich, this);
        AddCommand(command);
    }
}
