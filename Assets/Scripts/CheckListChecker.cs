using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckListChecker : MonoBehaviour
{
    public GameObject[] dressingChange;
    public bool door = false;       //needs to be true then false after entering room
    public GameObject listPanel;
    public bool panelOn = true;

    private List<string> onTheTable = new List<string>();
    private int touchCounter = 0;
    private int i = 0;

	void Awake ()
    {
        this.listPanel = GameObject.Find("CheckListPanel");

        this.dressingChange = new GameObject[] {GameObject.Find("Dressing Change Kit"), GameObject.Find("Face Mask for Patient"),
    GameObject.Find("Securement Device"), GameObject.Find("Sterile 4x4"), GameObject.Find("Sterile Drape"), GameObject.Find("Sterile Gloves"),
    GameObject.Find("Tegaderm"), GameObject.Find("Alcohol Wipes"), GameObject.Find("Biopatch"), GameObject.Find("Chux"), GameObject.Find("Clean Gloves")};
    }

    void Start()
    {
        this.listPanel.SetActive(this.panelOn);     //change true or false depending upon simulation difficulty

        if (this.panelOn)       //should be activated on button press for difficulty 
        {
            foreach(GameObject item in dressingChange)      //dressingChange should change upon skill selection
            {
                //Debug.Log(item);
                GameObject.Find(item.name + ".").GetComponent<Image>().enabled = false;
            }
        }
    }

    public bool DressingChangeKit()
    {
        foreach(string thing in this.onTheTable)
        {
            if(GameObject.Find(thing) == this.dressingChange[0])
            {
                this.touchCounter++;
            }
        }
        foreach (string thing in this.onTheTable)
        {
            if (GameObject.Find(thing) == this.dressingChange[1])
            {
                this.touchCounter++;
            }
        }
        foreach (string thing in this.onTheTable)
        {
            if (GameObject.Find(thing) == this.dressingChange[2])
            {
                this.touchCounter++;
            }
        }
        foreach (string thing in this.onTheTable)
        {
            if (GameObject.Find(thing) == this.dressingChange[3])
            {
                this.touchCounter++;
            }
        }
        foreach (string thing in this.onTheTable)
        {
            if (GameObject.Find(thing) == this.dressingChange[4])
            {
                this.touchCounter++;
            }
        }
        foreach (string thing in this.onTheTable)
        {
            if (GameObject.Find(thing) == this.dressingChange[5])
            {
                this.touchCounter++;
            }
        }
        foreach (string thing in this.onTheTable)
        {
            if (GameObject.Find(thing) == this.dressingChange[6])
            {
                this.touchCounter++;
            }
        }
        foreach (string thing in this.onTheTable)
        {
            if (GameObject.Find(thing) == this.dressingChange[7])
            {
                this.touchCounter++;
            }
        }
        foreach (string thing in this.onTheTable)
        {
            if (GameObject.Find(thing) == this.dressingChange[8])
            {
                this.touchCounter++;
            }
        }
        foreach (string thing in this.onTheTable)
        {
            if (GameObject.Find(thing) == this.dressingChange[9])
            {
                this.touchCounter++;
            }
        }
        foreach (string thing in this.onTheTable)
        {
            if (GameObject.Find(thing) == this.dressingChange[10])
            {
                this.touchCounter++;
            }
        }

        if(this.touchCounter >= 11)
        {
            this.touchCounter = 0;
            return true;
        }
        else
        {
            this.touchCounter = 0;
            return false;
        }
    }

    public bool CheckList(GameObject[] objectsNeeded)       //would it be better to do a merge sort type of thing?  maybe organize array alphabetically and compare string values to it??
    {   
        //switch(item in table list) case 1: case 2: {true?;}


        foreach(GameObject item in objectsNeeded)   //for each object in array, if it is touching table top touchCounter++
        {            
            foreach(string thing in this.onTheTable)    //if item is in contact with table
            {
                if (item == GameObject.Find(thing))     //basic idea but the list index will need to be changed and cycle through up to i
                {
                    Debug.Log("1." + this.touchCounter);
                    this.touchCounter++;        //value not resetting locally
                    Debug.Log("2." + this.touchCounter);
                    //end this foreach
                    GameObject.Find(item.name + ".").GetComponent<Image>().enabled = true;               
                }
            }
        }

        if (this.touchCounter >= objectsNeeded.Length)
        {
            Debug.Log("all objects gathered ");
            this.touchCounter = 0;      //might not be needed
            return true;
        }
        else
        {
            this.touchCounter = 0;
            Debug.Log("keep trying " + this.touchCounter);
            return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        this.onTheTable.Add(other.name);
        this.i++;

        this.door = CheckList(this.dressingChange);
        
        //this.door = DressingChangeKit();
    }

    private void OnTriggerExit(Collider other)      
    {
        if (GameObject.Find(other.gameObject.name + ".") != null)
        {
            GameObject.Find(other.gameObject.name + ".").GetComponent<Image>().enabled = false; //turn off check box
            this.onTheTable.Remove(other.gameObject.name);      //remove object from list
        }
    }
}
