Imports AccesoDatos.AccesoDatosSQL
Imports System.Data.SqlClient
Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Conectar()
        Dim dr As SqlDataReader
        Try
            dr = logueado(email.Text, psw.Text)
        Catch ex As Exception
            QUERY.Text = ex.Message
            Exit Sub
        End Try
        If dr.HasRows Then
            While dr.Read
                If dr.Item(0) = 0 Then
                    QUERY.Text = "Confirma tu registro, revisa tu correo electrónico y accede desde el enlace que te mandamos al registrarte"
                    dr.Close()
                Else
                    Session("Usuario") = email.Text
                    If dr.Item(1) = "Profesor" Then
                        dr.Close()
                        Response.Redirect("Profesor.aspx")
                    ElseIf dr.Item(1) = "Alumno" Then
                        dr.Close()
                        Response.Redirect("Alumno.aspx")
                    End If
                End If
            End While
        Else
            QUERY.Text = "El usuario o la contraseña no son correctos"
            dr.Close()
        End If
        CerrarConexion()
    End Sub
End Class