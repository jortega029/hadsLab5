Imports System.Data.SqlClient
Imports System.Xml
Imports AccesoDatos.AccesoDatosSQL

Public Class ImportarTareasXML
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs)
        actualizarTabla()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles importarButton.Click
        Dim da = anadirtarea()
        Dim builder As New SqlCommandBuilder(da)
        Dim ds As New DataSet
        da.Fill(ds, "TareasGenericas")
        Dim dt = ds.Tables("TareasGenericas")

        Dim doc As XmlDocument = Session("doc")
        Dim tareas As XmlNodeList = doc.GetElementsByTagName("tarea")
        For i = 0 To tareas.Count - 1

            Dim rowselect() As DataRow
            rowselect = dt.Select("codigo='" + tareas(i).Attributes(0).Value + "'")
            If rowselect.Length < 1 Then
                Dim rowMbrs As DataRow = dt.NewRow()
                rowMbrs("Codigo") = tareas(i).Attributes(0).Value
                rowMbrs("Descripcion") = tareas(i).ChildNodes(0).ChildNodes(0).Value
                rowMbrs("CodAsig") = listaAsignaturasProf.SelectedValue
                rowMbrs("HEstimadas") = tareas(i).ChildNodes(1).ChildNodes(0).Value
                rowMbrs("Explotacion") = tareas(i).ChildNodes(2).ChildNodes(0).Value
                rowMbrs("TipoTarea") = tareas(i).ChildNodes(3).ChildNodes(0).Value
                dt.Rows.Add(rowMbrs)
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

    Protected Sub actualizarTabla()
        Try
            Dim doc As XmlDocument = Session("doc")
            doc.Load(Server.MapPath("App_Data/" & listaAsignaturasProf.SelectedValue & ".xml"))
            Xml1.DocumentSource = Server.MapPath("App_Data/" & listaAsignaturasProf.SelectedValue.Trim() & ".xml")
            Xml1.TransformSource = Server.MapPath("App_Data/" & DropDownList1.SelectedValue & ".xsl")
            noHayTareas.Visible = False
            Xml1.Visible = True
            Session("doc") = doc
            importarButton.Enabled = True
        Catch ex As Exception
            noHayTareas.Visible = True
            Xml1.Visible = False
            importarButton.Enabled = False
        End Try


    End Sub

    Protected Sub listaAsignaturasProf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listaAsignaturasProf.SelectedIndexChanged
        actualizarTabla()
        labelMensaje.Text = ""
    End Sub

    Private Sub listaAsignaturasProf_DataBound(sender As Object, e As EventArgs) Handles listaAsignaturasProf.DataBound
        Dim docxml As New XmlDocument
        Session("doc") = docxml
        actualizarTabla()
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged1(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Xml1.DocumentSource = Server.MapPath("App_Data/" & listaAsignaturasProf.SelectedValue.Trim() & ".xml")
        Xml1.TransformSource = Server.MapPath("App_Data/" & DropDownList1.SelectedValue & ".xsl")
    End Sub
End Class