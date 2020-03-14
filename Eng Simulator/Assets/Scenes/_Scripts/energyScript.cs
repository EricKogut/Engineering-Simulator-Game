using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class energyScript : MonoBehaviour
{

 
    public float amountLeft = PlayerMovement.energy/100;
    public Image content;  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        content.fillAmount = amountLeft;
        updateAmountLeft();
    }

     void updateAmountLeft(){
         amountLeft  = PlayerMovement.energy/100;   
     }

}
