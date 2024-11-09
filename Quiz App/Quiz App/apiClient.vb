Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks

Public Class ApiClient
    Private Shared ReadOnly client As New HttpClient()

    ' Method to send quiz response
    Public Async Function SubmitResponse(userId As String, questionId As Integer, selectedOption As String) As Task(Of String)
        'Dim url As String = "http://localhost:3000/submit-response"' ' Your API endpoint

        Dim url As String = "https://mysp.enterprisegroup.net.gh:5005/api/v1/did-you-know"
        'Dim requestBody As String = $"{{""user_id"": ""{userId}"", ""question_id"": {questionId}, ""selected_option"": ""{selectedOption}""}}"'

        Dim requestBody As String = $"{{""username"": ""{userId}"", ""question"": ""{questionId}"", ""answer"": ""{selectedOption}"" }}"
        Dim content As New StringContent(requestBody, Encoding.UTF8, "application/json")

        Dim response As HttpResponseMessage = Await client.PostAsync(url, content)

        If response.IsSuccessStatusCode Then
            Return Await response.Content.ReadAsStringAsync()
        Else
            Return $"Error: {response.StatusCode} - {response.ReasonPhrase}"
        End If
    End Function


    'Public Async Function getQuestions() As Task(Of String)
    '    Dim url As String = "http://localhost:3000/questions" ' API endpoint
    '    Dim response As HttpResponseMessage = Await client.GetAsync(url)
    '    If response.IsSuccessStatusCode Then
    '        Return Await response.Content.ReadAsStringAsync()
    '        Return $"Error: {response.StatusCode} - {response.ReasonPhrase}"
    '    End If
    'End Function

    Public Async Function getQuestions() As Task(Of String)
        Dim url As String = "https://mysp.enterprisegroup.net.gh:5005/api/v1/questions-answers" ' API endpoint
        Dim response As HttpResponseMessage = Await client.GetAsync(url)

        Console.Write(response)
        Console.Write(response.IsSuccessStatusCode)

        If response.IsSuccessStatusCode Then
            Return Await response.Content.ReadAsStringAsync()
            Return $"Error: {response.StatusCode} - {response.ReasonPhrase}"
        End If
    End Function
End Class
