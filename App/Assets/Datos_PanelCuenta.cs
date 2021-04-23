using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Datos_PanelCuenta : MonoBehaviour
{
    // Start is called before the first frame update
	public TextMeshProUGUI TextProNombre;
	public TextMeshProUGUI TextProCorreo;
    public TextMeshProUGUI TextProMasInfo;

	private string nombre;
	private string puesto;
    private string permissions;
    private string conexion;
	private string correo;
	private int totalMoviles;
	private int movilesPorHora;
	private int consumoPorHora;

    private bool alguienConectado;

    private  string Dia;
    private  string Mes;
    private  string Hora;
    private  string Minut;
    private  string Segon;
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
    	//Llegir de la base de dades 
        //string pos = sockets.BaseDatos.ultimo_usuario[0];
        //Debug.Log(pos);
        
        if(sockets.BaseDatos.ultimo_usuario[8] == "True") alguienConectado = true;
        else alguienConectado = false;
        Hora = sockets.BaseDatos.ultimo_usuario[1];
        Minut = sockets.BaseDatos.ultimo_usuario[2];
        Segon = sockets.BaseDatos.ultimo_usuario[3];
        Dia = sockets.BaseDatos.ultimo_usuario[4];
        Mes = sockets.BaseDatos.ultimo_usuario[5];
        nombre = sockets.BaseDatos.ultimo_usuario[6];
        correo = sockets.BaseDatos.ultimo_usuario[7];
        permissions = "All";
        //Debug.Log(alguienConectado);
        conexion = String.Format(
            "{0}/{1} at {2}:{3}:{4}",
            Dia,
            Mes,
            Hora,
            Minut,
            Segon
        );

        if(alguienConectado){
            
    	   puesto = "Operator";
    	   TextProNombre.text = "Hi " + nombre;
    	   TextProCorreo.text = correo;
           TextProMasInfo.text = puesto + "\nPermissions: " + permissions + "\nConnected on " + conexion;
        }
        else{
            TextProNombre.text = "No One";
            TextProCorreo.text = "Log in";
            TextProMasInfo.text = "Last connection at "  + conexion;
        }

        
    }
}
