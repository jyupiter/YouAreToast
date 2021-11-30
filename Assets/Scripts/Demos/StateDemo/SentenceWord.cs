using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SentenceGenerator
{
    public class Word
    {
        public string id { get; }
        public string word { get; }

        public Word(string id, string word)
        {
            this.id = id;
            this.word = word;
        }
    }
}