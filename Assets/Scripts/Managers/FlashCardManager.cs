using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class FlashCardManager : MonoBehaviour
{
    [SerializeField] private Text englishText;
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private InputField answerField;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Sprite correctBackground;
    [SerializeField] private Sprite incorrectBackground;

    private Dictionary<string, string> flashcards;
    private string currentFlashcardEnglish;
    private int points = 5;

    private void Start()
    {
        LoadFlashcardsFromFile("Assets/words.txt");
        ChooseRandomFlashcard();

        UpdatePointsText(); 
    }

    private void UpdatePointsText()
    {
        pointsText.text = points.ToString();
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
        if (flashcards == null)
        {
            flashcards = new Dictionary<string, string>();
        }
        else
        {
            flashcards.Clear(); 
        }

        string[] lines = System.IO.File.ReadAllLines(path);

        foreach (string line in lines)
        {
            string[] parts = line.Split('-');
            if (parts.Length == 2)
            {
                string englishWord = parts[0].Trim();
                string polishTranslation = parts[1].Trim();

                if (!flashcards.ContainsKey(englishWord))
                {
                    flashcards.Add(englishWord, polishTranslation);
                }
                else
                {
                    Debug.LogWarning("Duplicate key found: " + englishWord);
                }
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
            backgroundImage.sprite = correctBackground;
            points += 1;
        }
        else
        {
            backgroundImage.sprite = incorrectBackground;
            points -= 1;
        }

        UpdatePointsText(); 

        if (points <= 0)
        {
            Debug.Log("Game Over!");
        }
        else
        {
            ChooseRandomFlashcard();
        }
    }
}
