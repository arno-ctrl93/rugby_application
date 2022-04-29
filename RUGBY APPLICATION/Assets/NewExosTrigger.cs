using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.AI;
using UnityEngine.UI;

public class NewExosTrigger : MonoBehaviour
{

	private NewExosExecute script;
	public GameObject canvamenu;
	private Exercicemenuscript exosmenu;
	public Exercicemenuscript exercicescript;


	private string menu_principal = "Assets/Scenes/PRINCIPAL MENU.unity";
	private string menu_entrainement = "Assets/Scenes/ENTRAINEMENT MENU.unity";
	private string menu_exercice = "Assets/Scenes/EXERCICE menu.unity";
	private string creation_exos ="Assets/Scenes/CREATION_DEXOS.unity";

	private void Start()
	{
		script =gameObject.GetComponentInParent<NewExosExecute>();
		canvamenu = transform.root.gameObject;
		exosmenu = canvamenu.GetComponent<Exercicemenuscript>();
	}


	public void Save()
	{
		script.save();
	}

	public void acliquer ()
	{
		Debug.Log("Ca clique");
	}

	public void LoadNewExos()
	{
		 SceneManager.LoadScene (creation_exos, LoadSceneMode.Single );

	}

	public void LoadEntrainement ()
	{
		SceneManager.LoadScene(menu_entrainement, LoadSceneMode.Single);
	}

	public void LoadPrincipal ()
	{
		SceneManager.LoadScene(menu_principal,LoadSceneMode.Single);
	}

	public void LoadExercice()
	{
		SceneManager.LoadScene(menu_exercice,LoadSceneMode.Single);
	}

	public void cliquersurexos()
	{
		string name = gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text;
		Debug.Log(name);
		exosmenu.exercicedetaille(name);
		
	}

	public void quitterapercu()
	{
		exosmenu.modedetaillexos = true;
		exosmenu.exercicedetaillestop();
	}

	public void exoscomplet()
	{
		exosmenu.exosfullinfo();
	}

	public void exoscompletretour()
	{
		exosmenu.exosfullinfostop();
	}

	public void modifexos()
	{
		exosmenu.exosmodif();
	}

	public void saveexos()
	{
		exosmenu.exosmodifsave();
	}

	public void delete()
	{
		exosmenu.delete();
	}
}
