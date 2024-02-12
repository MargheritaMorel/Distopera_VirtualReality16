using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisable : MonoBehaviour
{
    public GameObject canva;

    public void Trigger(){
        if(canva.activeInHierarchy == false){
            canva.SetActive(true);
        }
        else{
            canva.SetActive(false);
        }
    }
}
