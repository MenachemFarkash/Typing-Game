using TMPro;
using UnityEngine;

public class TextComponent : MonoBehaviour {
    public char activationLetter;
    public string word;
    public char[] brokenWord;
    public TextMeshPro text;
    public bool isFocused;
    public int wordLength;

    TypingEngine typingEngine;


    private void Start() {
        text.text = word;
        brokenWord = word.ToCharArray();
        wordLength = brokenWord.Length - 1;

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

    public void RemoveLetterFromWord(int indexToRemove) {
        if (indexToRemove < wordLength) {

            brokenWord[indexToRemove] = '_';
            string charsStr = new string(brokenWord);
            text.text = charsStr;
            typingEngine.currentLetterIndex++;
        } else {
            Destroy(gameObject);
            typingEngine.ResetForNextWord();
        }
    }

    public void SetWordAsFocused() {
        isFocused = true;
    }

    public void AbbortFromWord() {

    }
}
