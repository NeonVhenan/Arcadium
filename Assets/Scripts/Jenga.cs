using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jenga : MonoBehaviour
{
    static List<Jenga> blocsRestants = new List<Jenga>();
    static List<Jenga> blocs = new List<Jenga>();
    static int blocsRetires = 0;
    float xBase, yBase, zBase;

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

    }

    public static void remiseAZero()
    {
        blocsRestants = blocs;
        foreach (Jenga bloc in blocs)
        {
        }
    }

    public static bool testECHEC()
    {
        bool test = false;
        foreach (Jenga bloc in blocsRestants)
        {
            if ((bloc.transform.position.x > bloc.xBase + 0.1 || bloc.transform.position.x < bloc.xBase - 0.1)
                && (bloc.transform.position.y > bloc.yBase + 0.1 || bloc.transform.position.y < bloc.yBase - 0.1)
                && (bloc.transform.position.z > bloc.zBase + 0.1 || bloc.transform.position.z < bloc.zBase - 0.1))
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
