Imports System.Data.SqlClient
Imports AccesoDatos.AccesoDatosSQL

Public Class ImportarTareasDataSet
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Dim ds As New DataSet
            Session("dsimp") = ds
            actualizarTabla()
        End If
    End Sub

    Protected Sub importarButtonDS_Click(sender As Object, e As EventArgs) Handles importarButtonDS.Click
        Dim ds As DataSet = Session("dsimp")
        Dim dt As DataTable
        Dim newCol As New DataColumn
        dt = ds.Tables(0)
        newCol.ColumnName = "codAsig"
        dt.Columns.Add(newCol)
        For i = 0 To dt.Rows.Count - 1
            Dim row As DataRow = dt.Rows(i)
            row("codAsig") = listaAsignaturasProf.SelectedValue
        Next
        Dim da As SqlDataAdapter = anadirtarea()
        Dim builder As New SqlCommandBuilder(da)
        da.Fill(ds, "TareasGenericas")
        Dim dt1 As DataTable = ds.Tables("TareasGenericas")

        For i = 0 To dt.Rows.Count - 1

            Dim rowselect() As DataRow
            rowselect = dt1.Select("codigo='" + dt.Rows(i).Item("codigo") + "'")
            If rowselect.Length < 1 Then
                Dim rowMbrs As DataRow = dt1.NewRow()
                rowMbrs("Codigo") = dt.Rows(i).Item("codigo")
                rowMbrs("Descripcion") = dt.Rows(i).Item("descripcion")
                rowMbrs("CodAsig") = listaAsignaturasProf.SelectedValue
                rowMbrs("HEstimadas") = dt.Rows(i).Item("hestimadas")
                rowMbrs("Explotacion") = dt.Rows(i).Item("explotacion")
                rowMbrs("TipoTarea") = dt.Rows(i).Item("tipotarea")
                dt1.Rows.Add(rowMbrs)
            End If
        Next


        Try
            Dim num As Integer = da.Update(ds, "TareasGenericas")
            If num > 0 Then
                labelMensaje.Text = "Se han importado las tareas que no estaban en la BD"
            Else
                labelMensaje.Text = "Las tareas estaban importadas previamente en la BD"
            End If
        Catch ex2 As Exception
            labelMensaje.Text = "Ha ocurrido algún error. Vuelve a intentarlo."
        End Try

    End Sub

    Private Sub listaAsignaturasProf_DataBound(sender As Object, e As EventArgs) Handles listaAsignaturasProf.DataBound
        Dim ds As New DataSet
        Session("dsimp") = ds
        actualizarTabla()
    End Sub

    Protected Sub actualizarTabla()
        Try
            Dim ds As DataSet = Session("dsimp")
            ds.Clear()
            ds.ReadXml(Server.MapPath("App_Data/" & listaAsignaturasProf.SelectedValue.Trim & ".xml").Trim)
            Dim dt As DataTable = ds.Tables(0)
            GridView1.DataSource = dt
            GridView1.DataBind()
            noHayTareas.Visible = False
            GridView1.Visible = True
            importarButtonDS.Enabled = True
            Session("dsimp") = ds
        Catch ex As Exception
            noHayTareas.Visible = True
            GridView1.Visible = False
            importarButtonDS.Enabled = False
        End Try


    End Sub

    Protected Sub listaAsignaturasProf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listaAsignaturasProf.SelectedIndexChanged
        actualizarTabla()
    End Sub
End Class