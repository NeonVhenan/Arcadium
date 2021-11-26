using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemiseAZero : MonoBehaviour
{
    public string jeu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void remiseAZero()
    {
        switch (jeu)
        {
            case "Memory":
                Memory.remiseAZero();
                break;
            case "Jenga":
                Jenga.remiseAZero();
                break;
            case "Hanoi":
                Hanoi.remiseAZero();
                break;
            case "Simon":
                Simon.remiseAZero();
                break;
            case "Chambouletout":
                Chambouletout.remiseAZero();
                break;
            default:
                break;
        }
    }
}
