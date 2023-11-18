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
                question = "Jakie s³owo jest synonimem dla 'happy'?",
                answers = new string[] { "Smutny", "Radosny", "Z³y" },
                correctAnswer = "Radosny"
            },
            new Question
            {
                question = "Jaki jest liczba mnoga dla s³owa 'child'?",
                answers = new string[] { "Children", "Childs", "Childies" },
                correctAnswer = "Children"
            },
            new Question
            {
                question = "Wybierz poprawn¹ pisowniê: 'Receive' czy 'Recieve'?",
                answers = new string[] { "Receive", "Recieve", "Receve" },
                correctAnswer = "Receive"
            },
            new Question
            {
                question = "Która czêœæ mowy opisuje s³owo 'quickly'?",
                answers = new string[] { "Przymiotnik", "Przys³ówek", "Czasownik" },
                correctAnswer = "Przys³ówek"
            },
            new Question
            {
                question = "Jaki jest czas przesz³y dla s³owa 'go'?",
                answers = new string[] { "Gone", "Goed", "Went" },
                correctAnswer = "Went"
            },
            new Question
            {
                question = "ZnajdŸ antonim dla s³owa 'benevolent'.",
                answers = new string[] { "Dobry", "Z³oœliwy", "Przyjazny" },
                correctAnswer = "Z³oœliwy"
            },
            new Question
            {
                question = "W którym zdaniu s³owo 'ubiquitous' jest u¿yte poprawnie?",
                answers = new string[] { "S³oñce zachodzi na zachodzie, wszechobecne na horyzoncie.", "Ludzie wszechobecni czêsto lubi¹ czytaæ ksi¹¿ki.", "Wszechobecne to trudne s³owo do przeliterowania." },
                correctAnswer = "Wszechobecne to trudne s³owo do przeliterowania."
            },
            new Question
            {
                question = "Które zdanie jest zdaniem z³o¿onym?",
                answers = new string[] { "Ona lubi czytaæ ksi¹¿ki.", "Lubiê graæ w tenisa i p³ywaæ.", "Zjad³ pyszne ciasto." },
                correctAnswer = "Lubiê graæ w tenisa i p³ywaæ."
            },
            new Question
            {
                question = "Jaka jest poprawna kolejnoœæ alfabetu?",
                answers = new string[] { "A, Z, B, Y, C, X", "A, B, C, D, E", "Z, Y, X, W, V" },
                correctAnswer = "A, B, C, D, E"
            },
            new Question
            {
                question = "Które zdanie jest w stronie biernej?",
                answers = new string[] { "Kot goni³ mysz.", "Mysz by³a goni³a przez kota.", "Dokoñczê pracê jutro." },
                correctAnswer = "Mysz by³a goni³a przez kota."
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
