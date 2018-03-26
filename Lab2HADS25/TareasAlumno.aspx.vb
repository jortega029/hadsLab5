Imports AccesoDatos.AccesoDatosSQL
Imports System.Data.SqlClient
Imports System.Drawing
Public Class TareasAlumno
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usuario = Session("Usuario")
        asignaturas.AutoPostBack = True
        If Not Page.IsPostBack Then
            Dim dr As SqlDataReader
            dr = obtenerAsignaturas(usuario)
            While dr.Read
                asignaturas.Items.Add(dr.Item(0).ToString)
            End While
            dr.Close()
            Dim da = obtenerTareas(usuario, asignaturas.SelectedValue)
            Dim ds As New DataSet
            da.Fill(ds, "TareasGenericas")
            Dim dt = ds.Tables("tareasGenericas")
            tablaFinal.AllowSorting = True
            tablaFinal.DataSource = dt
            tablaFinal.DataBind()
            Session("ds") = ds
            Session("tabla") = dt
        End If
    End Sub

    Protected Sub asignaturas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles asignaturas.SelectedIndexChanged
        Dim da = obtenerTareas(Session("Usuario"), asignaturas.SelectedValue)
        Dim ds As New DataSet
        da.Fill(ds, "TareasGenericas")
        Dim dt = ds.Tables("tareasGenericas")
        Session("tabla") = dt

        tablaFinal.DataSource = dt
        tablaFinal.DataBind()
    End Sub

    Protected Sub tablaFinal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tablaFinal.SelectedIndexChanged
        Dim tabla = Session("tabla")
        Dim codigo = tabla.Rows(tablaFinal.SelectedIndex).Item("Codigo")
        Dim horas = tabla.Rows(tablaFinal.SelectedIndex).Item("HEstimadas")
        Dim usuario = Session("usuario")
        Response.Redirect("InstanciarTarea.aspx?tarea=" & codigo & "&usuario=" & usuario & "&horas=" & horas)
    End Sub

    Private Property orden() As String
        Get
            Return ViewState("orden")
        End Get

        Set(ByVal value As String)
            ViewState("orden") = value
        End Set

    End Property

    Protected Sub ordenar(sender As GridView, e As GridViewSortEventArgs) Handles tablaFinal.Sorting
        If orden = "ASC" Then
            orden = "DESC"
        Else
            orden = "ASC"
        End If
        Dim vista As New DataView
        Dim dt As DataTable
        dt = Session("tabla")
        vista.Table = dt
        vista.Sort = e.SortExpression & " " & orden
        tablaFinal.DataSource = vista
        tablaFinal.DataBind()
    End Sub

End Class