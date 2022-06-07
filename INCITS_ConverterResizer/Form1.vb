
Imports System.IO
'Imports SecuGen.FDxSDKPro.Windows

Public Class Form1

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'If TextBox1.Text = "" Then
        '    MessageBox.Show("Please enter file..")
        '    TextBox1.Focus()
        '    Exit Sub
        'Else
        '    If New FileInfo(TextBox1.Text).Length < 1024 Then
        '        MessageBox.Show("File is not greater than 1024 bytes..")
        '        TextBox1.Focus()
        '        Exit Sub
        '    End If
        'End If

        Button1.Enabled = False
        Button2.Enabled = False

        Dim ir As New INCITS_Resizer
        If ComboBox1.Text = ir.ANSI_378 Then
            ir.FileType = ir.ANSI_378
            If ir.Convert(TextBox1.Text, ir.ANSI_378_FileFormat, ir.ISO_19794_2_CF_CS_FileFormat, ir.ISO_19794_2_CF_CS_FileFormat) Then
                MessageBox.Show("Success!")
            Else
                MessageBox.Show("Failed!" & vbNewLine & vbNewLine & ir.ErrorMessage)
            End If
        ElseIf ComboBox1.Text = ir.ISO_19794_2_CF_CS Then
            If ir.ResizeIncits(TextBox1.Text) Then
                MessageBox.Show("Success!")
            Else
                MessageBox.Show("Failed!" & vbNewLine & vbNewLine & ir.ErrorMessage)
            End If
        ElseIf ComboBox1.Text = ir.ISO_19794_2 Then
            If ir.ResizeIncits3(TextBox1.Text) Then
                MessageBox.Show("Success!")
            Else
                MessageBox.Show("Failed!" & vbNewLine & vbNewLine & ir.ErrorMessage)
            End If
        ElseIf ComboBox1.Text = ir.Morpho_CFV Then
            If ir.ResizeIncits(TextBox1.Text) Then
                MessageBox.Show("Success!")
            Else
                MessageBox.Show("Failed!" & vbNewLine & vbNewLine & ir.ErrorMessage)
            End If
        End If

        Button1.Enabled = True
        Button2.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        BrowseFile(TextBox1)
    End Sub

    Private Sub BrowseFile(ByVal txtbox As TextBox)
        Dim ofd As New OpenFileDialog
        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtbox.Text = ofd.FileName
        End If
        ofd.Dispose()
    End Sub


    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("ANSI_378")
        ComboBox1.Items.Add("ISO_19794_2_CF_CS")
        ComboBox1.Items.Add("ISO_19794_2")
        ComboBox1.Items.Add("Morpho_CFV")
        ComboBox1.SelectedIndex = 1
    End Sub

    'Private m_FPM As New SGFingerPrintManager
    'Private m_ImageWidth As Int32
    'Private m_ImageHeight As Int32

    'Private Function SecugenMatchFileTemplate(ByVal ansiFile1 As Byte(), ByVal ansiFile2 As Byte(), ByVal ErrorMessage As String) As Boolean
    '    Try
    '        Dim iError As Int32
    '        Dim matched As Boolean

    '        iError = m_FPM.InitEx(m_ImageWidth, m_ImageHeight, 500)
    '        iError = m_FPM.MatchAnsiTemplate(ansiFile1, 0, ansiFile2, 0, SGFPMSecurityLevel.NORMAL, matched)
    '        Application.DoEvents()

    '        If MatchedFingerprints(iError, matched) Then
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Catch ex As Exception
    '        ErrorMessage = ex.Message
    '        Return False
    '    End Try

    'End Function

    'Private Function MatchedFingerprints(ByVal iError As Integer, ByVal matched As Boolean) As Boolean
    '    If iError = SGFPMError.ERROR_NONE Then
    '        If matched Then
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Else
    '        Return False
    '    End If
    'End Function

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        BrowseFile(TextBox2)
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        BrowseFile(TextBox3)
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        'If SecugenMatchFileTemplate(File.ReadAllBytes(TextBox2.Text), File.ReadAllBytes(TextBox3.Text), "") Then
        '    MessageBox.Show("Matched!")
        'Else
        '    MessageBox.Show("Not matched!")
        'End If
    End Sub


    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Please enter file..")
            TextBox1.Focus()
            Exit Sub
            'Else
            '    If New FileInfo(TextBox1.Text).Length < 1024 Then
            '        MessageBox.Show("File is not greater than 1024 bytes..")
            '        TextBox1.Focus()
            '        Exit Sub
            '    End If
        End If

        Button1.Enabled = False
        Button2.Enabled = False

        Dim ir As New INCITS_Resizer
        ir.FileType = ir.Morpho_CFV
        If ir.Convert(TextBox1.Text, ir.ANSI_378_FileFormat, ir.Morpho_CFV_FileFormat, ir.Morpho_CFV_EXT) Then
            MessageBox.Show("Success!")
        Else
            MessageBox.Show("Failed!" & vbNewLine & vbNewLine & ir.ErrorMessage)
        End If

        Return

        If ComboBox1.Text = ir.ANSI_378 Then
            ir.FileType = ir.Morpho_CFV
            If ir.Convert(TextBox1.Text, ir.ANSI_378_FileFormat, ir.Morpho_CFV_FileFormat, ir.Morpho_CFV_FileFormat) Then
                MessageBox.Show("Success!")
            Else
                MessageBox.Show("Failed!" & vbNewLine & vbNewLine & ir.ErrorMessage)
            End If
        ElseIf ComboBox1.Text = ir.ISO_19794_2_CF_CS Then
            If ir.ResizeIncits(TextBox1.Text) Then
                MessageBox.Show("Success!")
            Else
                MessageBox.Show("Failed!" & vbNewLine & vbNewLine & ir.ErrorMessage)
            End If
        ElseIf ComboBox1.Text = ir.Morpho_CFV Then
            If ir.ResizeIncits(TextBox1.Text) Then
                MessageBox.Show("Success!")
            Else
                MessageBox.Show("Failed!" & vbNewLine & vbNewLine & ir.ErrorMessage)
            End If
        End If

        Button1.Enabled = True
        Button2.Enabled = True
    End Sub
End Class
