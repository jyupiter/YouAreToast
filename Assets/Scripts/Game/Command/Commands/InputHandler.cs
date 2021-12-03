using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SandwichHandler;

public class InputHandler : MonoBehaviour
{
    [HideInInspector] public SandwichHandler sandwichHandler;

    public ICommand StartToasting { get; set; }
    public ICommand MoveBread { get; set; }

    public Stack<ICommand> commands = new Stack<ICommand>();

    void Start()
    {
        sandwichHandler = GameObject.Find("Grill Station").GetComponent<SandwichHandler>();

        StartToasting = new StartToasterCommand(this);
        MoveBread = new MoveBreadCommand(this);

        commands = new Stack<ICommand>();
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if(hit)
            {
                GameObject test = hit.collider.gameObject;
                if(test.CompareTag("Bread"))
                {
                    if(sandwichHandler.sandwichState == SandwichState.fresh)
                        StartToasting?.Execute();
                }
                else if(test.CompareTag("Sandwich"))
                {
                    if(sandwichHandler.sandwichState == SandwichState.toasted)
                        MoveBread?.Execute();
                }
            }
        }
    }
}
