var startButton = document.getElementById("start-btn")
var questionContainer = document.getElementById("question-container")
var questionElment = document.getElementById("question")
var answerButtonsElment = document.getElementById("answer-buttons")
let  shuffledQuestions, currentQuestionIndex

startButton.addEventListener("click", startQuiz)




function startQuiz() {
    startButton.classList.add("hide")
    shuffledQuestions = questionArray.sort(() => Math.random() - .5)
    currentQuestionIndex = 0
    questionContainer.classList.remove("hide")
    setNextQuestion()
}

function setNextQuestion() {
    showQuestion(shuffledQuestions[currentQuestionIndex])
}

function showQuestion(question) {
    questionElment.innerText = question.question
}

function selectAnswer() {
    
}