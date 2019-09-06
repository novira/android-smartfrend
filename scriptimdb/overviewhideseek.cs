using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class overviewhideseek : MonoBehaviour {
	public Button close;
	public GameObject inio,nantio;
	// Use this for initialization
	void Start () {
		close.onClick.AddListener (() => closeclick());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void closeclick(){
		inio.SetActive (false);
		nantio.SetActive (true);
	}
}
