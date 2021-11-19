using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jenga : MonoBehaviour
{
    static List<Jenga> blocsRestants = new List<Jenga>();
    static List<Jenga> blocs = new List<Jenga>();
    static int blocsRetires = 0;
    float xBase, yBase, zBase;
    public bool selectionne = false;

    // Start is called before the first frame update
    void Start()
    {
        blocs.Add(GetComponent<Jenga>());
        blocsRestants.Add(GetComponent<Jenga>());
        xBase = transform.position.x;
        yBase = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (selectionne)
        {
            Jenga bloc = GetComponent<Jenga>();
            if (bloc.transform.position.x > bloc.xBase + 0.3)
            {
                selectionne = false;
                blocsRestants.Remove(bloc);
                if (testECHEC())
                {
                    //message ECHEC
                    Canvas.canvas.SetActive(true);
                    Canvas.canvasMessage.text = "ECHEC";
                }
                else
                {
                    blocsRetires++;
                    if (testVICTOIRE())
                    {
                        //message VICTOIRE
                        Canvas.canvas.SetActive(true);
                        Canvas.canvasMessage.text = "ECHEC";
                        GameStateManager.jeuxGagnes++;
                    }
                }
            }
        }
    }

    public static void remiseAZero()
    {
        Canvas.canvas.SetActive(false);
        blocsRestants = blocs;
        foreach (Jenga bloc in blocs)
        {
            bloc.transform.position = new Vector3(bloc.xBase, bloc.yBase, bloc.zBase);
            bloc.selectionne = false;
        }
        blocsRetires = 0;

    }

    public static bool testECHEC()
    {
        bool test = false;
        foreach (Jenga bloc in blocsRestants)
        {
            if ((bloc.transform.position.x > bloc.xBase + 0.05 || bloc.transform.position.x < bloc.xBase - 0.05)
                && (bloc.transform.position.y > bloc.yBase + 0.05 || bloc.transform.position.y < bloc.yBase - 0.05)
                && (bloc.transform.position.z > bloc.zBase + 0.05 || bloc.transform.position.z < bloc.zBase - 0.05))
                test = true;
        }
        return test;
    }

    public static bool testVICTOIRE()
    {
        if (blocsRetires > 6)
            return true;
        return false;
    }
}
