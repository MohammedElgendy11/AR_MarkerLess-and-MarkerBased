using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersSelection : MonoBehaviour
{
    public static int scaleCharacter;
    public GameObject[] _Models;
    public int SelectedModel = 0;

    // Start is called before the first frame update
    void Start()
    {
        HideAllCharacters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //this function is called at the start of the game 
    private void HideAllCharacters()
    {
        foreach (GameObject go in _Models)
        {
            go.SetActive(false);
        }
    }
    public void SetActiveCharacters(int index)
    {
        scaleCharacter = index;
        if (index >= 0 && index < _Models.Length)
        {
            for (int i = 0; i < _Models.Length; i++)
            {
                _Models[i].SetActive(false);
            }

            _Models[index].SetActive(true);
        }
    }



}
