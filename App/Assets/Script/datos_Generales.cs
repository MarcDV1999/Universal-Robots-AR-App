using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class datos_Generales : MonoBehaviour{
    // Start is called before the first frame update
    public GameObject Alerta;
	public TextMeshProUGUI TextProInfo;
	private string texto;
	private int RCurrent;
	private int Power;
    void Start(){
    }

    // Update is called once per frame
    void Update(){
    	//int RCurrent = sockets.URobot.regs[61].GetData();
    	//Debug.Log(RCurrent);

        RCurrent = 0;
        RCurrent += Math.Abs(sockets.URobot.regs[(int)sockets.RegisterNames.BaseJointCurrent].GetData());
        RCurrent += Math.Abs(sockets.URobot.regs[(int)sockets.RegisterNames.ShoulderJointCurrent].GetData());
        RCurrent += Math.Abs(sockets.URobot.regs[(int)sockets.RegisterNames.ElbowJointCurrent].GetData());
        RCurrent += Math.Abs(sockets.URobot.regs[(int)sockets.RegisterNames.Wrist1JointCurrent].GetData());
        RCurrent += Math.Abs(sockets.URobot.regs[(int)sockets.RegisterNames.Wrist2JointCurrent].GetData());
        RCurrent += Math.Abs(sockets.URobot.regs[(int)sockets.RegisterNames.Wrist3JointCurrent].GetData());
        Power = (48 * RCurrent )/ 1000;
        int ioCurrent = sockets.URobot.regs[(int)sockets.RegisterNames.ToolCurrent].GetData();
    	//int RCurrent = 2;
    	//int ioCurrent = 3;
    	texto ="Robot Current: " + RCurrent + "mA" + "\nIOCurrent: " + ioCurrent + "mA" + "\nTotal Power: " + Power + " W";
    	TextProInfo.text = texto;
    }
}
