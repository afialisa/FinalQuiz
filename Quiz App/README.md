Overview
The "Pop Up" Quiz Application is a Windows-based tool developed in VB.NET, designed to run immediately after an employee logs in. 
The quiz focuses on data protection and privacy awareness and cannot be closed until all questions have been answered.

Features
Mandatory Quiz Completion: The quiz cannot be closed or minimized until all questions are answered, ensuring that employees engage fully with the content.
Single-Choice Questions: Each question has three answer options (A, B, C), and users can select only one answer.

Automatic Evaluation: The application checks selected answers against correct ones stored in the database, providing immediate feedback.
Project Structure
The project consists of:

Form1.vb: Main form that displays questions and options.
This application uses an embedded JSON object to store quiz questions and answers.

API Integration: A backend API was integrated to manage responses and retrieve questions dynamically.
