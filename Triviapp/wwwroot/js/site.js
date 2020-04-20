const startButton = document.getElementById("start-btn") //START BUTTON
const nextButton = document.getElementById("next-btn") //NEXT BUTTON
const quitButton = document.getElementById("quit-btn") //QUIT BUTTON
const questionContainer = document.getElementById("question-container") //QUESTION CONTAINER
const questionElment = document.getElementById("question") //QUESTION TITLE
const answerButtonsElment = document.getElementById("answer-buttons") //ANSWER BUTTONS
const completedContainer = document.getElementById("completed-container") //END GAME CONTAINER
const scoreElement = document.getElementById("score") //SCORE ELEMENT
const scoreTitle = document.getElementById("scoreTitle") //SCORE TITLE

const scoreValue = document.getElementById("scoreValue");


let shuffledQuestions, currentQuestionIndex
let score = 0

//QUIT BUTTON
quitButton.addEventListener("click", quitGame)
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
    startButton.classList.add("hide")
    completedContainer.classList.add("hide")
    shuffledQuestions = questionArray.sort(() => Math.random() - .5) //RANDOMLY SORT QUESTIONS
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
    selectedButton.classList.add("selected")
    Array.from(answerButtonsElment.children).forEach(button => {
        setStatusClass(button, button.dataset.correct)
        button.setAttribute("disabled", true)
    })
    //CORRECT ANSWER
    if (correct) {
        score++
    }
    //CARRY ON GAME
    if (shuffledQuestions.length > currentQuestionIndex + 1) {
        nextButton.classList.remove("hide")
    } else {
        //END GAME LOGIC
        completedContainer.classList.remove("hide")
        updateScore()
        scoreValue.value = score
        questionContainer.classList.add("hide")
        startButton.innerText = "Restart" 
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
    let totalScore = score.toString()
    let numberOfQuestions = questionArray.length
    scoreElement.innerText = totalScore + "/" + numberOfQuestions
    if (score == numberOfQuestions) {
        scoreTitle.innerText = "Congratulations! You perfectly scored:"
    } else if (score > 0) {
        scoreTitle.innerText = "Not bad! You scored:"
    } else {
        scoreTitle.innerText = "You suck... You scored:"
    }
}

//QUIT GAME
function quitGame() {
    window.location.href = '/Quizzes/Browse'
}