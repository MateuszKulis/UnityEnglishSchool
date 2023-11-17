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
        LoadFlashcardsFromFile("path/to/your/file.txt");

        ChooseRandomFlashcard();
    }

    private void Update()
    {
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
        englishText.text = english;
        answerField.text = "";
    }

    private void CheckAnswer(string userAnswer)
    {
        string correctAnswer = flashcards[currentFlashcardEnglish];

        if (userAnswer.Trim().ToLower() == correctAnswer.Trim().ToLower())
        {
            Debug.Log("Correct answer!");
            ChooseRandomFlashcard(); 
        }
        else
        {
            Debug.Log("Incorrect answer. Try again.");
        }
    }
}
