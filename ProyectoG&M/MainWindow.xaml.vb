Imports System.Data
Imports System.Data.SqlClient

Class MainWindow
    Dim conexion As String
    Dim dt As DataTable
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs) Handles MyBase.Loaded
        conexion = My.Settings.Conexion
        NombreTextBox.Focus()
    End Sub
    Private Sub IniciarSesionButton_Click(sender As Object, e As RoutedEventArgs)
        Dim consulta As String

        If String.IsNullOrEmpty(NombreTextBox.Text) Then
            MsgBox("Debe introducir un usuario correcto", MsgBoxStyle.Exclamation, "Gamo Tour")
            NombreTextBox.Focus()
        Else
            If String.IsNullOrEmpty(ContraseñaTextBox.Password) Then
                MsgBox("Debe introducir una contraseña valida", MsgBoxStyle.Exclamation, "Gamo Tours")
                ContraseñaTextBox.Focus()
            End If
        End If

        consulta = "Select * from usuarios where usuario = '" & NombreTextBox.Text & "' and password = '" & ContraseñaTextBox.Password & "' and activo = 1"

        If NombreTextBox.Text <> "" And ContraseñaTextBox.Password <> "" Then
            Gamo.llenadt(consulta, dt, conexion)

            If dt.Rows.Count > 0 Then
                Dim principal = New Principal()
                principal.Show()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub SalirButton_Click(sender As Object, e As RoutedEventArgs)
        End
    End Sub

    Private Sub ContraseñaTextBox_KeyDown(sender As Object, e As KeyEventArgs)
        If e.Key = Key.Enter Then
            Dim consulta As String

            If String.IsNullOrEmpty(NombreTextBox.Text) Then
                MsgBox("Debe introducir un usuario correcto", MsgBoxStyle.Exclamation, "Gamo Tour")
                NombreTextBox.Focus()
            Else
                If String.IsNullOrEmpty(ContraseñaTextBox.Password) Then
                    MsgBox("Debe introducir una contraseña valida", MsgBoxStyle.Exclamation, "Gamo Tours")
                    ContraseñaTextBox.Focus()
                End If
            End If

            consulta = "Select * from usuarios where usuario = '" & NombreTextBox.Text & "' and password = '" & ContraseñaTextBox.Password & "' and activo = 1"

            If NombreTextBox.Text <> "" And ContraseñaTextBox.Password <> "" Then
                llenadt(consulta, dt, conexion)

                If dt.Rows.Count > 0 Then
                    Dim principal = New Principal()
                    principal.Show()
                    Me.Close()
                End If
            End If
        End If
    End Sub
End Class
