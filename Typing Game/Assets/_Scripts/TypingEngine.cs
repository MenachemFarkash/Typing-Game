using System;
using System.Collections.Generic;
using UnityEngine;

public class TypingEngine : MonoBehaviour {
    #region Singleton
    public static TypingEngine instance;

    private void Awake() {
        instance = this;
    }

    #endregion

    public List<string> wordToType;
    public List<char> initialsToAttack;

    private List<string> lettersArray;

    public TextComponent focusedComponent;


    public int currentLetterIndex;

    public string lastLetterTyped;

    public GameObject cubesContainer;
    public string[] cubes;



    // Start is called before the first frame update
    void Start() {
        wordToType = new List<string> { };
        currentLetterIndex = 0;
        lettersArray = new List<string>();
        PopulateLettersArray();


    }

    // Update is called once per frame
    void Update() {
        if (Input.anyKeyDown) {
            lastLetterTyped = Input.inputString;
            for (int i = 0; i < lettersArray.Count; i++) {
                if (lastLetterTyped.Equals(lettersArray[i])) {

                    if (CheckIfLetterInInitials(lastLetterTyped.ToCharArray()[0])) {

                        focusedComponent = FindCubeWithInitial(lastLetterTyped.ToCharArray()[0]);
                        focusedComponent.SetWordAsFocused();

                        SetWordAsWordToType();

                    };
                    return;
                }
            }
        }
    }

    private void PopulateLettersArray() {
        int foreachCounter = 0;
        foreach (string kcode in Enum.GetNames(typeof(KeyCode))) {
            foreachCounter++;
            if (foreachCounter > 122) {
                return;
            }

            if (kcode.Length == 1) {
                lettersArray.Add(kcode);
                lettersArray.Add(kcode.ToLower());
            }
        }
    }

    public void TypeLetter(string letter) {
        if (letter == wordToType[currentLetterIndex]) {
            print(wordToType[currentLetterIndex]);
            currentLetterIndex++;
        }
    }

    public bool CheckIfLetterInInitials(char letter) {
        for (int i = 0; i < initialsToAttack.Count; i++) {
            if (initialsToAttack[i] == letter) {
                print(letter + " Found In Initials");
                return true;
            }
        }
        print(letter + " Not Found In Initials");
        return false;
    }

    public TextComponent FindCubeWithInitial(char initial) {
        foreach (TextComponent comp in cubesContainer.GetComponentsInChildren<TextComponent>()) {
            if (comp.activationLetter == initial) {
                return comp;
            }
        }

        return null;
    }

    public void SetWordAsWordToType() {
        foreach (char letter in focusedComponent.brokenWord) {
            wordToType.Add(letter.ToString());
        }
    }
    public void AddCharToInitialsToAttack(char charToAdd) {
        initialsToAttack.Add(charToAdd);
    }
    public void RemoveCharToInitialsToAttack(char charToRemove) {
        initialsToAttack.Add(charToRemove);
    }
}
