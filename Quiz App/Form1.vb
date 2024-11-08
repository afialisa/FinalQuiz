Imports System.Drawing.Text
Imports MySql.Data.MySqlClient
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net.Http
Imports System.Text
Imports Mysqlx.XDevAPI.Common
Imports System.Runtime.InteropServices.JavaScript
'Imports Microsoft.Win32

Public Class Form1
    Private conn As MySqlConnection
    Private questionsData As JObject
    Private currentQuestionIndex As Integer = 0
    Private totalQuestions As Integer = 8
    Private correctAnswers As Integer = 0
    Private quizCompleted As Boolean = False
    Private questions As New List(Of DataRow)
    Private username As String = Environment.UserName

    'Private question_two As String = Data

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.None
        'Me.WindowState = FormWindowState.Maximized'
        'Me.ControlBox = False'
        'Me.TopMost = True'

        AddToStartup()

        If LoadQuestions() Then
            If questions.Count > 0 Then
                LoadQuestion(currentQuestionIndex)
            Else
                MessageBox.Show("No questions available in the database.")
            End If
        Else
            MessageBox.Show("An error occurred while loading questions.")
        End If
    End Sub
    Private Sub AddToStartup()
        Try
            ' Setting up the  startup registry path
            Dim startupPath As String = Application.ExecutablePath
            'Dim regKey As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)'

            'If regKey.GetValue("EmployeeQuiz") Is Nothing Then
            '    regKey.SetValue("EmployeeQuiz", startupPath)
            'End If
            'regKey.Close()
        Catch ex As Exception
            MessageBox.Show("Could not set up startup: " & ex.Message)
        End Try
    End Sub

    Private Function LoadQuestions() As Boolean
        Try
            conn = New MySqlConnection("server=localhost;userid=root;password='pa$$word';database=quizdb")
            Dim adapter As New MySqlDataAdapter("SELECT * FROM questions_answers", conn)
            Dim table As New DataTable()

            conn.Open()
            adapter.Fill(table)

            If table.Rows.Count = 0 Then
                Return False
            End If

            ' Randomize and limit questions
            Dim rnd As New Random()
            questions = table.Select().OrderBy(Function(x) rnd.Next()).Take(totalQuestions).ToList()

            Return True
        Catch ex As Exception
            MessageBox.Show("Error loading questions: " & ex.Message)
            Return False
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Function

    Private Sub LoadQuestionAA(index As Integer)
        If index >= 0 And index < questions.Count Then
            Dim questionRow As DataRow = questions(index)
            lbl_question.Text = questionRow("questiontext").ToString()
            rbOptionA.Text = questionRow("optionA").ToString().Trim()
            rbOptionB.Text = questionRow("optionB").ToString().Trim()
            rbOptionC.Text = questionRow("optionC").ToString().Trim()

            ' Reset radio buttons
            rbOptionA.Checked = False
            rbOptionB.Checked = False
            rbOptionC.Checked = False
        End If
    End Sub

    Private Sub LoadQuestion(index As Integer)
        'Dim jsonString As String = "{ ""employees"": [ { ""name"": ""John"", ""age"": 30, ""city"": ""New York"" }, { ""name"": ""Anna"", ""age"": 25, ""city"": ""London"" }, { ""name"": ""Mike"", ""age"": 32, ""city"": ""Chicago"" } ] }"
        Dim jsonString As String = "{""questions_answers"": {" &
