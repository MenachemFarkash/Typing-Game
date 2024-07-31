using UnityEngine;

public class TypingEngine : MonoBehaviour {

    public string[] words;
    public int currentLetterIndex;

    public string lastLetterTyped;

    // Start is called before the first frame update
    void Start() {
        words = new string[] { "a", "b", "c", "d", "e" };
        currentLetterIndex = 0;
    }

    // Update is called once per frame
    void Update() {
        if (Input.anyKeyDown && currentLetterIndex <= words.Length - 1) {
            lastLetterTyped = Input.inputString;
            TypeLetter(lastLetterTyped);
        }
    }

    public void TypeLetter(string letter) {
        if (letter == words[currentLetterIndex]) {
            print(words[currentLetterIndex]);
            currentLetterIndex++;
        }
    }
}
