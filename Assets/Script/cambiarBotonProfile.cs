using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cambiarBotonProfile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject b;
	public Sprite b_activado;
    public Sprite b_desactivado;
    public bool estado = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(estado) b.GetComponent<Image>().sprite = b_activado;
    	else b.GetComponent<Image>().sprite = b_desactivado;
        
    }
}
