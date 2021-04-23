using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/********************************************************
************************ Tool ************************
*********************************************************/

public class datos_power : MonoBehaviour{
    // Start is called before the first frame update
	
	public GameObject Power;
	public Sprite power_activado;
    public Sprite power_desactivado;
	//private string texto;
    //Debug.log(tmpx);
    void Start(){
    }

    // Update is called once per frame
    void Update(){
   	//textmeshPro.SetText("The first numbe");
    	int estado = sockets.URobot.regs[(int)sockets.RegisterNames.isPowerOnRobot].GetData();
    	if(estado == 1) Power.GetComponent<Image>().sprite = power_activado;
    	else if(estado == 0) Power.GetComponent<Image>().sprite = power_desactivado;
        
    }

}