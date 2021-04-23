using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    private Animator animacion;
    private Boton boton;

    public GameObject BotonDesplegar;
    public Sprite Menu_activado;
    public Sprite Menu_desactivado;

// Start is called before the first frame update
void Start(){
        animacion = GetComponent<Animator>();
        boton = GameObject.Find("Code").GetComponent<Boton>();
    }

    // Update is called once per frame
    void Update(){
        if (boton.showMenuPerfil){
            animacion.SetBool("B_mostrar_perfil", true);
            BotonDesplegar.GetComponent<Image>().sprite = Menu_activado;
        }
        else if (!boton.showMenuPerfil) {
            animacion.SetBool("B_mostrar_perfil", false);
            BotonDesplegar.GetComponent<Image>().sprite = Menu_desactivado;
        }

    }
}
