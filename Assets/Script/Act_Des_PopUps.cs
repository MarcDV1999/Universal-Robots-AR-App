using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Act_Des_PopUps : MonoBehaviour{
    // Start is called before the first frame update
    public Sprite b_activado;
    public Sprite b_desactivado;

    public Sprite bombilla_activado;
    public Sprite bombilla_desactivado;

    public GameObject Pop1;
    public GameObject Pop2;
    public GameObject Pop3;
    public GameObject Pop4;
    public GameObject Pop5;
    public GameObject Pop6;
    public GameObject OTool;

    public GameObject Bombilla;
	public GameObject B1;
    public GameObject B2;
    public GameObject B3;
    public GameObject B4;
    public GameObject B5;
    public GameObject B6;
    public GameObject BTool;
    

    
    public bool activar1 = true;
    public bool activar2 = true;
    public bool activar3 = true;
    public bool activar4 = true;
    public bool activar5 = true;
    public bool activar6 = true;
    public bool activarTool = true;
    public bool actvarTodos = true;
    
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){}

    public void Todos(){
        if(actvarTodos){
            Bombilla.GetComponent<Image>().sprite = bombilla_desactivado;
            
            Pop1.SetActive(false);
            B1.GetComponent<Image>().sprite = b_desactivado;
            
            Pop2.SetActive(false);
            B2.GetComponent<Image>().sprite = b_desactivado;
            
            Pop3.SetActive(false);
            B3.GetComponent<Image>().sprite = b_desactivado;
            
            Pop4.SetActive(false);
            B4.GetComponent<Image>().sprite = b_desactivado;
            
            Pop5.SetActive(false);
            B5.GetComponent<Image>().sprite = b_desactivado;

            Pop6.SetActive(false);
            B6.GetComponent<Image>().sprite = b_desactivado;

            OTool.SetActive(false);
            BTool.GetComponent<Image>().sprite = b_desactivado;
            activar1 = activar2 = activar3 = activar4 = activar5 = activar6 = activarTool = false;
        }
        else{
            Bombilla.GetComponent<Image>().sprite = bombilla_activado;
            Pop1.SetActive(true);
            B1.GetComponent<Image>().sprite = b_activado;

            Pop2.SetActive(true);
            B2.GetComponent<Image>().sprite = b_activado;

            Pop3.SetActive(true);
            B3.GetComponent<Image>().sprite = b_activado;

            Pop4.SetActive(true);
            B4.GetComponent<Image>().sprite = b_activado;

            Pop5.SetActive(true);
            B5.GetComponent<Image>().sprite = b_activado;

            Pop6.SetActive(true);
            B6.GetComponent<Image>().sprite = b_activado;

            OTool.SetActive(true);
            BTool.GetComponent<Image>().sprite = b_activado;
            activar1 = activar2 = activar3 = activar4 = activar5 = activar6 = activarTool = true;
        }
        actvarTodos = !actvarTodos;
    }

    public void Popup1(){
    	if(activar1) {
    		Pop1.SetActive(false);
    		B1.GetComponent<Image>().sprite = b_desactivado;
    	}
    	else {
    		Pop1.SetActive(true);
    		B1.GetComponent<Image>().sprite = b_activado;
    	}
    	activar1 = !activar1;
    }
    public void Popup2(){
    	if(activar2) {
    		Pop2.SetActive(false);
    		B2.GetComponent<Image>().sprite = b_desactivado;
    	}
    	else {
    		Pop2.SetActive(true);
    		B2.GetComponent<Image>().sprite = b_activado;
    	}
    	activar2 = !activar2;
    }

    public void Popup3(){
    	if(activar3) {
    		Pop3.SetActive(false);
    		B3.GetComponent<Image>().sprite = b_desactivado;
    	}
    	else {
    		Pop3.SetActive(true);
    		B3.GetComponent<Image>().sprite = b_activado;
    	}
    	activar3 = !activar3;
    }


    public void Popup4(){
    	if(activar4) {
    		Pop4.SetActive(false);
    		B4.GetComponent<Image>().sprite = b_desactivado;
    	}

    	else {
    		Pop4.SetActive(true);
    		B4.GetComponent<Image>().sprite = b_activado;
    	}
    	activar4 = !activar4;
    }


    public void Popup5(){
    	if(activar5) {
    		Pop5.SetActive(false);
    		B5.GetComponent<Image>().sprite = b_desactivado;
    	}
    	else {
    		Pop5.SetActive(true);
    		B5.GetComponent<Image>().sprite = b_activado;
    	}
    	activar5 = !activar5;
    }


    public void Popup6(){
    	if(activar6) {
    		Pop6.SetActive(false);
    		B6.GetComponent<Image>().sprite = b_desactivado;
    	}
    	else {
    		Pop6.SetActive(true);
    		B6.GetComponent<Image>().sprite = b_activado;
    	}
    	activar6 = !activar6;
    }


    public void Tool(){
    	if(activarTool) {
    		OTool.SetActive(false);
    		BTool.GetComponent<Image>().sprite = b_desactivado;
    	}
    	else {
    		OTool.SetActive(true);
    		BTool.GetComponent<Image>().sprite = b_activado;
    	}
    	activarTool = !activarTool;
    }
}
