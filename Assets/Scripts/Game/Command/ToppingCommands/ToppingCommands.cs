using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEggCommand : IToppingCommand
{
    Sandwich sandwich;
    ToppingHandler toppingHandler;

    public AddEggCommand(Sandwich sandwich, ToppingHandler toppingHandler)
    {
        this.sandwich = sandwich;
        this.toppingHandler = toppingHandler;
    }

    public void Execute()
    {
        sandwich.AddTopping(Order.Topping.egg);
        toppingHandler.AddCommand(this);
    }

    public void Redo()
    {
        sandwich.AddTopping(Order.Topping.egg);
    }

    public void Undo()
    {
        sandwich.RemoveTopping();
    }
}

public class AddAvocadoCommand : IToppingCommand
{
    Sandwich sandwich;
    ToppingHandler toppingHandler;

    public AddAvocadoCommand(Sandwich sandwich, ToppingHandler toppingHandler)
    {
        this.sandwich = sandwich;
        this.toppingHandler = toppingHandler;
    }

    public void Execute()
    {
        sandwich.AddTopping(Order.Topping.avocado);
        toppingHandler.AddCommand(this);
    }

    public void Redo()
    {
        sandwich.AddTopping(Order.Topping.avocado);
    }

    public void Undo()
    {
        sandwich.RemoveTopping();
    }
}

public class AddHamCommand : IToppingCommand
{
    Sandwich sandwich;
    ToppingHandler toppingHandler;

    public AddHamCommand(Sandwich sandwich, ToppingHandler toppingHandler)
    {
        this.sandwich = sandwich;
        this.toppingHandler = toppingHandler;
    }

    public void Execute()
    {
        sandwich.AddTopping(Order.Topping.ham);
        toppingHandler.AddCommand(this);
    }

    public void Redo()
    {
        sandwich.AddTopping(Order.Topping.ham);
    }

    public void Undo()
    {
        sandwich.RemoveTopping();
    }
}

public class AddCheeseCommand : IToppingCommand
{
    Sandwich sandwich;
    ToppingHandler toppingHandler;

    public AddCheeseCommand(Sandwich sandwich, ToppingHandler toppingHandler)
    {
        this.sandwich = sandwich;
        this.toppingHandler = toppingHandler;
    }

    public void Execute()
    {
        sandwich.AddTopping(Order.Topping.cheese);
        toppingHandler.AddCommand(this);
    }

    public void Redo()
    {
        sandwich.AddTopping(Order.Topping.cheese);
    }

    public void Undo()
    {
        sandwich.RemoveTopping();
    }
}

public class AddBBQSauceCommand : IToppingCommand
{
    Sandwich sandwich;
    ToppingHandler toppingHandler;

    public AddBBQSauceCommand(Sandwich sandwich, ToppingHandler toppingHandler)
    {
        this.sandwich = sandwich;
        this.toppingHandler = toppingHandler;
    }

    public void Execute()
    {
        sandwich.AddTopping(Order.Topping.bbq_sauce);
        toppingHandler.AddCommand(this);
    }

    public void Redo()
    {
        sandwich.AddTopping(Order.Topping.bbq_sauce);
    }

    public void Undo()
    {
        sandwich.RemoveTopping();
    }
}

public class AddKetchupCommand : IToppingCommand
{
    Sandwich sandwich;
    ToppingHandler toppingHandler;

    public AddKetchupCommand(Sandwich sandwich, ToppingHandler toppingHandler)
    {
        this.sandwich = sandwich;
        this.toppingHandler = toppingHandler;
    }

    public void Execute()
    {
        sandwich.AddTopping(Order.Topping.ketchup);
        toppingHandler.AddCommand(this);
    }

    public void Redo()
    {
        sandwich.AddTopping(Order.Topping.ketchup);
    }

    public void Undo()
    {
        sandwich.RemoveTopping();
    }
}

public class AddMayonnaiseCommand : IToppingCommand
{
    Sandwich sandwich;
    ToppingHandler toppingHandler;

    public AddMayonnaiseCommand(Sandwich sandwich, ToppingHandler toppingHandler)
    {
        this.sandwich = sandwich;
        this.toppingHandler = toppingHandler;
    }

    public void Execute()
    {
        sandwich.AddTopping(Order.Topping.mayonnaise);
        toppingHandler.AddCommand(this);
    }

    public void Redo()
    {
        sandwich.AddTopping(Order.Topping.mayonnaise);
    }

    public void Undo()
    {
        sandwich.RemoveTopping();
    }
}

public class AddTomatoCommand : IToppingCommand
{
    Sandwich sandwich;
    ToppingHandler toppingHandler;

    public AddTomatoCommand(Sandwich sandwich, ToppingHandler toppingHandler)
    {
        this.sandwich = sandwich;
        this.toppingHandler = toppingHandler;
    }

    public void Execute()
    {
        sandwich.AddTopping(Order.Topping.tomato);
        toppingHandler.AddCommand(this);
    }

    public void Redo()
    {
        sandwich.AddTopping(Order.Topping.tomato);
    }

    public void Undo()
    {
        sandwich.RemoveTopping();
    }
}

public class AddLettuceCommand : IToppingCommand
{
    Sandwich sandwich;
    ToppingHandler toppingHandler;

    public AddLettuceCommand(Sandwich sandwich, ToppingHandler toppingHandler)
    {
        this.sandwich = sandwich;
        this.toppingHandler = toppingHandler;
    }

    public void Execute()
    {
        sandwich.AddTopping(Order.Topping.lettuce);
        toppingHandler.AddCommand(this);
    }

    public void Redo()
    {
        sandwich.AddTopping(Order.Topping.lettuce);
    }

    public void Undo()
    {
        sandwich.RemoveTopping();
    }
}
