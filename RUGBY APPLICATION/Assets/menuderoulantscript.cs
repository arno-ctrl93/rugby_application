using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class menuderoulantscript : MonoBehaviour
{
    public GameObject test;
    public GameObject listderoulant;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(test);
        
    }

    // Update is called once per frame
    void  Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject a = Instantiate(test);
            a.GetComponent<Transform>().SetParent(listderoulant.transform, true);
            a.gameObject.transform.localScale = new Vector3(1f,1f,0.5f);
            a.transform.GetChild(0).GetComponent<Text>().text = "test";
        }
    }

    public void addbouton (Exercice a,string modif)
    {
         GameObject b = Instantiate(test);
          b.GetComponent<Transform>().SetParent(listderoulant.transform, true);
          b.gameObject.transform.localScale = new Vector3(1f,1f,0.5f);
          b.transform.GetChild(0).GetComponent<Text>().text =a.name;
          b.transform.GetChild(1).GetComponent<Text>().text ="Modifié le "+modif;

    }
    
}
