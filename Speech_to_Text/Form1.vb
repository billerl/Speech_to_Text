Imports System.Speech

Public Class Form1

    Public synth As New Speech.Synthesis.SpeechSynthesizer
    Public WithEvents recognizer As New Speech.Recognition.SpeechRecognitionEngine
    Dim gram As New System.Speech.Recognition.DictationGrammar()

    Public Sub GotSpeech(ByVal sender As Object, ByVal phrase As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles recognizer.SpeechRecognized
        Dim newText As String = phrase.Result.Text
        Dim search As Boolean = False
        LblWords.Text = ""
        LblWords.Text += newText
        newText = newText.ToLower
        If newText.Contains("look up") Then
            Dim startsAt As Integer = newText.IndexOf("look up")
            newText = newText.Substring(startsAt + 7)
            If newText.Length > 0 Then
                search = True
            End If
        End If
        If newText.Contains("search for") Then
            Dim startsAt As Integer = newText.IndexOf("search for")
            newText = newText.Substring(startsAt + 10)
            If newText.Length > 0 Then
                search = True
            End If
        End If
        If newText.Contains("google") Then
            Dim startsAt As Integer = newText.IndexOf("google")
            newText = newText.Substring(startsAt + 6)
            If newText.Length > 0 Then
                search = True
            End If
        End If

        If search = True Then


            'Speak a string.  
            'synth.Speak("Please hold while I look up " & newText & " for you")
            Process.Start("http://www.google.com/images?hl=en&q=" & newText.Replace(" ", "+"))
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        recognizer.LoadGrammar(gram)
        recognizer.SetInputToDefaultAudioDevice()
        recognizer.RecognizeAsync(Recognition.RecognizeMode.Multiple)
        'Configure the audio output.   
        'synth.SetOutputToDefaultAudioDevice()
    End Sub
End Class