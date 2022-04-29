using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercice
{

    public string name;
    public string description;
    public string objectif;
    public string comportement;
    public string consigne;
    public string lancement;
    public string evolution;
    public string critere;
    public string effectif;
    public string espace;
    public string duree;
    public string materiel;
    public string but;
    public string score;

    public int id;

    public Exercice ( string name, string description, int id, string objectif, string comportement, string consigne, string lancement, string evolution, string critere, string effectif,
    string espace, string duree, string materiel, string but, string score)
    {
        this.name = name;
        this.description = description;
        this.id = id;
        this.objectif = objectif;
        this.comportement = comportement;
        this.consigne = consigne;
        this.lancement = lancement;
        this.evolution = evolution;
        this.critere = critere;
        this.effectif =effectif;
        this.espace = espace;
        this.duree = duree;
        this.materiel = materiel;
        this.but = but;
        this.score = score;

    }

}
