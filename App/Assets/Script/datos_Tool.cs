using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/********************************************************
************************ Tool ************************
*********************************************************/

public class datos_Tool : MonoBehaviour
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
    	int pos = sockets.URobot.regs[(int)sockets.RegisterNames.Wrist1JointAngle].GetData();
    	int vel = sockets.URobot.regs[(int)sockets.RegisterNames.Wrist1JointAngleVelocity].GetData();
    	int curr = sockets.URobot.regs[(int)sockets.RegisterNames.Wrist1JointCurrent].GetData();
    	int temp = sockets.URobot.regs[(int)sockets.RegisterNames.Wrist1JointTemperature].GetData();
    	texto = "Pos: " + ((6283-pos)*360/(2*3141.5)).ToString("F2") + "\nVel: " + vel + "\nCurr: " + curr + "\nTemp: " + temp;
    	TextPro.text = texto;
        if(temp >= 50){
            panel.GetComponent<Renderer> ().material = panel_rojo;
            Warning_intermitente.activar_WarningTool = true;
        }
        else {
            Warning_intermitente.activar_WarningTool = false;
            panel.GetComponent<Renderer> ().material = panel_azul;
        }
        //Debug.Log(Warning_intermitente.activar_Warning2);
    }

}