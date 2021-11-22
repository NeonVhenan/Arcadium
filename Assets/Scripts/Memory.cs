using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Memory : MonoBehaviour
{
    // game variables
    static int ERRORS_MAX = 5;
    public static int erreur = 0;
    static bool flag = false;
    static int numCards = 18;
    static List<Memory> cartes = new List<Memory>();
    public static List<Memory> carteTirees = new List<Memory>();
    static int pair;
    public bool isFacingCard = false;
    Material front;


    // Start is called before the first frame update
    void Start()
    {
        if (!flag)
        {
            cartes.Add(this);
            front = GetComponent<Renderer>().materials[1];
            if (cartes.Count == numCards)
            {
                flag = true;
                placement();
            }
        }
    }

    void Update()
    {
        /*if (name.StartsWith("erreur"))
        {
            switch (errors)
            {
                case 1:
                    spriteRenderer.sprite = erreur4;
                    break;
                case 2:
                    spriteRenderer.sprite = erreur3;
                    break;
                case 3:
                    spriteRenderer.sprite = erreur2;
                    break;
                case 4:
                    spriteRenderer.sprite = erreur1;
                    break;
                case 5:
                    spriteRenderer.sprite = erreur0;
                    break;
            }
        }*/
    }


    public static void testCarte()
    {
        if(carteTirees.Count >= 2 && carteTirees.Count % 2 == 0)
        {
            if(carteTirees[carteTirees.Count - 2].front == carteTirees[carteTirees.Count - 1].front)
            {
                pair++;
                testVictoire();
            }
            else
            {
                carteTirees[carteTirees.Count - 2].rotation(90.0);
                carteTirees[carteTirees.Count - 1].rotation(90.0);
                erreur++;
                testDefaite();
            }
        }
    }

    static void remiseAZero()
    {

    }

    static void testVictoire()
    {
        if (pair*2 == numCards)
            GameStateManager.jeuxGagnes++;
    }

    static void testDefaite()
    {

    }

    public void rotation(double angle)
    {
        GetComponent<Memory>().transform.rotation = new Quaternion((float)angle, (float)0.0, (float)0.0, (float)1.0);
    }

    static void placement()
    {

    }
}
