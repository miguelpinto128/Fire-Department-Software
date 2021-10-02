Imports System.Text
Public Class form_googlemaps
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim street As String = TextBox3.Text
        Dim city As String = TextBox4.Text
        Dim zip As String = TextBox6.Text

        Try
            Dim queryaddress As New StringBuilder
            queryaddress.Append("http://maps.google.com/maps?=")

            If TextBox3.Text <> String.Empty Then
                queryaddress.Append(city + "," & "+")
            End If
            If TextBox4.Text <> String.Empty Then
                queryaddress.Append(city + "," & "+")
            End If
            If TextBox6.Text <> String.Empty Then
                queryaddress.Append(zip + "," & "+")
            End If

            WebBrowser2.Navigate(queryaddress.ToString)
        Catch ex As Exception

        End Try
    End Sub
End Class