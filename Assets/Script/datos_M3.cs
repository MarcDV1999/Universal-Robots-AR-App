﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

/********************************************************
************************ WRIST 1 ************************
*********************************************************/

public class datos_M3 : MonoBehaviour
{
    // Start is called before the first frame update
	
	private TextMeshPro TextPro;
    public GameObject panel;
    public Material panel_azul;
    public Material panel_rojo;
	private string texto;
    //Debug.log(tmpx);
    void Start(){
        TextPro = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update(){
   	//textmeshPro.SetText("The first numbe");
    	int pos = sockets.URobot.regs[(int)sockets.RegisterNames.ElbowJointAngle].GetData();
        if(pos > 2705) pos = -(6283-pos);
    	int vel = sockets.URobot.regs[(int)sockets.RegisterNames.ElbowJointAngleVelocity].GetData();
    	int curr = sockets.URobot.regs[(int)sockets.RegisterNames.ElbowJointCurrent].GetData();
    	int temp = sockets.URobot.regs[(int)sockets.RegisterNames.ElbowJointTemperature].GetData() + 30;
        //int temp = 60;
    	texto = "Pos: " + (pos*360/(2*3141.5)).ToString("F2") + " °\nVel: " + vel + " mRad/s\nCurr: " + Math.Abs(curr) + " mA\nTemp: " + temp + " °C";
    	TextPro.text = texto;
        
        if(temp >= 45){
            panel.GetComponent<Renderer> ().material = panel_rojo;
            Warning_intermitente.activar_Warning3 = true;
        }
        else {
            Warning_intermitente.activar_Warning3 = false;
            panel.GetComponent<Renderer> ().material = panel_azul;
        }
        
    }

}