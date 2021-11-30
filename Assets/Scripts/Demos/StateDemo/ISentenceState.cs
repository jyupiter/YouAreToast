using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SentenceGenerator
{
    public interface ISentenceState
    {
        void SelectPhrase(SentenceGenerator generator);
    }
}