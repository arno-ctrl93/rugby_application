using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEditor.Experimental.GraphView;

public class Exercicemenuscript : MonoBehaviour
{

    public List<Exercice> exoslist ;

    string path = Directory.GetCurrentDirectory()+@"\CARUGBY\";
    menuderoulantscript scriptbouton;

    private GameObject scrollbar;
    private GameObject listexos;
    private GameObject retour;
    private GameObject newe;
    public bool modedetaillexos;
    private GameObject detaillexos;
    private GameObject retourapercu;
    private GameObject moreinfo;
    public Exercice encoursdaffichage;
    public GameObject detaillelist;
    public GameObject canvaexos;
    public GameObject canvamodifexos;
    public NewExosExecute ecriredansfichierscript;
    
    


    // Start is called before the first frame update
    void Start()
    {

        encoursdaffichage = null;
        detaillexos = gameObject.transform.GetChild(4).gameObject;
        retourapercu = gameObject.transform.GetChild(5).gameObject;
        moreinfo = gameObject.transform.GetChild(6).gameObject;
        canvaexos= gameObject.transform.GetChild(7).gameObject;
        canvamodifexos = gameObject.transform.GetChild(8).gameObject;
        
        modedetaillexos = false;
        exoslist = new List<Exercice>();
        scrollbar = transform.GetChild(3).gameObject;
        listexos = transform.GetChild(2).gameObject;
        
        retour = transform.GetChild(1).gameObject;
        
        newe = transform.GetChild(0).gameObject;

        
        actualiserlisteexos();
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(exoslist.Count);
        
    }


    public Exercice readfichier (string contenu) //index de l'info dans le fichier
    {
        int a=0;
        string text = "";
        Exercice exos = new Exercice ("","",0,"","","","","","","","","","","","");
        int size = contenu.Length;
        for (int i = 0; i < size; i++)
        {
            if (contenu[i]=='µ')
            {
                a+=1;
                switch (a)
                {
                
                    case 1:
                        exos.id =Convert.ToInt32(text);
                        break;
                        
                    case 2:
                        exos.name=text;
                        break;
                    case 3:
                        exos.description=text;
                        break;
                    case 4:
                        exos.objectif=text;
                        break;
                    case 5:
                        exos.comportement=text;
                        break;
                    case 6:
                        exos.consigne=text;
                        break;
                    case 7:
                        exos.lancement=text;
                        break;
                    case 8:
                        exos.evolution=text;
                        break;
                    case 9:
                        exos.critere=text;
                        break;
                    case 10:
                        exos.effectif=text;
                        break;
                    case 11:
                        exos.espace=text;
                        break;
                    case 12:
                        exos.duree=text;
                        break;
                    case 13:
                        exos.materiel=text;
                        break;
                    case 14:
                        exos.but=text;
                        break;
                    case 15:
                        exos.score=text;
                        break;
                }
                
               text="";

            }
            else
            {
                if (contenu[i]!='µ')
                {
                     text +=contenu[i];
                }
            }


        }

        exos.score = text;
        return exos;

    }

    public void exercicedetaille (string name)
    {
        if (modedetaillexos == false)
        {
            modedetaillexos = true;
            detaillexos.SetActive(true);
            retourapercu.SetActive(true);
            moreinfo.SetActive(true);
        }

        Exercice afficher = findexoswithname(name);

        detaillexos.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = name;
        detaillexos.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = afficher.effectif;
        detaillexos.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = afficher.duree;
        detaillexos.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = afficher.consigne;
        detaillexos.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = afficher.objectif;
        
        canvaexos.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = name;
        canvaexos.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = afficher.objectif;
        canvaexos.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = afficher.comportement;
        canvaexos.transform.GetChild(3).GetChild(1).GetComponent<Text>().text = afficher.consigne;
        canvaexos.transform.GetChild(4).GetChild(1).GetComponent<Text>().text = afficher.lancement;
        canvaexos.transform.GetChild(5).GetChild(1).GetComponent<Text>().text = afficher.evolution;
        canvaexos.transform.GetChild(6).GetChild(1).GetComponent<Text>().text = afficher.critere;
        canvaexos.transform.GetChild(7).GetChild(1).GetComponent<Text>().text = afficher.description;
        canvaexos.transform.GetChild(8).GetChild(1).GetComponent<Text>().text = afficher.effectif;
        canvaexos.transform.GetChild(9).GetChild(1).GetComponent<Text>().text = afficher.espace;
        canvaexos.transform.GetChild(10).GetChild(1).GetComponent<Text>().text = afficher.duree;
        canvaexos.transform.GetChild(11).GetChild(1).GetComponent<Text>().text = afficher.materiel;
        canvaexos.transform.GetChild(12).GetChild(1).GetComponent<Text>().text = afficher.but;
        canvaexos.transform.GetChild(13).GetChild(1).GetComponent<Text>().text = afficher.score;

        canvamodifexos.transform.GetChild(0).GetComponent<InputField>().text = name;
        canvamodifexos.transform.GetChild(1).GetComponent<InputField>().text = afficher.objectif;
        canvamodifexos.transform.GetChild(2).GetComponent<InputField>().text = afficher.comportement;
        canvamodifexos.transform.GetChild(3).GetComponent<InputField>().text = afficher.consigne;
        canvamodifexos.transform.GetChild(4).GetComponent<InputField>().text = afficher.lancement;
        canvamodifexos.transform.GetChild(5).GetComponent<InputField>().text = afficher.evolution;
        canvamodifexos.transform.GetChild(6).GetComponent<InputField>().text = afficher.critere;
        canvamodifexos.transform.GetChild(7).GetComponent<InputField>().text = afficher.description;
        canvamodifexos.transform.GetChild(8).GetComponent<InputField>().text = afficher.effectif;
        canvamodifexos.transform.GetChild(9).GetComponent<InputField>().text = afficher.espace;
        canvamodifexos.transform.GetChild(10).GetComponent<InputField>().text = afficher.duree;
        canvamodifexos.transform.GetChild(11).GetComponent<InputField>().text = afficher.materiel;
        canvamodifexos.transform.GetChild(12).GetComponent<InputField>().text = afficher.but;
        canvamodifexos.transform.GetChild(13).GetComponent<InputField>().text = afficher.score;
        
        encoursdaffichage = afficher;




    }

