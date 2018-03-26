Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml
Imports AccesoDatos.AccesoDatosSQL
Imports Newtonsoft.Json

Public Class ExportarTareas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub listaAsignaturasProf_DataBound(sender As Object, e As EventArgs) Handles listaAsignaturasProf.DataBound
        Dim da As SqlDataAdapter = anadirtarea()
        Dim builder As New SqlCommandBuilder(da)
        Dim ds As New DataSet("tareas")
        da.Fill(ds, "TareasGenericas")
        Dim dt = ds.Tables("TareasGenericas")
        dt.Columns("codigo").ColumnMapping = MappingType.Attribute
        dt.Columns("codigo").ColumnName = "codigo"

        dt.TableName = "tarea"
        Dim vista As New DataView
        vista.Table = dt
        Session("tabla") = vista
        actualizarTabla()
    End Sub

    Protected Sub listaAsignaturasProf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listaAsignaturasProf.SelectedIndexChanged
        actualizarTabla()
    End Sub

    Protected Sub exportarButton_Click(sender As Object, e As EventArgs) Handles exportarButton.Click
        Dim vista As DataView = Session("tabla")
        Dim dt As DataTable = vista.ToTable
        Dim col As DataColumn = dt.Columns("codAsig")
        dt.Columns.Remove(col)
        dt.Columns("descripcion").ColumnName = "descripcion"
        dt.Columns("hestimadas").ColumnName = "hestimadas"
        dt.Columns("explotacion").ColumnName = "explotacion"
        dt.Columns("tipotarea").ColumnName = "tipotarea"
        Dim ds As New DataSet("tareas")
        ds.Tables.Add(dt)
        Try
            ds.WriteXml(Server.MapPath("/App_Data/" & listaAsignaturasProf.SelectedValue & ".xml"))
            Dim doc As New XmlDocument
            doc.Load(Server.MapPath("/App_Data/" & listaAsignaturasProf.SelectedValue & ".xml"))

            Dim at As XmlAttribute = doc.CreateAttribute("xmlns:has")
            at.Value = "http://ji.ehu.es/has"
            doc.DocumentElement.Attributes.Append(at)
            doc.Save(Server.MapPath("App_Data/" & listaAsignaturasProf.SelectedValue & ".xml"))
            labelMensaje.Text = "Documento exportado correctamente"
        Catch ex As Exception
            labelMensaje.Text = "Ha ocurrido algún error, vuelve a intentarlo"
        End Try

    End Sub

    Protected Sub actualizarTabla()
        Dim vista As DataView = Session("tabla")
        vista.RowFilter = "CodAsig='" & listaAsignaturasProf.SelectedValue & "'"
        GridView1.DataSource = vista
        GridView1.DataBind()
        If vista.Count > 0 Then
            exportarButton.Enabled = True
            exportarJSONButton.Enabled = True
        Else
            exportarButton.Enabled = False
            exportarJSONButton.Enabled = False
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub exportarJSONButton_Click(sender As Object, e As EventArgs) Handles exportarJSONButton.Click
        Dim vista As DataView = Session("tabla")
        Dim dt As DataTable = vista.ToTable()
        Dim col As DataColumn = dt.Columns("codAsig")
        dt.Columns.Remove(col)
        Dim JSONString As String = String.Empty
        JSONString = JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented)
        Dim writer As StreamWriter
        writer = My.Computer.FileSystem.OpenTextFileWriter(Server.MapPath("App_Data/" & listaAsignaturasProf.SelectedValue & ".json"), True)
        writer.Write(JSONString)
        writer.Close()
        labelMensaje.Text = "Documento exportado correctamente a JSON"
    End Sub
End Class