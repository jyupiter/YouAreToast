using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SentenceGenerator
{
    public class Action : Word
    {
        public List<ObjectType> objectList { get; }

        public Action(string id, string word, List<ObjectType> objectList) : base(id, word)
        {
            this.objectList = objectList;
        }
    }
}