using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public Question[] questions; 
    private int currentQuestionIndex = 0; 

    public Text questionText; 
    public ToggleGroup answerToggleGroup; 
    public Button nextButton; 

    private void Start()
    {
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
