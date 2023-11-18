using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public Question[] questions; 
    private int currentQuestionIndex = 0; 

    public TextMeshProUGUI questionText; 
    public ToggleGroup answerToggleGroup; 
    public Button nextButton; 

    private void Start()
    {

        questions = new Question[]
       {
            new Question
            {
                question = "Jakie s�owo jest synonimem dla 'happy'?",
                answers = new string[] { "Smutny", "Radosny", "Z�y" },
                correctAnswer = "Radosny"
            },
            new Question
            {
                question = "Jaki jest liczba mnoga dla s�owa 'child'?",
                answers = new string[] { "Children", "Childs", "Childies" },
                correctAnswer = "Children"
            },
            new Question
            {
                question = "Wybierz poprawn� pisowni�: 'Receive' czy 'Recieve'?",
                answers = new string[] { "Receive", "Recieve", "Receve" },
                correctAnswer = "Receive"
            },
            new Question
            {
                question = "Kt�ra cz�� mowy opisuje s�owo 'quickly'?",
                answers = new string[] { "Przymiotnik", "Przys��wek", "Czasownik" },
                correctAnswer = "Przys��wek"
            },
            new Question
            {
                question = "Jaki jest czas przesz�y dla s�owa 'go'?",
                answers = new string[] { "Gone", "Goed", "Went" },
                correctAnswer = "Went"
            },
            new Question
            {
                question = "Znajd� antonim dla s�owa 'benevolent'.",
                answers = new string[] { "Dobry", "Z�o�liwy", "Przyjazny" },
                correctAnswer = "Z�o�liwy"
            },
            new Question
            {
                question = "W kt�rym zdaniu s�owo 'ubiquitous' jest u�yte poprawnie?",
                answers = new string[] { "S�o�ce zachodzi na zachodzie, wszechobecne na horyzoncie.", "Ludzie wszechobecni cz�sto lubi� czyta� ksi��ki.", "Wszechobecne to trudne s�owo do przeliterowania." },
                correctAnswer = "Wszechobecne to trudne s�owo do przeliterowania."
            },
            new Question
            {
                question = "Kt�re zdanie jest zdaniem z�o�onym?",
                answers = new string[] { "Ona lubi czyta� ksi��ki.", "Lubi� gra� w tenisa i p�ywa�.", "Zjad� pyszne ciasto." },
                correctAnswer = "Lubi� gra� w tenisa i p�ywa�."
            },
            new Question
            {
                question = "Jaka jest poprawna kolejno�� alfabetu?",
                answers = new string[] { "A, Z, B, Y, C, X", "A, B, C, D, E", "Z, Y, X, W, V" },
                correctAnswer = "A, B, C, D, E"
            },
            new Question
            {
                question = "Kt�re zdanie jest w stronie biernej?",
                answers = new string[] { "Kot goni� mysz.", "Mysz by�a goni�a przez kota.", "Doko�cz� prac� jutro." },
                correctAnswer = "Mysz by�a goni�a przez kota."
            }
       };

        ShowQuestion();


    }

    private void ShowQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            questionText.text = questions[currentQuestionIndex].question;

            foreach (Toggle toggle in answerToggleGroup.ActiveToggles())
            {
                toggle.isOn = false;
            }

            for (int i = 0; i < answerToggleGroup.transform.childCount; i++)
            {
                Toggle toggle = answerToggleGroup.transform.GetChild(i).GetComponent<Toggle>();
                toggle.isOn = false;

                if (i < questions[currentQuestionIndex].answers.Length)
                {
                    toggle.gameObject.SetActive(true);
                    toggle.GetComponentInChildren<Text>().text = questions[currentQuestionIndex].answers[i];
                }
                else
                {
                    toggle.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            questionText.text = "Quiz completed!";
            nextButton.interactable = false;
        }
    }

    public void NextQuestion()
    {
        Toggle selectedToggle = answerToggleGroup.ActiveToggles().FirstOrDefault();

        if (selectedToggle != null)
        {
            if (selectedToggle.GetComponentInChildren<Text>().text == questions[currentQuestionIndex].correctAnswer)
            {
                Debug.Log("Correct!");
            }
            else
            {
                Debug.Log("Incorrect!");
            }

            currentQuestionIndex++;
            ShowQuestion();
        }
        else
        {
            Debug.Log("Please select an answer.");
        }
    }
}

[System.Serializable]
public class Question
{
    public string question; 
    public string[] answers; 
    public string correctAnswer; 
}
