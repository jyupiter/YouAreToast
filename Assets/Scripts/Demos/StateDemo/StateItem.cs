using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SentenceGenerator
{
    public class StateItem : ISentenceState
    {
        public void SelectPhrase(SentenceGenerator generator)
        {
            //add random item to sentence
            SentenceObject selectWord = generator.GetRandomSubject(ObjectType.ITEM);
            string fullItem = generator.GetRandomDescriptor(ObjectType.ITEM).word + " " + selectWord.word;
            generator.ConcatSentence(fullItem);

            if (Random.Range(0, 1f) < 0.4f)
            {
                //follow with location
                generator.ConcatSentence(" in ");
                generator.SetSentenceState(new StateLocation());
            }
            else
            {
                //end sentence
                generator.EndSentence();
            }
        }
    }
}