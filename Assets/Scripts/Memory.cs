using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Memory : MonoBehaviour
{
    // game variables
    private static int ERRORS_MAX = 5;
    public static int errors = 0;
    private static bool flag = false;
    int numCards = 18;
    private static List<Memory> cartes = new List<Memory>();
    private static List<Memory> carteTirees = new List<Memory>();
    private static List<CardID> spritesName = new List<CardID>();
    // card variables
    private bool isFacingCard = false;
    Material front;


    // Start is called before the first frame update
    void Start()
    {
        if (!flag)
        {
            cartes.Add(this);
            front = cartes.GetComponent<Renderer>().materials[1];
            if (cartes.size() == numCards)
            {
                flag = true;
                //lancer le random pour avoir les positions des cartes
            }
        }
    }

    void Update()
    {
        if (name.StartsWith("erreur"))
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
        }
    }

    /// <summary>
    ///  Appel� sur chaque gameobject avec le script ET boxcollider
    /// </summary>
    void OnMouseDown() //This function is called each time player clicks on GameObject
    {
        if (!isFacingCard && CompareLastTwoCards())
        {
            isFacingCard = true;
            switch (name)
            {
                case "card1":
                    ChangeSide(spritesName[0]);
                    break;
                case "card2":
                    ChangeSide(spritesName[1]);
                    break;
                case "card3":
                    ChangeSide(spritesName[2]);
                    break;
                case "card4":
                    ChangeSide(spritesName[3]);
                    break;
                case "card5":
                    ChangeSide(spritesName[4]);
                    break;
                case "card6":
                    ChangeSide(spritesName[5]);
                    break;
                case "card7":
                    ChangeSide(spritesName[6]);
                    break;
                case "card8":
                    ChangeSide(spritesName[7]);
                    break;
                case "card9":
                    ChangeSide(spritesName[8]);
                    break;
                case "card10":
                    ChangeSide(spritesName[9]);
                    break;
                case "card11":
                    ChangeSide(spritesName[10]);
                    break;
                case "card12":
                    ChangeSide(spritesName[11]);
                    break;
            }
        }
    }

    void ChangeSide(CardID cardID)
    {
        switch (cardID)
        {
            case CardID.SUN:
                spriteRenderer.sprite = sun;
                carteTirees.Add(this);
                break;
            case CardID.ASTEROID:
                spriteRenderer.sprite = asteroid;
                carteTirees.Add(this);
                break;
            case CardID.BANANA:
                spriteRenderer.sprite = banana;
                carteTirees.Add(this);
                break;
            case CardID.SATELLITE:
                spriteRenderer.sprite = satellite;
                carteTirees.Add(this);
                break;
            case CardID.MOON:
                spriteRenderer.sprite = moon;
                carteTirees.Add(this);
                break;
            case CardID.ALIENSHIP:
                spriteRenderer.sprite = alien_ship_alt;
                carteTirees.Add(this);
                break;
            case CardID.CARDBACK:
                spriteRenderer.sprite = card_back;
                break;
        }
        Debug.Log(carteTirees.Count);
        if (carteTirees.Count % 2 == 0 && carteTirees.Count != 0)
        { // v�rification
            if (carteTirees[carteTirees.Count - 2].spriteRenderer.sprite.name == carteTirees[carteTirees.Count - 1].spriteRenderer.sprite.name)
            { // victoire
                if (carteTirees.Count == 12)
                {
                    Debug.Log("Victoire");
                    SceneManager.LoadScene("Corridor_AA");
                }
            }
            else
            {
                errors++;
                if (errors == ERRORS_MAX)
                { // d�faite
                    Debug.Log("D�faite");
                    SceneManager.LoadScene("Hangar_AB");
                }
                StartCoroutine(Reset());
            }
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(1);
        carteTirees[carteTirees.Count - 2].spriteRenderer.sprite = card_back;
        carteTirees[carteTirees.Count - 2].isFacingCard = false;
        carteTirees[carteTirees.Count - 1].spriteRenderer.sprite = card_back;
        carteTirees[carteTirees.Count - 1].isFacingCard = false;
        carteTirees.RemoveAt(carteTirees.Count - 1);
        carteTirees.RemoveAt(carteTirees.Count - 1);
        yield return null;
    }

    /// <summary>
    /// Retourne vrai si les 2 dernieres cartes sont == ou si il n'y a pas 2 cartes.
    /// </summary>
    /// <returns></returns>
    bool CompareLastTwoCards()
    {
        if (carteTirees.Count >= 2 && carteTirees.Count % 2 == 0)
        {
            return carteTirees[carteTirees.Count - 2].front == carteTirees[carteTirees.Count - 1].front;
        }
        else
        {
            return true;
        }
    }
}
