<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        btn_Submit = New Button()
        lbl_question = New Label()
        rbOptionA = New RadioButton()
        Panel1 = New Panel()
        rbOptionC = New RadioButton()
        rbOptionB = New RadioButton()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' btn_Submit
        ' 
        btn_Submit.Font = New Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_Submit.Location = New Point(386, 338)
        btn_Submit.Name = "btn_Submit"
        btn_Submit.Size = New Size(75, 23)
        btn_Submit.TabIndex = 0
        btn_Submit.Text = "Submit"
        btn_Submit.UseVisualStyleBackColor = True
        ' 
        ' lbl_question
        ' 
        lbl_question.AutoSize = True
        lbl_question.Font = New Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lbl_question.Location = New Point(18, 44)
        lbl_question.Name = "lbl_question"
        lbl_question.Size = New Size(57, 15)
        lbl_question.TabIndex = 1
        lbl_question.Text = "Question"
        ' 
        ' rbOptionA
        ' 
        rbOptionA.AutoSize = True
        rbOptionA.Font = New Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbOptionA.Location = New Point(3, 17)
        rbOptionA.Name = "rbOptionA"
        rbOptionA.Size = New Size(67, 19)
        rbOptionA.TabIndex = 2
        rbOptionA.TabStop = True
        rbOptionA.Text = "optionA"
        rbOptionA.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(rbOptionC)
        Panel1.Controls.Add(rbOptionB)
        Panel1.Controls.Add(rbOptionA)
        Panel1.Location = New Point(34, 107)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(453, 182)
        Panel1.TabIndex = 3
        ' 
        ' rbOptionC
        ' 
        rbOptionC.AutoSize = True
        rbOptionC.Font = New Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbOptionC.Location = New Point(3, 130)
        rbOptionC.Name = "rbOptionC"
        rbOptionC.Size = New Size(67, 19)
        rbOptionC.TabIndex = 4
        rbOptionC.TabStop = True
        rbOptionC.Text = "optionC"
        rbOptionC.UseVisualStyleBackColor = True
        ' 
        ' rbOptionB
        ' 
        rbOptionB.AutoSize = True
        rbOptionB.Font = New Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbOptionB.Location = New Point(3, 74)
        rbOptionB.Name = "rbOptionB"
        rbOptionB.Size = New Size(67, 19)
        rbOptionB.TabIndex = 3
        rbOptionB.TabStop = True
        rbOptionB.Text = "optionB"
        rbOptionB.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        ControlBox = False
        Controls.Add(Panel1)
        Controls.Add(lbl_question)
        Controls.Add(btn_Submit)
        Name = "Form1"
        Text = "Quiz"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btn_Submit As Button
    Friend WithEvents lbl_question As Label
    Friend WithEvents rbOptionA As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rbOptionC As RadioButton
    Friend WithEvents rbOptionB As RadioButton

End Class
