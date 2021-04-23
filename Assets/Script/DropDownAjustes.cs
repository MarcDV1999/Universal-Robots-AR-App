using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DropDownAjustes : MonoBehaviour
{
    private Animator buttonAnim2;
    private Boton boton2;
    // Start is called before the first frame update
    void Start()
    {
        buttonAnim2 = GetComponent<Animator>();
        boton2 = GameObject.Find("Code").GetComponent<Boton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boton2.showMenuAjustes) buttonAnim2.SetBool("B_mostrar_menu_ajustes", true);
        else if (!boton2.showMenuAjustes) buttonAnim2.SetBool("B_mostrar_menu_ajustes", false);


    }
 
    
}
