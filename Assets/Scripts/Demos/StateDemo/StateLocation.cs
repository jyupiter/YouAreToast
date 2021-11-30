using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SentenceGenerator
{
    public class StateLocation : ISentenceState
    {
        public void SelectPhrase(SentenceGenerator generator)
        {
            //add random location to sentence
            string fullName = generator.GetRandomDescriptor(ObjectType.LOCATION).word + " " + generator.GetRandomSubject(ObjectType.LOCATION).word;
            generator.ConcatSentence(fullName);

            //end sentence
            generator.EndSentence();
        }
    }
}