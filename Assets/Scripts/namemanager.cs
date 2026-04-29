using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class namemanager : MonoBehaviour
{
    [Header("Teksty wyświetlane")]
    public TMP_Text imie;        
    public TMP_Text nazw;        

    [Header("Pola wpisywania (Inputy)")]
    public TMP_InputField podajim;
    public TMP_InputField podajnazw;

    [Header("Guzik do schowania")]
    public GameObject zatwim;

    [Header("Zdjęcia")]
    public GameObject fociatyl;   // To, co widać NA POCZĄTKU
    public GameObject fociaprzod; // To, co widać PO KLIKNIĘCIU

    public static string imieGracza;
    public static string nazwiskoGracza;
    public float czasWidocznosci = 3f;

    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            gameObject.SetActive(false);
            return;
        }
        // Upewniamy się, że na start widać tylko tył
        if (fociatyl != null) fociatyl.SetActive(true);
        if (fociaprzod != null) fociaprzod.SetActive(false);
    }

    public void zapiszimie()
    {
        string daneImie = podajim.text;
        string daneNazwisko = podajnazw.text;

        if (!string.IsNullOrEmpty(daneImie))
        {
            imieGracza = daneImie;
            nazwiskoGracza = daneNazwisko;

            PlayerPrefs.SetString("PlayerName", daneImie);
            PlayerPrefs.SetString("PlayerSurname", daneNazwisko);
            PlayerPrefs.Save();

            WyswietlIZatwierdz(daneImie, daneNazwisko);
        }
    }

    private void WyswietlIZatwierdz(string i, string n)
    {
        imie.text = "Twoje imie: " + i;

        if (!string.IsNullOrEmpty(n))
        {
            nazw.text = "Twoje nazwisko: " + n;
            nazw.gameObject.SetActive(true);
        }
        else
        {
            nazw.gameObject.SetActive(false);
        }

        // --- MAGIA ZDJĘĆ ---
        if (fociatyl != null) fociatyl.SetActive(false);   // Gasimy tył
        if (fociaprzod != null) fociaprzod.SetActive(true); // Zapalamy przód

        // Reszta chowania
        if (podajim != null) podajim.gameObject.SetActive(false);
        if (podajnazw != null) podajnazw.gameObject.SetActive(false);
        if (zatwim != null) zatwim.SetActive(false);
        StartCoroutine(ZamknijPanelPoChwili());
    }
    private IEnumerator ZamknijPanelPoChwili()
    {
        yield return new WaitForSeconds(czasWidocznosci);
        gameObject.SetActive(false);
    }
}