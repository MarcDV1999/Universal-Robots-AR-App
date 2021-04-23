using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

/********************************************************
************************ WRIST 1 ************************
*********************************************************/

public class datos_M0 : MonoBehaviour
{
    // Start is called before the first frame update
	
	private TextMeshPro TextPro;
    public GameObject panel;
    public Material panel_azul;
    public Material panel_rojo;
	private string texto;
    void Start(){
        TextPro = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update(){
   	//textmeshPro.SetText("The first numbe");
    	int pos = sockets.URobot.regs[(int)sockets.RegisterNames.BaseJointAngle].GetData();
    	int vel = sockets.URobot.regs[(int)sockets.RegisterNames.BaseJointAngleVelocity].GetData();
    	int curr = sockets.URobot.regs[(int)sockets.RegisterNames.BaseJointCurrent].GetData();
    	int temp = sockets.URobot.regs[(int)sockets.RegisterNames.BaseJointTemperature].GetData();
    	//pos = pos*360/(2*3.1416*1000);
    	texto = "Pos: " + (pos*360/(2*3141.5)).ToString("F2") + " °\nVel: " + vel + " mRad/s\nCurr: " + Math.Abs(curr) + " mA\nTemp: " + temp + " °C";
    	TextPro.text = texto;
        //temp = 60;
        if(temp >= 50){
            panel.GetComponent<Renderer> ().material = panel_rojo;
            Warning_intermitente.activar_Warning0 = true;
        }
        else {
            Warning_intermitente.activar_Warning0 = false;
            panel.GetComponent<Renderer> ().material = panel_azul;
        }
        
    }

}