" ""1"": { ""question"": ""What is the process of safeguarding personal information from unauthorised use, disclosure, compromise or loss?"", ""optionA"": ""Data Collection"", ""optionB"": ""Data Protection"",  ""optionC"": ""Data Retention"", ""correctOption"": ""Data Protection"" }, " &
" ""2"": { ""question"": ""Which document enshrines data protection laws in Ghana?"", ""optionA"": ""Data Protection Act,2012 (Act 843)"", ""optionB"": ""General Data Protection Regulation(GDPR)"",  ""optionC"": ""Data Privacy Policy"", ""correctOption"": ""Data Protection Act,2012 (Act 843)"" }, " &
" ""3"": { ""question"": ""Personal Data means"", ""optionA"": ""Information which can be used to identify an individual"", ""optionB"": ""Information about an organization"",  ""optionC"": ""Information about security agencies"", ""correctOption"": ""Information which can be used to identify an individual"" }, " &
" ""4"": { ""question"": ""The following are all examples of Personal Data except:"", ""optionA"": ""name"", ""optionB"": ""Age range"",  ""optionC"": ""address"", ""correctOption"": ""Age range"" }, " &
" ""5"": { ""question"": ""Which of the following is Special Personal Data?"", ""optionA"": ""Telephone Number"", ""optionB"": ""Voice"",  ""optionC"": ""Ethnic Origin"", ""correctOption"": ""Ethnic Origin"" }, " &
" ""6"": { ""question"": ""Which of the following is Not Special Personal Data?"", ""optionA"": ""Name"", ""optionB"": ""Sexual Orientation"",  ""optionC"": ""Political Views"", ""correctOption"": ""Name"" }, " &
" ""7"": { ""question"": ""A data subject is"", ""optionA"": ""A company which can be identified from the personal data"", ""optionB"": ""A living individual who can be identified from personal data"",  ""optionC"": ""An individual (dead or alive) who can be identified from personal data"", ""correctOption"": ""Name"" }, " &
" ""8"": { ""question"": ""The following are all examples of 'data subjects' except:"", ""optionA"": ""Employees of Enterprise Group"", ""optionB"": ""Enterprise Insurance Ltd"",  ""optionC"": ""Customers of Enterprise Life Assurance LTD"", ""correctOption"": ""Enterprise Insurance Ltd""} " &
" } }"


        ' Parse JSON
        'Dim jsonObject As JObject = JObject.Parse(jsonString)

        Dim i As Integer = 1

        'MessageBox.Show(index)
        Dim jsonObj As JObject = JObject.Parse(jsonString)

        ' Access the "questions_answers" part of the JSON and deserialize it into a Dictionary
        Dim questionsJson As JObject = jsonObj("questions_answers")


        Dim data As RootObject = JsonConvert.DeserializeObject(Of RootObject)(jsonString)


        'MessageBox.Show(data.questions_answers(2).question)


        ' Loop through the employees array
        'For Each ques_ans In data.questions_answers.Keys

        'Dim questionObj = data.questions_answers(2)
        If index >= 0 And index < 8 Then
            'Dim iii As Integer = 0
            'MessageBox.Show(index)
            'Dim ii As Integer = iii + 1

            ''iii = ii

            'MessageBox.Show(index)

            'Dim questionRow As DataRow = questions(index)
            lbl_question.Text = data.questions_answers(index + 1).question
            rbOptionA.Text = data.questions_answers(index + 1).optionA
            rbOptionB.Text = data.questions_answers(index + 1).optionB
            rbOptionC.Text = data.questions_answers(index + 1).optionC

            ' Reset radio buttons
            rbOptionA.Checked = False
            rbOptionB.Checked = False
            rbOptionC.Checked = False

        End If
        'Next
        'Dim selectedOption As String = GetSelectedOptionCharacter()

        ' Get the correct answer for the current question (assuming it's loaded in the `questions` collection)
        'Dim correctAnswer As String = questionsData("questions_answers")(currentQuestionIndex.ToString())("correctOption").ToString()

    End Sub

    Public Class RootObject
        Public Property questions_answers As Dictionary(Of String, Question)
    End Class

    Public Class Question
        Public Property question As String
        Public Property optionA As String
        Public Property optionB As String
        Public Property optionC As String
        Public Property correctOption As String
        Public Property correctCharacter As String
    End Class
    Public Class QuestionsAnswers
        Public Property questions_answers As Dictionary(Of String, Question)
    End Class
    Private Sub LoadQuestionCC(index As Integer)


        Dim dd = GetQuestionsFromApi()
        'Dim pp = JObject.Parse(dd)
        'MessageBox.Show(dd)



        Dim jsonString As String = "{ ""employees"": [ { ""name"": ""John"", ""age"": 30, ""city"": ""New York"" }, { ""name"": ""Anna"", ""age"": 25, ""city"": ""London"" }, { ""name"": ""Mike"", ""age"": 32, ""city"": ""Chicago"" } ] }"

        ' Parse JSON
        Dim jsonObject As JObject = JObject.Parse(jsonString)

        ' Loop through the employees array
        For Each employee As JObject In jsonObject("employees")
            Dim name As String = employee("name").ToString()
            Dim age As Integer = Convert.ToInt32(employee("age"))
            Dim city As String = employee("city").ToString()

            MessageBox.Show(name)
            MessageBox.Show(age)
            MessageBox.Show(city)

        Next
    End Sub

    'Private Async Function LoadQuestion() As Task
    '    Dim jsonData As String = Await FetchDataAsync()  ' Await the task to get the result
    '    Dim jsonObject As JObject = JObject.Parse(jsonData)  ' Parse the JSON string to JObject

    '    ' Example: Accessing a property in the JSON object
    '    Console.WriteLine("Fetched JSON: " & jsonObject.ToString())
    '    Console.WriteLine("Specific Data: " & jsonObject("specific_key").ToString())
    'End Function

    'Public Async Function FetchDataAsync() As Task(Of String)
    '    Using client As New HttpClient()
    '        Dim response As HttpResponseMessage = Await client.GetAsync("https://mysp.enterprisegroup.net.gh:5005/api/v1/questions-answers")
    '        response.EnsureSuccessStatusCode()
    '        Dim jsonData As String = Await response.Content.ReadAsStringAsync()
    '        Return jsonData
    '    End Using
    'End Function

    Private Async Sub btn_Submit_Click(sender As Object, e As EventArgs) Handles btn_Submit.Click
        Dim selectedOptionChar As String = GetSelectedOptionCharacter()

        Dim jsonString As String = "{""questions_answers"": {" &
