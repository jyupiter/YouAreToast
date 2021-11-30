using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SentenceGenerator
{
    public class StateVictim : ISentenceState
    {
        public void SelectPhrase(SentenceGenerator generator)
        {
            //add random victim name to sentence
            SentenceObject selectWord = generator.GetRandomSubject(ObjectType.VICTIM);
            generator.ConcatSentence(selectWord.word);

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