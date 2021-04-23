using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning_intermitente : MonoBehaviour{
    // Start is called before the first frame update
    public GameObject Warnings;
    public static bool activar_Warning0;
    public static bool activar_Warning1;
    public static bool activar_Warning3;
    public static bool activar_Warning4;
    public static bool activar_Warning5;
    public static bool activar_Warning6;
    public static bool activar_WarningTool;
    private int contador = 0;
    private bool b = false;
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
    	if(activar_Warning0 || activar_Warning1 || activar_Warning3 || activar_Warning4 || activar_Warning5 || activar_Warning6 || activar_WarningTool){
    		if(contador == 30){
    			b = !b;
    			contador = 0;
    		}
    		else contador++;
    		Warnings.SetActive(b);
    	}
    	else{
    		Warnings.SetActive(false);
    	}
    }
}
