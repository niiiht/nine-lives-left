using UnityEngine;
using TMPro;

public class PlayerCard : MonoBehaviour
{
    public TMP_Text imieText;
    public TMP_Text nazwiskoText;

    void Start()
    {
        string imie = PlayerPrefs.GetString("PlayerName", "Brak");
        string nazwisko = PlayerPrefs.GetString("PlayerSurname", "");

        imieText.text = "Imiê: " + imie;
        nazwiskoText.text = "Nazwisko: " + nazwisko;
    }
}