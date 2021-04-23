using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opcioes_F : MonoBehaviour{
    // Start is called before the first frame update
    public GameObject panelFiltro;
    void Start(){
        panelFiltro.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        
    }
    public void desactivar_menu(){
        panelFiltro.SetActive(false);

    }

    public void filtro(){
        if (panelFiltro.active) panelFiltro.SetActive(false);
        else if (!panelFiltro.active) panelFiltro.SetActive(true);
    }
}
