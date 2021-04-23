using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour
{
    public bool showMenuPerfil;
    public bool showMenuAjustes;

    public void ButtonShowMenuPerfil(){
        showMenuPerfil = !showMenuPerfil;
        
    }

    public void ButtonShowMenuAjustes(){
        showMenuAjustes = !showMenuAjustes;
        //Debug.Log("He entrado");
    }

}
