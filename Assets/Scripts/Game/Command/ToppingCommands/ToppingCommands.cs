using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Order;

public abstract class AddToppingCommand
{
    protected SandwichHandler sandwichHandler;
    protected ToppingHandler toppingHandler;
    protected Topping topping;

    public AddToppingCommand(SandwichHandler sandwichHandler, ToppingHandler toppingHandler, Topping topping)
    {
        this.sandwichHandler = sandwichHandler;
        this.toppingHandler = toppingHandler;
        this.topping = topping;
    }

    public void Execute()
    {
        Redo();
        toppingHandler.AddCommand((IToppingCommand) this);
    }

    public void Redo()
    {
        if(sandwichHandler.sandwichState != SandwichHandler.SandwichState.complete)
            return;
        sandwichHandler.sandwich.AddTopping(topping);
        Refresh();
    }

    public void Undo()
    {
        if(sandwichHandler.sandwichState != SandwichHandler.SandwichState.complete)
            return;
        sandwichHandler.sandwich.RemoveTopping();
        Refresh();
    }

    private void Refresh()
    {
        GameObject sandwichObject = sandwichHandler.sandwichObject;
        List<GameObject> children = new List<GameObject>();

        foreach(Transform t in sandwichObject.transform)
            children.Add(t.gameObject);

        sandwichHandler.UpdateToppingsSprites(sandwichHandler.sandwich, children);
    }
}

#region individual topping commands, inheriting from the abstract parent

public class AddEggCommand : AddToppingCommand, IToppingCommand
{
    public AddEggCommand(SandwichHandler sandwichHandler, ToppingHandler toppingHandler, Topping topping) : base(sandwichHandler, toppingHandler, topping)
    {
        this.sandwichHandler = sandwichHandler;
        this.toppingHandler = toppingHandler;
        this.topping = topping;
    }
}

public class AddAvocadoCommand : AddToppingCommand, IToppingCommand
{
    public AddAvocadoCommand(SandwichHandler sandwichHandler, ToppingHandler toppingHandler, Topping topping) : base(sandwichHandler, toppingHandler, topping)
    {
        this.sandwichHandler = sandwichHandler;
        this.toppingHandler = toppingHandler;
        this.topping = topping;
    }
}

public class AddHamCommand : AddToppingCommand, IToppingCommand
{
    public AddHamCommand(SandwichHandler sandwichHandler, ToppingHandler toppingHandler, Topping topping) : base(sandwichHandler, toppingHandler, topping)
    {
        this.sandwichHandler = sandwichHandler;
        this.toppingHandler = toppingHandler;
        this.topping = topping;
    }
}

public class AddCheeseCommand : AddToppingCommand, IToppingCommand
{
    public AddCheeseCommand(SandwichHandler sandwichHandler, ToppingHandler toppingHandler, Topping topping) : base(sandwichHandler, toppingHandler, topping)
    {
        this.sandwichHandler = sandwichHandler;
        this.toppingHandler = toppingHandler;
        this.topping = topping;
    }
}

public class AddBBQSauceCommand : AddToppingCommand, IToppingCommand
{
    public AddBBQSauceCommand(SandwichHandler sandwichHandler, ToppingHandler toppingHandler, Topping topping) : base(sandwichHandler, toppingHandler, topping)
    {
        this.sandwichHandler = sandwichHandler;
        this.toppingHandler = toppingHandler;
        this.topping = topping;
    }
}

public class AddKetchupCommand : AddToppingCommand, IToppingCommand
{
    public AddKetchupCommand(SandwichHandler sandwichHandler, ToppingHandler toppingHandler, Topping topping) : base(sandwichHandler, toppingHandler, topping)
    {
        this.sandwichHandler = sandwichHandler;
        this.toppingHandler = toppingHandler;
        this.topping = topping;
    }
}

public class AddMayonnaiseCommand : AddToppingCommand, IToppingCommand
{
    public AddMayonnaiseCommand(SandwichHandler sandwichHandler, ToppingHandler toppingHandler, Topping topping) : base(sandwichHandler, toppingHandler, topping)
    {
        this.sandwichHandler = sandwichHandler;
        this.toppingHandler = toppingHandler;
        this.topping = topping;
    }
}

public class AddTomatoCommand : AddToppingCommand, IToppingCommand
{
    public AddTomatoCommand(SandwichHandler sandwichHandler, ToppingHandler toppingHandler, Topping topping) : base(sandwichHandler, toppingHandler, topping)
    {
        this.sandwichHandler = sandwichHandler;
        this.toppingHandler = toppingHandler;
        this.topping = topping;
    }
}

public class AddLettuceCommand : AddToppingCommand, IToppingCommand
{
    public AddLettuceCommand(SandwichHandler sandwichHandler, ToppingHandler toppingHandler, Topping topping) : base(sandwichHandler, toppingHandler, topping)
    {
        this.sandwichHandler = sandwichHandler;
        this.toppingHandler = toppingHandler;
        this.topping = topping;
    }
}

#endregion