Imports System.Data
Imports System.Data.SqlClient

Module Gamo
    Public Sub llenadt(ByVal sql As String, ByRef dt As Data.DataTable, ByVal cs As String, Optional ByVal time As Integer = 30)
        Try
            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim da As New SqlDataAdapter
            dt = New DataTable
            dt.Clear()
            cn.ConnectionString = cs
            cn.Open()
            cmd.Connection = cn
            cmd.CommandTimeout = time
            cmd.CommandText = sql
            da.SelectCommand = cmd
            da.Fill(dt)
            cn.Close()
            cn.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            ThowException(ex, sql)
        End Try
    End Sub
    Sub ThowException(ByVal Ex As Exception, Optional ByVal query As String = "")
        Dim i As Integer
        Dim sException, Err, sTmp As String
        Dim aErrorLines
        Try
            Err = Ex.StackTrace.Replace("in ", "}").Replace("at ", "{") 'Delimitar las lineas Interesantes con {}
            aErrorLines = Err.Split("{")
            sException = Ex.Message & vbCr

            For i = 0 To aErrorLines.Length - 1
                sTmp = aErrorLines(i)
                If sTmp.Contains("}") Then
                    sException &= sTmp.Substring(0, sTmp.IndexOf("}") - 1) & " " & sTmp.Substring(sTmp.IndexOf(":line"))
                End If
            Next

            MsgBox("Ocurrio una Excepcion :" & vbCr & sException)
        Catch exe As Exception
            MsgBox("Ha Ocurrido una Excepcion en ThowException : " & exe.Message)

        End Try
    End Sub
End Module
