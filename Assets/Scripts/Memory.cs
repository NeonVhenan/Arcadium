using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Memory : MonoBehaviour
{
    // game variables
    static int ERRORS_MAX = 15;
    public static int erreur = 0;
    static bool flag = false;
    static int numCards = 18;
    static List<Memory> cartes = new List<Memory>();
    public static List<Memory> carteTirees = new List<Memory>();
    static int pair;
    public bool isFacingCard = false;
    Material front;
    static List<int> ordre = new List<int>();
    public static bool finDePartie = false;


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

    public static void remiseAZero()
    {
        erreur = 0;
        carteTirees = new List<Memory>();
        foreach (Memory carte in cartes) 
        {
            carte.isFacingCard = false;
            if (carte.transform.rotation.x == -90)
                carte.rotation(90.0);
        }
        placement();
        finDePartie = false;
    }

    static void testVictoire()
    {
        if (pair * 2 == numCards)
        {
            GameStateManager.jeuxGagnes++;
            Canvas.canvas.SetActive(true);
            Canvas.canvasMessage.text = "VICTOIRE";
            GameStateManager.jeuxGagnes++;
            finDePartie = true;
        }
    }

    static void testDefaite()
    {
        if(erreur >= ERRORS_MAX)
        {
            Canvas.canvas.SetActive(true);
            Canvas.canvasMessage.text = "ECHEC";
            GameStateManager.jeuxGagnes++;
            finDePartie = true;
        }

    }

    public void rotation(double angle)
    {
        GetComponent<Memory>().transform.rotation = new Quaternion((float)angle, (float)0.0, (float)0.0, (float)1.0);
    }

    static void placement()
    {
        ordre = new List<int>();
        for(int i = 0; i < 18; i++)
        {
            ordre.Add(i);
        }
        int tmp;
        int num1, num2;
        for(int i = 0; i < 18; i++)
        {
            num1 = UnityEngine.Random.Range(0, 18);
            tmp = ordre[num1];
            num2 = UnityEngine.Random.Range(0, 18);
            ordre[num1] = ordre[num2];
            ordre[num2] = tmp;
        }
        cartes[ordre[0]].transform.position = new Vector3((float)4.5, (float)3.67, (float)-7.5);
        cartes[ordre[1]].transform.position = new Vector3((float)4.5, (float)3.67, (float)-7.0);
        cartes[ordre[2]].transform.position = new Vector3((float)4.5, (float)3.67, (float)-7.5);
        cartes[ordre[3]].transform.position = new Vector3((float)4.0, (float)3.67, (float)-6.5);
        cartes[ordre[4]].transform.position = new Vector3((float)4.0, (float)3.67, (float)-7.0);
        cartes[ordre[5]].transform.position = new Vector3((float)4.0, (float)3.67, (float)-7.5);
        cartes[ordre[6]].transform.position = new Vector3((float)4.5, (float)3.67, (float)-6.5);
        cartes[ordre[7]].transform.position = new Vector3((float)4.5, (float)3.67, (float)-7.0);
        cartes[ordre[8]].transform.position = new Vector3((float)4.5, (float)3.67, (float)-7.5);
        cartes[ordre[9]].transform.position = new Vector3((float)5.0, (float)3.67, (float)-6.5);
        cartes[ordre[10]].transform.position = new Vector3((float)5.0, (float)3.67, (float)-7.0);
        cartes[ordre[11]].transform.position = new Vector3((float)5.0, (float)3.67, (float)-7.5);
        cartes[ordre[12]].transform.position = new Vector3((float)5.5, (float)3.67, (float)-6.5);
        cartes[ordre[13]].transform.position = new Vector3((float)5.5, (float)3.67, (float)-7.0);
        cartes[ordre[14]].transform.position = new Vector3((float)5.5, (float)3.67, (float)-7.5);
        cartes[ordre[15]].transform.position = new Vector3((float)6.0, (float)3.67, (float)-6.5);
        cartes[ordre[16]].transform.position = new Vector3((float)6.0, (float)3.67, (float)-7.0);
        cartes[ordre[17]].transform.position = new Vector3((float)6.0, (float)3.67, (float)-7.5);
    }
}
