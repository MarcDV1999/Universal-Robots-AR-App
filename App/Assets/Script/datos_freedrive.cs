using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/********************************************************
************************ Tool ************************
*********************************************************/

public class datos_freedrive : MonoBehaviour{
    // Start is called before the first frame update
	
	public GameObject Free;
	public Sprite free_activado;
    public Sprite free_desactivado;
	//private string texto;
    //Debug.log(tmpx);
    void Start(){
    }

    // Update is called once per frame
    void Update(){
   	//textmeshPro.SetText("The first numbe");
    	int estado = sockets.URobot.regs[(int)sockets.RegisterNames.isFreedriveActive].GetData();
    	if(estado == 1) Free.GetComponent<Image>().sprite = free_activado;
    	else if(estado == 0) Free.GetComponent<Image>().sprite = free_desactivado;
        
    }

}