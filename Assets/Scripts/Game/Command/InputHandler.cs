using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SandwichHandler;

public class InputHandler : MonoBehaviour
{
    [HideInInspector] public SandwichHandler sandwichHandler;

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
        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if(hit)
            {
                string test = hit.collider.gameObject.name.ToLower();
                if(test.Contains("button") && (test.Contains("brioche") || test.Contains("bagel") || test.Contains("english muffin")))
                {
                    if(sandwichHandler.sandwichState == SandwichState.fresh)
                        StartToasting?.Execute();
                }
                else if(test.Contains("bread") && test.Contains("clone"))
                {
                    if(sandwichHandler.sandwichState == SandwichState.toasted)
                        MoveBread?.Execute();
                }
                else if(test.Contains("complete"))
                {
                    if(sandwichHandler.sandwichState == SandwichState.complete)
                        SubmitSandWich?.Execute();
                }
            }
        }
    }
}
