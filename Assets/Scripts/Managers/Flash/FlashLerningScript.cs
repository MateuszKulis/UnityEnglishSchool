using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class FlashLernignScript : MonoBehaviour
{
    public TextMeshProUGUI englishText;
    public InputField answerField;

    private Dictionary<string, string> flashcards;
    private string currentFlashcardEnglish;

    private void Start()
    {
        // Load flashcards from a text file at the start of the game.
        LoadFlashcardsFromFile("path/to/your/file.txt");

        // Start the game with a random flashcard.
        ChooseRandomFlashcard();
    }

    private void Update()
    {
        // Accept user input when the Enter key is pressed.
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckAnswer(answerField.text);
        }
    }

    private void LoadFlashcardsFromFile(string path)
    {
        flashcards = new Dictionary<string, string>();

        string[] lines = System.IO.File.ReadAllLines(path);

        foreach (string line in lines)
        {
            string[] parts = line.Split('-');
            if (parts.Length == 2)
            {
                flashcards.Add(parts[0].Trim(), parts[1].Trim());
            }
        }
    }

    private void ChooseRandomFlashcard()
    {
        currentFlashcardEnglish = GetRandomKey(flashcards);
        DisplayFlashcard(currentFlashcardEnglish);
    }

    private string GetRandomKey(Dictionary<string, string> dictionary)
    {
        List<string> keys = new List<string>(dictionary.Keys);
        int randomIndex = Random.Range(0, keys.Count);
        return keys[randomIndex];
    }

    private void DisplayFlashcard(string english)
    {
        // Display the English word in the user interface.
        englishText.text = english;
        // Clear the answer field.
        answerField.text = "";
    }

    private void CheckAnswer(string userAnswer)
    {
        string correctAnswer = flashcards[currentFlashcardEnglish];

        if (userAnswer.Trim().ToLower() == correctAnswer.Trim().ToLower())
        {
            Debug.Log("Correct answer!");
            ChooseRandomFlashcard(); // Move to the next flashcard.
        }
        else
        {
            Debug.Log("Incorrect answer. Try again.");
        }
    }
}
