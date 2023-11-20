# Word Games Project Documentation

## Project Overview

The Word Games project encompasses a set of Unity scripts that handle various word-based games. The three main scripts are `FlashCardManager`, `QuizManager`, and `WordGameManager`. Each script manages a different word game with distinct features.

## FlashCardManager

### Description

![p1](https://github.com/MateuszKulis/UnityEnglishSchool/blob/main/mobile1.png)


The `FlashCardManager` script handles a flashcard-style game for learning vocabulary. Players are presented with a random English word and must input its Polish translation. Correct answers earn points, while incorrect answers result in point deductions. The game concludes when the player reaches zero points.


### Components

- `Text englishText`: Displays the current word in English.
- `TextMeshProUGUI pointsText`: Displays the number of points earned.
- `InputField answerField`: Text field where players input their answers.
- `Image backgroundImage`: Image background that changes based on answer correctness.
- `Sprite correctBackground`: Background sprite for correct answers.
- `Sprite incorrectBackground`: Background sprite for incorrect answers.

### Methods

- `Start()`: Initializes the game, loads flashcards from a file, and selects the first one.
- `UpdatePointsText()`: Updates the text displaying the number of points.
- `LoadFlashcardsFromFile(string path)`: Loads flashcards from a text file.
- `ChooseRandomFlashcard()`: Selects a random flashcard for display.
- `GetRandomKey(Dictionary<string, string> dictionary)`: Retrieves a random key from the dictionary.
- `DisplayFlashcard(string english)`: Displays the English word.
- `CheckAnswer(string userAnswer)`: Checks the answer's correctness, updates points, and proceeds to the next flashcard.

## QuizManager

### Description

![p2](https://github.com/MateuszKulis/UnityEnglishSchool/blob/main/mobile2.png)


The `QuizManager` script manages a quiz with questions and multiple-choice answers. Players must select the correct answer to proceed to the next question. After completing the quiz, a message indicates the end of the quiz.

### Components

- `Question[] questions`: Array of questions and answers.
- `int currentQuestionIndex`: Index of the current question.
- `TextMeshProUGUI questionText`: Text field displaying the current question.
- `ToggleGroup answerToggleGroup`: Group of toggles for answer selection.
- `Button nextButton`: Button for advancing to the next question.

### Methods

- `Start()`: Initializes questions and displays the first one.
- `ShowQuestion()`: Displays the current question and answers.
- `NextQuestion()`: Checks the answer correctness and proceeds to the next question.

### Question Class

- `string question`: Question text.
- `string[] answers`: Array of possible answers.
- `string correctAnswer`: Correct answer.

## WordGameManager

### Description

![p3](https://github.com/MateuszKulis/UnityEnglishSchool/blob/main/mobile3.png)


The `WordGameManager` script manages a word game where players must guess hidden letters in a word.

### Components

- `Text wordDisplay`: Text field displaying the current word with hidden letters.
- `InputField inputField`: Text field where players input their guesses.
- `Text resultText`: Text field displaying the result of the previous round.
- `Text scoreText`: Text field displaying the current score.

### Methods

- `Start()`: Starts a new game.
- `StartNewGame()`: Starts a new game, resetting the score, selecting a new word, and hiding some letters.
- `CreatePartialWord(string fullWord)`: Creates a hidden word by randomly replacing some letters with underscores.
- `CheckAnswer()`: Checks the player's answer, updates the score, and starts a new game.
- `UpdateScoreText()`: Updates the text field displaying the score.

## Installation

To use this project, add the scripts to objects in the Unity scene and assign the appropriate fields.

## Usage Examples

1. Run the game.
2. Depending on the selected game, input answers to earn points or guess hidden letters.
3. Monitor scores and progress in the game.
