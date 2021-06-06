﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovingNumbers : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    private List<string> numbers = new List<string>();
    public GameObject buttonUp;
    public GameObject buttonDown;

    public float speed = .7f;
    public bool lineEnabled = true;
    private bool direction = true;

    private bool beingHandled = true;
    private bool win = false;


    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject item in items)
        {
            numbers.Add(item.GetComponent<TMP_InputField>().text);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!win && lineEnabled)
        {
            if(beingHandled)
            {
                beingHandled = false;
                StartCoroutine(UpdateNubers());

                foreach(GameObject item in items)
                {
                    if((item.GetComponent<TMP_InputField>().text) == "0")
                    {
                        item.GetComponent<TMP_InputField>().textComponent.alpha = .2f;
                    }
                    else 
                    {
                        item.GetComponent<TMP_InputField>().textComponent.alpha = 1f;
                    }
                }
            }
        }
    }

    IEnumerator UpdateNubers()
    {
        foreach(GameObject item in items)
        {
            item.GetComponent<TMP_InputField>().text = numbers[items.IndexOf(item)];
        }

        moveList(numbers);

        yield return new WaitForSeconds(speed);
        beingHandled = true;
    }

    void moveList(List<string> listOfItems)
    {
        int indexOfOne = listOfItems.IndexOf("1");

        if(direction)
        {
            //Debug.Log("going down");
            if(indexOfOne == listOfItems.Count - 1)
            {   
                listOfItems[indexOfOne] = "0";
                listOfItems[0] = "1";
            }
            else
            {
                listOfItems[indexOfOne] = "0";
                listOfItems[indexOfOne+1] = "1";
            }
        }
        else
        {
            //Debug.Log("going up");
            if(indexOfOne == 0)
            {
                listOfItems[indexOfOne] = "0";
                listOfItems[listOfItems.Count - 1] = "1";
            }
            else
            {
                listOfItems[indexOfOne] = "0";
                listOfItems[indexOfOne-1] = "1";
            }
        }
    }

    public void buttonUp_press()
    {
        this.direction = false;
    }
    
    public void buttonDown_press()
    {
        this.direction = true;
    }

    public void finish()
    {
        win = true;
    }
}