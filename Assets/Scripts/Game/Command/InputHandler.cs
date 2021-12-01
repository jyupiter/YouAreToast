using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SandwichHandler;

public class InputHandler : MonoBehaviour
{
    private SandwichHandler sandwichHandler;

    public ICommand StartToasting { get; set; }
    public ICommand MoveBread { get; set; }
    public ICommand SubmitSandWich { get; set; }

    public Stack<ICommand> commands = new Stack<ICommand>();

    void Start()
    {
        sandwichHandler = GameObject.Find("Grill Station").GetComponent<SandwichHandler>();
        // TODO: change string name^

        StartToasting = new CStartToaster(this);
        MoveBread = new CMoveBread(this);
        SubmitSandWich = new CSubmitSandwich(this);

        commands = new Stack<ICommand>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if(sandwichHandler.sandwichState == SandwichState.fresh)
                StartToasting?.Execute();
            if(sandwichHandler.sandwichState == SandwichState.toasted)
                MoveBread?.Execute();
            if(sandwichHandler.sandwichState == SandwichState.complete)
                SubmitSandWich?.Execute();
        }
    }
}