" ""1"": { ""question"": ""What is the process of safeguarding personal information from unauthorised use, disclosure, compromise or loss?"", ""optionA"": ""Data Collection"", ""optionB"": ""Data Protection"",  ""optionC"": ""Data Retention"", ""correctOption"": ""Data Protection"", ""correctCharacter"": ""B"" }, " &
" ""2"": { ""question"": ""Which document enshrines data protection laws in Ghana?"", ""optionA"": ""Data Protection Act,2012 (Act 843)"", ""optionB"": ""General Data Protection Regulation(GDPR)"",  ""optionC"": ""Data Privacy Policy"", ""correctOption"": ""Data Protection Act,2012 (Act 843) (A)"", ""correctCharacter"": ""A"" }, " &
" ""3"": { ""question"": ""Personal Data means"", ""optionA"": ""Information which can be used to identify an individual"", ""optionB"": ""Information about an organization"",  ""optionC"": ""Information about security agencies"", ""correctOption"": ""Information which can be used to identify an individual (A)"", ""correctCharacter"": ""A"" }, " &
" ""4"": { ""question"": ""The following are all examples of Personal Data except:"", ""optionA"": ""name"", ""optionB"": ""Age range"",  ""optionC"": ""address"", ""correctOption"": ""Age range (B)"", ""correctCharacter"": ""B"" }, " &
" ""5"": { ""question"": ""Which of the following is Special Personal Data?"", ""optionA"": ""Telephone Number"", ""optionB"": ""Voice"",  ""optionC"": ""Ethnic Origin"", ""correctOption"": ""Ethnic Origin (C)"", ""correctCharacter"": ""C"" }, " &
" ""6"": { ""question"": ""Which of the following is Not Special Personal Data?"", ""optionA"": ""Name"", ""optionB"": ""Sexual Orientation"",  ""optionC"": ""Political Views"", ""correctOption"": ""Name (A)"", ""correctCharacter"": ""A"" }, " &
" ""7"": { ""question"": ""A data subject is"", ""optionA"": ""A company which can be identified from the personal data"", ""optionB"": ""A living individual who can be identified from personal data"",  ""optionC"": ""An individual (dead or alive) who can be identified from personal data"", ""correctOption"": ""Name (B)"", ""correctCharacter()"": ""B"" }, " &
" ""8"": { ""question"": ""The following are all examples of 'data subjects' except:"", ""optionA"": ""Employees of Enterprise Group"", ""optionB"": ""Enterprise Insurance Ltd"",  ""optionC"": ""Customers of Enterprise Life Assurance LTD"", ""correctOption"": ""Enterprise Insurance Ltd (B)"", ""correctCharacter"": ""B""} " &
" } }"


        ' Parse JSON
        'Dim jsonObject As JObject = JObject.Parse(jsonString)

        Dim i As Integer = 1

        'MessageBox.Show(index)
        Dim jsonObj As JObject = JObject.Parse(jsonString)

        ' Access the "questions_answers" part of the JSON and deserialize it into a Dictionary
        Dim questionsJson As JObject = jsonObj("questions_answers")


        Dim data As RootObject = JsonConvert.DeserializeObject(Of RootObject)(jsonString)


        If currentQuestionIndex >= 0 AndAlso currentQuestionIndex < questions.Count Then
            Dim correctAnswerChar As String = data.questions_answers(currentQuestionIndex + 1).correctCharacter
            Dim correctAnswerString As String = data.questions_answers(currentQuestionIndex + 1).correctOption


            'Dim correctAnswerChar As String = questions(currentQuestionIndex)("correctOption").ToString().Trim().ToUpper()
            Dim questionRow As DataRow = questions(currentQuestionIndex)
            Dim questionId As Integer = Convert.ToInt32(questionRow("questioni_id"))

            If Not rbOptionA.Checked AndAlso Not rbOptionB.Checked AndAlso Not rbOptionC.Checked Then
                MessageBox.Show("Please select an answer before proceeding.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            'Dim question = question_answers(currentQuestionIndex)
            'Dim correctAnswerChar As String = question.correctOption.Trim().ToUpper()
            Dim isCorrect As Boolean = (selectedOptionChar = correctAnswerChar)

            ' Debug output to verify selected and correct answers
            MessageBox.Show($"Selected: '{selectedOptionChar}' | Correct: '{correctAnswerString}'", "Debug Info")

            If selectedOptionChar = correctAnswerChar Then
                correctAnswers += 1
                MessageBox.Show("Correct answer!")
            Else
                MessageBox.Show($"Incorrect answer. The correct answer is: {correctAnswerString}")
            End If

            ' Save the response via the API
            MessageBox.Show(username)
            Await SubmitResponseToApi(username, questionId, selectedOptionChar, isCorrect) ' Replace 1 with actual user_id if applicable

            currentQuestionIndex += 1

            If currentQuestionIndex < totalQuestions AndAlso currentQuestionIndex < questions.Count Then
                LoadQuestion(currentQuestionIndex)
            Else
                MessageBox.Show($"You answered {correctAnswers} out of {totalQuestions} correctly.")
                quizCompleted = True
            End If
        Else
            MessageBox.Show("No more questions available.")
        End If

        If (quizCompleted) Then
            Me.Dispose()
        End If
    End Sub

    ' Function to send response to the API
    Private Async Function SubmitResponseToApi(userId As String, questionId As Integer, selectedOption As String, isCorrect As Boolean) As Task
        Dim apiClient As New ApiClient()
        Dim result As String = Await apiClient.SubmitResponse(userId.ToString(), questionId, selectedOption)
    End Function

    Private Async Function GetQuestionsFromApiOld() As Task
        Dim apiClient As New ApiClient()
        Dim result As String = Await apiClient.getQuestions()
        MessageBox.Show(result)

    End Function '

    Private Async Function GetQuestionsFromApi() As Task
        Dim apiUrl As String = "https://mysp.enterprisegroup.net.gh:5005/api/v1/questions-answers" ' Replace with the actual API endpoint

        Using client As New HttpClient()
            Try
                ' Send GET request to the API
                Dim response As HttpResponseMessage = Await client.GetAsync(apiUrl)

                ' Ensure the response is successful (Status Code 200 OK)
                response.EnsureSuccessStatusCode()

                ' Read the response content as a string
                Dim responseBody As String = Await response.Content.ReadAsStringAsync()

                ' Deserialize the JSON response into a List of ApiResponse objects
                Dim dataList As List(Of ApiResponse) = JsonConvert.DeserializeObject(Of List(Of ApiResponse))(responseBody)

                ' Loop through each item in the list and display the data
                MessageBox.Show("Data retrieved from API:")
                For Each item In dataList
                    MessageBox.Show("ID: " & item.Id)
                    MessageBox.Show("Name: " & item.Name)
                    MessageBox.Show("Description: " & item.Description)
                    MessageBox.Show("----")
                Next

            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
    End Function

    Public Class ApiResponse
        Public Property Id As Integer
        Public Property Name As String
        Public Property Description As String
    End Class


    Private Function GetSelectedOptionCharacter() As String
        If rbOptionA.Checked Then
            Return "A"
        ElseIf rbOptionB.Checked Then
            Return "B"
        ElseIf rbOptionC.Checked Then
            Return "C"
        End If
        Return String.Empty
    End Function

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not quizCompleted Then
            e.Cancel = True
            MessageBox.Show("You cannot close the application until you finish the quiz.")
        End If
    End Sub

    Private Sub lbl_question_Click(sender As Object, e As EventArgs) Handles lbl_question.Click

    End Sub
End Class