using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SentenceGenerator
{
    public class StateSentenceSubject : ISentenceState
    {
        public void SelectPhrase(SentenceGenerator generator)
        {
            //start sentence by generating subject of sentence
            string fullName = generator.GetRandomDescriptor(ObjectType.NAME).word + " " + generator.GetRandomName().word;
            generator.ConcatSentence(fullName);

            //follow with action done by subject
            generator.SetSentenceState(new StateAction());
        }
    }
}