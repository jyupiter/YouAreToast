using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SentenceGenerator
{
    public class StateAction : ISentenceState
    {
        public void SelectPhrase(SentenceGenerator generator)
        {
            //select random action
            Action selectWord = generator.GetRandomAction();
            generator.ConcatSentence(selectWord.word);

            //select random object type to apply action on 
            switch (CommonUtility.SelectRandom(selectWord.objectList))
            {
                case ObjectType.ITEM:
                    generator.SetSentenceState(new StateItem());
                    break;
                case ObjectType.LOCATION:
                    generator.SetSentenceState(new StateLocation());
                    break;
                case ObjectType.NAME:
                    generator.SetSentenceState(new StateName());
                    break;
                case ObjectType.VICTIM:
                    generator.SetSentenceState(new StateVictim());
                    break;
            }
        }
    }
}