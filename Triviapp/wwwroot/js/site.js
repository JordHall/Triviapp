const startButton = document.getElementById("start-btn") //START BUTTON
const nextButton = document.getElementById("next-btn") //NEXT BUTTON
const quitButton = document.getElementById("quit-btn") //QUIT BUTTON
const questionContainer = document.getElementById("question-container") //QUESTION CONTAINER
const questionElment = document.getElementById("question") //QUESTION TITLE
const answerButtonsElment = document.getElementById("answer-buttons") //ANSWER BUTTONS
const scoreSpan = document.getElementById("scoreSpan") // SCORE ELEMENT

let shuffledQuestions, currentQuestionIndex
let score = 0

//START QUIZ ON CLICK
startButton.addEventListener("click", startQuiz)
//NEXT QUESTION
nextButton.addEventListener("click", () => {
    currentQuestionIndex++
    setNextQuestion()
})

//START QUIZ
function startQuiz() {
    score = 0
    updateScore()
    startButton.classList.add("hide")
    shuffledQuestions = questionArray.sort(() => Math.random() - .5) //RANDOMLY SORT
    currentQuestionIndex = 0
    questionContainer.classList.remove("hide")
    setNextQuestion()
}

//NEXT QUESTION
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
        //SET ANSWER TO CORRECT
        if (answer.correct) {
            button.dataset.correct = answer.correct
        }
        //RUN SELECT ANSWER ON CLICK
        button.addEventListener("click", selectAnswer)
        answerButtonsElment.appendChild(button)
    })
}

//RESET BUTTONS
function reset() {
    nextButton.classList.add("hide")
    clearStatusClass(document.body)
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
        startButton.innerText = "Restart" //END GAME LOGIC
        startButton.classList.remove("hide")
        quitButton.classList.remove("hide")
    }
}

//SET ANSWER STATUS
function setStatusClass(element, correct) {
    clearStatusClass(element)
    if (correct) {
        element.classList.add("correct")
    } else {
        element.classList.add("wrong")
    }
}

//REMOVE ANSWER STATUS
function clearStatusClass(element) {
    element.classList.remove("correct")
    element.classList.remove("wrong")
}

//UPDATE SCORE
function updateScore() {
    scoreSpan.innerText = "Score: " + score.toString()
}