const startButton = document.getElementById("start-btn") //START BUTTON
const nextButton = document.getElementById("next-btn") //NEXT BUTTON
const questionContainer = document.getElementById("question-container") //QUESTION CONTAINER
const questionElment = document.getElementById("question") //QUESTION TITLE
const answerButtonsElment = document.getElementById("answer-buttons") //ANSWER BUTTONS
const scoreSpan = document.getElementById("scoreSpan") // SCORE ELEMENT
let shuffledQuestions, currentQuestionIndex
let score = 0

//Start Quiz on click
startButton.addEventListener("click", startQuiz)
nextButton.addEventListener("click", () => {
    currentQuestionIndex++
    setNextQuestion()
})

//QUIZ START
function startQuiz() {
    score = 0
    updateScore()
    startButton.classList.add("hide")
    shuffledQuestions = questionArray.sort(() => Math.random() - .5) //RANDOMLY SORT
    currentQuestionIndex = 0
    questionContainer.classList.remove("hide")
    setNextQuestion()
}

//GET NEXT QUESTION
function setNextQuestion() {
    reset()
    showQuestion(shuffledQuestions[currentQuestionIndex])
}

//DISPLAY QUESTION & ANSWERS
function showQuestion(question) {
    questionElment.innerText = question.question
    question.answers.forEach(answer => {
        const button = document.createElement("button")
        button.innerText = answer.text
        button.classList.add("btn-answer")
        if (answer.correct) {
            button.dataset.correct = answer.correct
        }
        button.addEventListener("click", selectAnswer)
        answerButtonsElment.appendChild(button)
    })
}

//RESET BUTTONS
function reset() {
    nextButton.classList.add("hide")
    while (answerButtonsElment.firstChild) {
        answerButtonsElment.removeChild(answerButtonsElment.firstChild)
    }
}

//SELECT ANSWER
function selectAnswer(a) {
    const selectedButton = a.target
    const correct = selectedButton.dataset.correct
    setStatusClass(document.body, correct)
    Array.from(answerButtonsElment.children).forEach(button => {
        setStatusClass(button, button.dataset.correct)
    })
    if (correct) {
        score++
        updateScore()
    }
    if (shuffledQuestions.length > currentQuestionIndex + 1) {
        nextButton.classList.remove("hide")
    } else {
        startButton.innerText = "Restart"
        startButton.classList.remove("hide")
    }
}

//SET ANSWER CLASSES
function setStatusClass(element, correct) {
    clearStatusClass(element)
    if (correct) {
        element.classList.add("correct")
    } else {
        element.classList.add("wrong")
    }
}

//REMOVE ANSWER CLASSES
function clearStatusClass(element) {
    element.classList.remove("correct")
    element.classList.remove("wrong")
}

//UPDATE SCORE
function updateScore() {
    scoreSpan.innerText = "Score: " + score.toString()
}