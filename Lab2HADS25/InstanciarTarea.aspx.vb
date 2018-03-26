Imports AccesoDatos.AccesoDatosSQL
Imports System.Data.SqlClient

Public Class InstanciarTarea
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usuario = Request.QueryString("usuario")
        Dim tarea = Request.QueryString("tarea")
        Dim horas = Request.QueryString("horas")
        Dim da = obtenerInstanciadas(usuario)
        Dim ds As New DataSet
        da.Fill(ds, "EstudiantesTareas")
        Dim dt = ds.Tables("EstudiantesTareas")
        Session("dsInstanciar") = ds
        gridTareas.DataSource = dt
        gridTareas.DataBind()

        textoUsuario.Text = usuario
        textoUsuario.Enabled = False
        textoTarea.Text = tarea
        textoTarea.Enabled = False
        textoEstimadas.Text = horas
        textoEstimadas.Enabled = False

        Session("adapter") = da

        Dim builder As New SqlCommandBuilder(da)

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim usuario = Request.QueryString("usuario")
        Dim tarea = Request.QueryString("tarea")
        Dim horasEst = Request.QueryString("horas")
        Dim horasReal As String = textoReales.Text

        Dim da As SqlDataAdapter
        da = Session("adapter")

        Dim ds As DataSet
        ds = Session("dsInstanciar")
        Dim dt As DataTable
        dt = ds.Tables("EstudiantesTareas")
        Dim rowMbrs As DataRow = dt.NewRow()
        rowMbrs("email") = usuario
        rowMbrs("codTarea") = tarea
        rowMbrs("HEstimadas") = horasEst
        rowMbrs("HReales") = horasReal
        dt.Rows.Add(rowMbrs)
        gridTareas.DataSource = dt
        gridTareas.DataBind()
        da.Update(ds, "EstudiantesTareas")

        textoReales.Enabled = False
        Button1.Enabled = False


    End Sub

End Class