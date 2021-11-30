using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SentenceGenerator
{
    public class SentenceObject : Word
    {
        public ObjectType objectType { get; }

        public SentenceObject(string id, string word, ObjectType objectType) : base(id, word)
        {
            this.objectType = objectType;
        }
    }
}