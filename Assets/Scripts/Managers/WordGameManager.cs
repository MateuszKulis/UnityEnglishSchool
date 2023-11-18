using UnityEngine;
using UnityEngine.UI;

public class WordGameManager : MonoBehaviour
{
    public Text wordDisplay;
    public InputField inputField;
    public Text resultText;
    public Text scoreText;

    private string[] words = { "apple", "banana", "computer", "dog", "elephant" };
    private string currentWord;
    private int score = 0;

    void Start()
    {
        StartNewGame();
    }

    void StartNewGame()
    {
        score = 0;
        UpdateScoreText();

        currentWord = words[Random.Range(0, words.Length)];

        string partialWord = CreatePartialWord(currentWord);

        wordDisplay.text = partialWord;

        inputField.text = "";

        resultText.text = "";
    }

    string CreatePartialWord(string fullWord)
    {
        int length = fullWord.Length;
        int charsToHide = Mathf.Min(length / 2, 2); 
        string partialWord = fullWord;

        for (int i = 0; i < charsToHide; i++)
        {
            int randomIndex = Random.Range(0, length);
            partialWord = partialWord.Remove(randomIndex, 1).Insert(randomIndex, "_");
        }

        return partialWord;
    }

    public void CheckAnswer()
    {
        string playerAnswer = inputField.text.ToLower();
        if (playerAnswer == currentWord)
        {
            resultText.text = "Poprawna odpowiedŸ!";
            score++;
            UpdateScoreText();
        }
        else
        {
            resultText.text = "B³êdna odpowiedŸ. Spróbuj ponownie.";
        }

        Invoke("StartNewGame", 2f);
    }

    void UpdateScoreText()
    {
        scoreText.text = "Wynik: " + score;
    }
}
