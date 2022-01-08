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
    private int nb;
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
		if(cannettes.Count == 6)
			flag = true;
    }

    // Update is called once per frame
    void Update()
    {
		if(flag){
			nb = 0;

			if (yBase <= GetComponent<Chambouletout>().transform.position.y - 0.03 && chute[num] == 0)
			{
				chute[num] = 1;;
			}
			
			Debug.Log(num);
			Debug.Log(chute[num]);

			for (int i = 0; i < cannettes.Count; i++)
			{
				if (chute[i] == 1)
					nb++;
			}

			//Debug.Log("NB :");
			//Debug.Log(nb);

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
					if (cp == 500)
					{
						cp = 0;
						remiseAZero();
					}
					else
						cp++;
				}
			}
		}
    }

    public void rotation(double angle)
    {
        GetComponent<Chambouletout>().transform.rotation = new Quaternion((float)angle, (float)90.0, (float)0.0, (float)1.0);
    }

    public static void remiseAZero()
    {
		flag = false;
        for(int i = 0; i < cannettes.Count; i++) {
            
            cannettes[i].transform.position = new Vector3(cannettes[i].xBase, cannettes[i].yBase, cannettes[i].zBase);
            cannettes[i].transform.rotation = new Quaternion((float)0.0, (float)-90.0, (float)-90.0, (float)1.0);
        }
		for(int i = 0; i < cannettes.Count; i++) {
			chute[i] = 0;
		}
		flag = true;
    }
}
