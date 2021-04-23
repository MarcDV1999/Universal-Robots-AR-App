using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Activar_alertas : MonoBehaviour{
    // Start is called before the first frame update
    public GameObject Alerta;
	public TextMeshProUGUI TextProError;
    public TextMeshProUGUI TextProSolution;
	private string texto;
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        int protective = sockets.URobot.regs[(int)sockets.RegisterNames.isProtectiveStopped].GetData();
    	int emergency = sockets.URobot.regs[(int)sockets.RegisterNames.isEmergencyStopped].GetData();
    	int safetySignal = sockets.URobot.regs[(int)sockets.RegisterNames.isSafetySignalSuchThatWeShouldStop].GetData();
    	//protective = 1;
        //emergency = 1;
    	if(protective == 1) {
    		Alerta.SetActive(true);
    		TextProError.text = "Protective Stop!";
            TextProSolution.text = "This is the solution for this error";
    	}

    	else if(emergency == 1) {
            TextProError.text = "Emergency Stop!";
            TextProSolution.text = "This is the solution for this error";
            Alerta.SetActive(true);
        }

    	else if(safetySignal == 1) {
            TextProError.text = "Safety Signal!";
            TextProSolution.text = "This is the solution for this error";
            Alerta.SetActive(true);
        }
    	else Alerta.SetActive(false);
        
    }
}
