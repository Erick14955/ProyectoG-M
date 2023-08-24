Imports System.Data.SqlClient
Imports System.Data

Public Class FacturacionC
    Dim conexion As String
    Dim dt, dt1, dt2, dt3, dt4 As New DataTable
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs) Handles MyBase.Loaded
        Dim consultacliente, consultadestino, consultacapacidad, consultaprecio As String
        conexion = My.Settings.Conexion
        consultacliente = "select codigo, nombre, direccion, rnc from clientes"
        consultadestino = "select distinct destino from precios"
        consultacapacidad = "select distinct capacidad from precios"

        Gamo.llenadt(consultacliente, dt, conexion)
        Gamo.llenadt(consultadestino, dt1, conexion)
        Gamo.llenadt(consultacapacidad, dt2, conexion)

        ClienteComboBox.ItemsSource = dt.DefaultView
        ClienteComboBox.DisplayMemberPath = "nombre"
        ClienteComboBox.SelectedValuePath = "codigo"
        ClienteComboBox.SelectedIndex = 0
        Dim fila1 As DataRow = dt.Rows(0)
        Dim valor1 As Object = fila1("direccion")
        Dim valor2 As Object = fila1("rnc")
        DireccionTextBox.Text = valor1.ToString
        RNCTextBox.Text = valor2.ToString

        DestinoComboBox.ItemsSource = dt1.DefaultView
        DestinoComboBox.DisplayMemberPath = "destino"
        DestinoComboBox.SelectedValuePath = "destino"
        DestinoComboBox.SelectedIndex = 0

        CapacidadComboBox.ItemsSource = dt2.DefaultView
        CapacidadComboBox.DisplayMemberPath = "capacidad"
        CapacidadComboBox.SelectedValuePath = "capacidad"
        CapacidadComboBox.SelectedIndex = 0

        consultaprecio = "select precio from precios where destino = '" & DestinoComboBox.SelectedValue & "' and capacidad = " & CapacidadComboBox.SelectedValue

        Gamo.llenadt(consultaprecio, dt3, conexion)
        Dim fila As DataRow = dt3.Rows(0)
        Dim valor As Object = fila("precio")
        PrecioTextBox.Text = valor.ToString()

        FechaDatePicker.SelectedDate = DateTime.Now
    End Sub
    Private Sub EliminarButton_Click(sender As Object, e As RoutedEventArgs)

    End Sub
    Private Sub Cancelar_Click(sender As Object, e As RoutedEventArgs)
        Dim prin As New Principal()
        prin.Show()
        Me.Close()
    End Sub

    Private Sub CapacidadComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim consulta As String

        If DestinoComboBox.SelectedValue <> "" And CapacidadComboBox.SelectedValue <> 0 Then
            consulta = "select precio from precios where destino = '" & DestinoComboBox.SelectedValue & "' and capacidad = " & CapacidadComboBox.SelectedValue

            Gamo.llenadt(consulta, dt4, conexion)

            Dim fila As DataRow = dt4.Rows(0)
            Dim valor As Object = fila("precio")
            PrecioTextBox.Text = valor.ToString()
        End If
    End Sub

    Private Sub DestinoComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim consulta As String

        If DestinoComboBox.SelectedValue <> "" And CapacidadComboBox.SelectedValue <> 0 Then
            consulta = "select precio from precios where destino = '" & DestinoComboBox.SelectedValue & "' and capacidad = " & CapacidadComboBox.SelectedValue

            dt4 = New DataTable

            Gamo.llenadt(consulta, dt4, conexion)

            Dim fila As DataRow = dt4.Rows(0)
            Dim valor As Object = fila("precio")
            PrecioTextBox.Text = valor.ToString()
        End If
    End Sub

    Private Sub GuardarButton_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub AgregarButton_Click(sender As Object, e As RoutedEventArgs)

    End Sub
End Class