    public void exercicedetaillestop()
    {
        modedetaillexos = false;
        detaillexos.SetActive(false);
        retourapercu.SetActive(false);
        moreinfo.SetActive(false);
    }


    public Exercice findexoswithname(string name)
    {
        int i = 0;
        while (name != exoslist[i].name)
        {
            i++;
        }

        return exoslist[i];
    }

    public void exosfullinfo()
    {
        canvaexos.SetActive(true);
        newe.SetActive(false);
        modedetaillexos = false;
        detaillexos.SetActive(false);
        retourapercu.SetActive(false);
        moreinfo.SetActive(false);
        scrollbar.SetActive(false);
        listexos.SetActive(false);
        
    }

    public void exosfullinfostop()
    {
        canvaexos.SetActive(false);
        newe.SetActive(true);
        scrollbar.SetActive(true);
        listexos.SetActive(true);
    }

    public void exosmodif()
    {
        canvaexos.SetActive(false);
        canvamodifexos.SetActive(true);
    }

    public void exosmodifsave()
    {
        Exercice exomodifies = new Exercice ("","",0,"","","","","","","","","","","","");
        exomodifies.name = canvamodifexos.transform.GetChild(0).GetComponent<InputField>().text ;
        exomodifies.objectif = canvamodifexos.transform.GetChild(1).GetComponent<InputField>().text ;
        exomodifies.comportement = canvamodifexos.transform.GetChild(2).GetComponent<InputField>().text ;
        exomodifies.consigne = canvamodifexos.transform.GetChild(3).GetComponent<InputField>().text ;
        exomodifies.lancement = canvamodifexos.transform.GetChild(4).GetComponent<InputField>().text ;
        exomodifies.evolution = canvamodifexos.transform.GetChild(5).GetComponent<InputField>().text ;
        exomodifies.critere = canvamodifexos.transform.GetChild(6).GetComponent<InputField>().text ;
        exomodifies.description = canvamodifexos.transform.GetChild(7).GetComponent<InputField>().text ;
        exomodifies.effectif = canvamodifexos.transform.GetChild(8).GetComponent<InputField>().text ;
        exomodifies.espace = canvamodifexos.transform.GetChild(9).GetComponent<InputField>().text ;
        exomodifies.duree = canvamodifexos.transform.GetChild(10).GetComponent<InputField>().text ;
        exomodifies.materiel = canvamodifexos.transform.GetChild(11).GetComponent<InputField>().text;
        exomodifies.but = canvamodifexos.transform.GetChild(12).GetComponent<InputField>().text;
        exomodifies.score = canvamodifexos.transform.GetChild(13).GetComponent<InputField>().text;

        
        string contenu = exomodifies.id+"µ"+exomodifies.name+"µ"+exomodifies.description+"µ"+exomodifies.objectif+"µ"+exomodifies.comportement+"µ"+
                         exomodifies.consigne+"µ"+exomodifies.lancement+"µ"+exomodifies.evolution+"µ"+exomodifies.critere+"µ"+exomodifies.effectif+"µ"+exomodifies.espace+"µ"+
                         exomodifies.duree+"µ"+exomodifies.materiel+"µ"+exomodifies.but+"µ"+exomodifies.score;
        File.WriteAllText(path+"Exercice "+encoursdaffichage.id+1,contenu);
        
        for (int i = 0; i < exoslist.Count; i++)
        {
            if (exoslist[i] == encoursdaffichage)
            {
                exoslist[i] = exomodifies;
            }
        }
        

        canvamodifexos.SetActive(false);
        newe.SetActive(true);
        scrollbar.SetActive(true);
        listexos.SetActive(true);
        
    }

    public void delete()
    {
        Debug.Log(path+"Exercice "+(encoursdaffichage.id+1));
        File.Delete(path+"Exercice "+(encoursdaffichage.id+1));
        exoslist.Remove(encoursdaffichage);
        exosfullinfostop();
    }

    public void actualiserlisteexos()
    {
        string[] files = Directory.GetFiles(path);
        scriptbouton = transform.GetChild(2).GetChild(0).GetComponent<menuderoulantscript>();
        int i = 1;
        while (i<files.Length)
        {
            FileInfo fi = new FileInfo(files[i]);
            string modification = fi.LastWriteTime.ToString();
            string sw = File.ReadAllText(files[i]);
            Exercice titre = readfichier(sw);
            exoslist.Add(titre);
            
            scriptbouton.addbouton(titre,modification);
            

            i++;
        }
    }
}

   