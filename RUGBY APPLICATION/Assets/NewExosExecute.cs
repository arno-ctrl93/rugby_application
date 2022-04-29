using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class NewExosExecute : MonoBehaviour
{

    string path = Directory.GetCurrentDirectory();//A changer manuellement pour le moment
    private GameObject exercices;
    public InputField titre;
    public InputField description;
    public InputField objectif;
    public InputField comportement;
    public InputField consigne;
    public InputField lancement;
    public InputField evolution;
    public InputField critere;
    public InputField effectif;
    public InputField espace;
    public InputField duree;
    public InputField materiel;
    public InputField but;
    public InputField score;
    


    
    private string titre2;
    private string description2;
    private string objectif2;
    private string comportement2;
    private string consigne2;
    private string lancement2;
    private string evolution2;
    private string critere2;
    private string effectif2;
    private string espace2;
    private string duree2;
    private string materiel2;
    private string but2;
    private string score2;


    private Exercice newexos;
    public int nombredexos;
    public string contenubasic;
    

// Le signe µ permet de savoir que l'on passe d'une info à l'autre (ancien signe était l'espace mais trop commun)
    // Start is called before the first frame update
    void Start()
    {

        
        exercices = gameObject.transform.Find("Exercice").gameObject;
        if (Directory.Exists(path+@"\CARUGBY"))
        {
            path += @"\CARUGBY\";

        }
        else
        {
            Directory.CreateDirectory(path+@"\CARUGBY");
            path += @"\CARUGBY\";

        }
        if (File.Exists(path+"basic.txt"))//Si le fichier basic existe déjà alors recuperer l info du nombre d exos deja fait
        {
            contenubasic = File.ReadAllText(path+"basic.txt");
            int i = 0;
            string a ="";
            while (contenubasic[i] != 'µ')
            {
                a += contenubasic[i];
                i++;

            }
            nombredexos = Convert.ToInt32(a);
            //Debug.Log(nombredexos);
            //Debug.Log(contenubasic);
        }
        else//Ou sinon créer ce fichier et assigne le nombre d exos à zero
        {
            File.Create(path+"basic.txt").Dispose();
            nombredexos = 0;
        }



    }

    // Update is called once per frame
    void Update()
    {
         //Debug.Log (titre.text);
         Debug.Log(path);
    }



    public void changehide (InputField a)
    {
       
       Debug.Log(a.enabled);

    }

    public void enlogtitre()
     {
         Debug.Log (titre.text);
     }

    public void save()
    {
        
        nombredexos ++;
        //Debug.Log("Save");
        titre2 = titre.text;
        description2 = description.text;
        objectif2 = objectif.text;
        
        comportement2 = comportement.text;
        consigne2 = consigne.text;
        lancement2 = lancement.text;
        evolution2 = evolution.text;
        critere2 = critere.text;
        effectif2 = effectif.text;
        espace2 = espace.text;
        duree2 = duree.text;
        materiel2 = materiel.text;
        but2 = but.text;
        score2 = score.text;
        newexos = new Exercice(titre2,description2,nombredexos, objectif2,comportement2,consigne2,lancement2,evolution2, critere2, effectif2, espace2, duree2, materiel2, but2, score2);
        Debug.Log(newexos.name+" "+newexos.description);
        Debug.Log(titre2+" "+description2);
        writeinfichier(newexos);
        resetnewexos();
    }

    public void writeinfichier(Exercice a )
    {
        string contenu = a.id+"µ"+a.name+"µ"+a.description+"µ"+a.objectif+"µ"+a.comportement+"µ"+
        a.consigne+"µ"+a.lancement+"µ"+a.evolution+"µ"+a.critere+"µ"+a.effectif+"µ"+a.espace+"µ"+
        a.duree+"µ"+a.materiel+"µ"+a.but+"µ"+a.score;
        File.WriteAllText(path+"Exercice "+nombredexos,contenu);
        File.WriteAllText(path+"basic.txt", nombredexos+"µ");
        Debug.Log(path);
    
    }

    public void resetnewexos()
    {
        titre.text ="";
        description.text="";
        objectif.text="";
        comportement.text="";
        consigne.text="";
        lancement.text="";
        evolution.text="";
        critere.text="";
        effectif.text="";
        espace.text="";
        duree.text="";
        materiel.text="";
        but.text="";
        score.text="";
        SceneManager.LoadScene ("Assets/Scenes/EXERCICE menu.unity", LoadSceneMode.Single );
    }
}
