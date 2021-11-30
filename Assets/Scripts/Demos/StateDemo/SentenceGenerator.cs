using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SentenceGenerator
{
    public class SentenceGenerator : MonoBehaviour
    {
        public Text outputLabel;
        public int outputCount;

        private List<Name> nameList;
        private List<Descriptor> descriptorList;
        private List<Action> actionList;
        private List<SentenceObject> sentenceObjectList;

        private ISentenceState currentState;
        private string currentSentence;

        // Start is called before the first frame update
        void Start()
        {
            MakeWordList();

            //make sentences
            outputLabel.text = "";
            for (int i = 0; i < outputCount; i++)
            {
                //start with index
                ConcatSentence((i + 1) + ": ");

                //set state to sentence subject to start sentence
                SetSentenceState(new StateSentenceSubject());
            }
        }

        public void ConcatSentence(string aPhrase)
        {
            CommonUtility.Log(currentState + " " + aPhrase);

            //add phrase to sentence
            currentSentence += aPhrase;
        }

        public void EndSentence()
        {
            CommonUtility.Log("END");
            
            //end sentence
            outputLabel.text += currentSentence + ".\n\n";
            currentSentence = "";
        }

        public void SetSentenceState(ISentenceState sentenceState)
        {
            //set current generator state
            currentState = sentenceState;

            //select phrase in current state
            currentState.SelectPhrase(this);
        }

        public Name GetRandomName()
        {
            //get random name from list
            return CommonUtility.SelectRandom(nameList);
        }

        public Descriptor GetRandomDescriptor(ObjectType objectType)
        {
            //get random descriptor from list based on object type
            return CommonUtility.SelectRandom(descriptorList.FindAll(x => x.objectList.Contains(objectType)));
        }

        public Action GetRandomAction()
        {
            //get random action from list
            return CommonUtility.SelectRandom(actionList);
        }

        public SentenceObject GetRandomSubject(params ObjectType[] objectTypes)
        {
            //get random object from list based on possible object types
            return CommonUtility.SelectRandom(GetObjectList(objectTypes));
        }

        public List<SentenceObject> GetObjectList(params ObjectType[] objectTypes)
        {
            if (objectTypes.Length > 0)
            {
                //filter object list by types
                List<ObjectType> objectTypeList = new List<ObjectType>();
                objectTypeList.AddRange(objectTypes);
                return sentenceObjectList.FindAll(x => objectTypeList.Contains(x.objectType));
            }
            else
            {
                //return full object list if types not specified
                return sentenceObjectList;
            }
        }

        private void MakeWordList()
        {
            //placeholder database for words
            nameList = new List<Name>();
            nameList.Add(new Name("1001", "Harmony"));
            nameList.Add(new Name("1002", "Dancer"));
            nameList.Add(new Name("1003", "Star"));
            nameList.Add(new Name("1004", "Aurora"));
            nameList.Add(new Name("1005", "Grudge"));
            nameList.Add(new Name("1006", "Peace"));
            nameList.Add(new Name("1007", "Grace"));
            nameList.Add(new Name("1008", "Witness"));
            nameList.Add(new Name("1009", "Moon"));
            nameList.Add(new Name("1010", "Blood"));
            nameList.Add(new Name("1011", "Blue"));
            nameList.Add(new Name("1012", "White"));
            nameList.Add(new Name("1013", "Sorrow"));
            nameList.Add(new Name("1014", "Light"));

            descriptorList = new List<Descriptor>();
            descriptorList.Add(new Descriptor("2001", "Cosmic", new List<ObjectType> { ObjectType.LOCATION, ObjectType.NAME }));
            descriptorList.Add(new Descriptor("2002", "Eternal", new List<ObjectType> { ObjectType.LOCATION, ObjectType.NAME }));
            descriptorList.Add(new Descriptor("2003", "Enchanted", new List<ObjectType> { ObjectType.NAME, ObjectType.ITEM }));
            descriptorList.Add(new Descriptor("2004", "Perpetual", new List<ObjectType> { ObjectType.LOCATION, ObjectType.NAME, ObjectType.ITEM }));
            descriptorList.Add(new Descriptor("2005", "Crying", new List<ObjectType> { ObjectType.NAME, ObjectType.ITEM }));
            descriptorList.Add(new Descriptor("2006", "Deep", new List<ObjectType> { ObjectType.LOCATION, ObjectType.NAME, ObjectType.ITEM }));
            descriptorList.Add(new Descriptor("2007", "Silent", new List<ObjectType> { ObjectType.LOCATION, ObjectType.NAME }));
            descriptorList.Add(new Descriptor("2008", "Damned", new List<ObjectType> { ObjectType.LOCATION, ObjectType.NAME }));
            descriptorList.Add(new Descriptor("2009", "Doomed", new List<ObjectType> { ObjectType.LOCATION, ObjectType.NAME, ObjectType.ITEM }));
            descriptorList.Add(new Descriptor("2010", "Chaotic", new List<ObjectType> { ObjectType.LOCATION, ObjectType.ITEM }));
            descriptorList.Add(new Descriptor("2011", "Buried", new List<ObjectType> { ObjectType.LOCATION, ObjectType.NAME, ObjectType.ITEM }));
            descriptorList.Add(new Descriptor("2012", "Drowned", new List<ObjectType> { ObjectType.LOCATION, ObjectType.NAME, ObjectType.ITEM }));
            descriptorList.Add(new Descriptor("2013", "Ruined", new List<ObjectType> { ObjectType.LOCATION, ObjectType.NAME, ObjectType.ITEM }));
            descriptorList.Add(new Descriptor("2014", "Reified", new List<ObjectType> { ObjectType.LOCATION, ObjectType.ITEM }));
            descriptorList.Add(new Descriptor("2015", "Haunted", new List<ObjectType> { ObjectType.LOCATION, ObjectType.NAME }));
            descriptorList.Add(new Descriptor("2016", "Subtle", new List<ObjectType> { ObjectType.NAME, ObjectType.ITEM }));

            actionList = new List<Action>();
            actionList.Add(new Action("3001", " died in ", new List<ObjectType> { ObjectType.LOCATION }));
            actionList.Add(new Action("3002", " was captured in ", new List<ObjectType> { ObjectType.LOCATION }));
            actionList.Add(new Action("3003", " is imprisoned in ", new List<ObjectType> { ObjectType.LOCATION }));
            actionList.Add(new Action("3004", " killed ", new List<ObjectType> { ObjectType.VICTIM, ObjectType.NAME }));
            actionList.Add(new Action("3005", " destroyed ", new List<ObjectType> { ObjectType.LOCATION, ObjectType.ITEM }));
            actionList.Add(new Action("3006", " deceived ", new List<ObjectType> { ObjectType.VICTIM, ObjectType.NAME }));
            actionList.Add(new Action("3007", " stole ", new List<ObjectType> { ObjectType.ITEM }));
            actionList.Add(new Action("3008", " kidnapped ", new List<ObjectType> { ObjectType.VICTIM }));
            actionList.Add(new Action("3009", " created ", new List<ObjectType> { ObjectType.ITEM, ObjectType.LOCATION }));
            actionList.Add(new Action("3010", " buried ", new List<ObjectType> { ObjectType.VICTIM, ObjectType.ITEM, ObjectType.LOCATION, ObjectType.NAME }));
            actionList.Add(new Action("3011", " imprisoned ", new List<ObjectType> { ObjectType.VICTIM, ObjectType.NAME }));

            sentenceObjectList = new List<SentenceObject>();
            sentenceObjectList.Add(new SentenceObject("4001", "Palace", ObjectType.LOCATION));
            sentenceObjectList.Add(new SentenceObject("4002", "City", ObjectType.LOCATION));
            sentenceObjectList.Add(new SentenceObject("4003", "Elysium", ObjectType.LOCATION));
            sentenceObjectList.Add(new SentenceObject("4004", "Garden", ObjectType.LOCATION));
            sentenceObjectList.Add(new SentenceObject("4005", "Paradise", ObjectType.LOCATION));
            sentenceObjectList.Add(new SentenceObject("4006", "Ziggurat", ObjectType.LOCATION));

            sentenceObjectList.Add(new SentenceObject("5001", "the Investigator", ObjectType.VICTIM));
            sentenceObjectList.Add(new SentenceObject("5002", "the Doctor", ObjectType.VICTIM));
            sentenceObjectList.Add(new SentenceObject("5003", "the Ferrylady", ObjectType.VICTIM));
            sentenceObjectList.Add(new SentenceObject("5004", "the Secretary", ObjectType.VICTIM));
            sentenceObjectList.Add(new SentenceObject("5005", "the Leader", ObjectType.VICTIM));
            sentenceObjectList.Add(new SentenceObject("5006", "the Architect", ObjectType.VICTIM));
            sentenceObjectList.Add(new SentenceObject("5007", "the Gardener", ObjectType.VICTIM));
            sentenceObjectList.Add(new SentenceObject("5008", "the Bartender", ObjectType.VICTIM));
            sentenceObjectList.Add(new SentenceObject("5009", "the Pretender", ObjectType.VICTIM));
            sentenceObjectList.Add(new SentenceObject("5010", "the Ghost", ObjectType.VICTIM));
            sentenceObjectList.Add(new SentenceObject("5011", "the Soldier", ObjectType.VICTIM));

            sentenceObjectList.Add(new SentenceObject("6001", "Heart", ObjectType.ITEM));
            sentenceObjectList.Add(new SentenceObject("6002", "Tear", ObjectType.ITEM));
            sentenceObjectList.Add(new SentenceObject("6003", "Blade", ObjectType.ITEM));
            sentenceObjectList.Add(new SentenceObject("6004", "Eye", ObjectType.ITEM));
            sentenceObjectList.Add(new SentenceObject("6005", "Blade", ObjectType.ITEM));
            sentenceObjectList.Add(new SentenceObject("6006", "Key", ObjectType.ITEM));
        }
    }
}