using TMPro;
using UnityEngine;

public class TextComponent : MonoBehaviour {
    public char activationLetter;
    public string word;
    public char[] brokenWord;
    public TextMeshPro text;
    public bool isFocused;

    TypingEngine typingEngine;


    private void Start() {
        text.text = word;
        brokenWord = word.ToCharArray();

        typingEngine = TypingEngine.instance;

        typingEngine.AddCharToInitialsToAttack(activationLetter);

    }

    public void Update() {
        if (isFocused) {
            text.fontSize = 7;
        } else {
            text.fontSize = 5;
        }
    }

    public void RemoveLetterFromWord() {
        brokenWord = brokenWord.ToString().Remove(0, 1).ToCharArray();
    }

    public void SetWordAsFocused() {
        print("This cube is now the focus");
    }

    public void AbbortFromWord() {

    }
}
