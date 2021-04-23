using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Datos_NextStep : MonoBehaviour{
    // Start is called before the first frame update
    public GameObject panel;
    public TextMeshProUGUI textPro;
    private string moviment;
    private string ult_moviment;
    private Animator animacion;
    private bool conectat;
    private bool primer = true;
    private int contador = 0;
    void Start(){
        animacion = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update(){
        moviment = sockets.BaseDatos.moviments[1];
        if(sockets.BaseDatos.ultimo_usuario[8] == "True") conectat = true;
        else conectat = false;
        //Debug.Log("Movimiento actual = " + moviment);

        if(moviment != ult_moviment && conectat && moviment != "start") {
            //animacion.SetBool("showNextStep", true);
            textPro.text = moviment;
            if(primer){
                contador = 0;
                primer = false;
            }

          
        }

        //else animacion.SetBool("showNextStep", false);
        
        if (contador == 30*5){
             ult_moviment = moviment;
             contador = 0;
             primer = true;
         }
        else contador++;
        
    }
}
