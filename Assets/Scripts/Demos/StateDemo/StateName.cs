using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SentenceGenerator
{
    public class StateName : ISentenceState
    {
        public void SelectPhrase(SentenceGenerator generator)
        {
            //add random name to sentence
            string fullName = generator.GetRandomDescriptor(ObjectType.NAME).word + " " + generator.GetRandomName().word;
            generator.ConcatSentence(fullName);

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