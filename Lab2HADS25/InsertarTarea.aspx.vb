Imports System.Data.SqlClient
Imports AccesoDatos.AccesoDatosSQL
Public Class InsertarTarea
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub botonAnadir_Click(sender As Object, e As EventArgs) Handles botonAnadir.Click
        Dim da = anadirtarea()
        Dim builder As New SqlCommandBuilder(da)
        Dim ds As New DataSet
        da.Fill(ds, "TareasGenericas")
        Dim dt = ds.Tables("TareasGenericas")

        Dim rowMbrs As DataRow = dt.NewRow()
        rowMbrs("Codigo") = textoCodigo.Text
        rowMbrs("Descripcion") = textoDesc.Text
        rowMbrs("CodAsig") = listaAsignaturas.SelectedValue
        rowMbrs("HEstimadas") = textoEstimadas.Text
        rowMbrs("Explotacion") = 1
        rowMbrs("TipoTarea") = listaTipo.SelectedValue
        dt.Rows.Add(rowMbrs)
        Try
            da.Update(ds, "TareasGenericas")
            labelMensaje.Text = "La inserción ha sido correcta"
        Catch ex As Exception
            labelMensaje.Text = ex.Message
        End Try

    End Sub

    Protected Sub textoCodigo_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class