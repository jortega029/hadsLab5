Public Class Estadisticas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Chart1.ChartAreas(0).AxisX.Interval = 1
    End Sub

End Class