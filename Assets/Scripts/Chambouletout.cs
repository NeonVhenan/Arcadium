using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chambouletout : MonoBehaviour
{
    static List<Chambouletout> cannettes = new List<Chambouletout>();
    static List<int> chute = new List<int>();
    float yBase, xBase, zBase;
    public static bool finDePartie = false;
    public AudioSource _gameover;
    static int cp = 0;
    static int nb;
    static bool flag = false;
    int num;

    // Start is called before the first frame update
    void Start()
    {
        cannettes.Add(GetComponent<Chambouletout>());

        yBase = GetComponent<Chambouletout>().transform.position.y;
        xBase = GetComponent<Chambouletout>().transform.position.x;
        zBase = GetComponent<Chambouletout>().transform.position.z;
        chute.Add(0);
        num = cannettes.Count - 1;
    }

    // Update is called once per frame
    void Update()
    {
        nb = 0;
            Debug.Log("Base : ");
            Debug.Log(yBase);
            Debug.Log("valeur : ");
            Debug.Log(GetComponent<Chambouletout>().transform.position.y - 0.1);

            if (yBase < GetComponent<Chambouletout>().transform.position.y - 0.1)
            {

                chute[num] = 1;
            }

        for (int i = 0; i < cannettes.Count; i++)
        {
            if (chute[i] == 1)
                nb++;
        }

        Debug.Log("NB :");
        Debug.Log(nb);

        if (nb == cannettes.Count)
        {
            Debug.Log(cp);
            if (cp == 0)
            {
                _gameover.Play();
                cp++;
            }
            else
            {
                if (cp == 1000)
                {
                    cp = 0;
                    remiseAZero();
                }
                else
                    cp++;
            }
        }
    }

    public void rotation(double angle)
    {
        GetComponent<Chambouletout>().transform.rotation = new Quaternion((float)angle, (float)0.0, (float)0.0, (float)1.0);
    }

    public static void remiseAZero()
    {
        for(int i = 0; i < cannettes.Count; i++) {
            
            cannettes[i].transform.position = new Vector3(cannettes[i].xBase, cannettes[i].yBase, cannettes[i].zBase);
            cannettes[i].rotation(-90.0); //= new Quaternion(90.0, cannettes[i].xBase, cannettes[i].yBase, cannettes[i].zBase);
        }
    }
}
