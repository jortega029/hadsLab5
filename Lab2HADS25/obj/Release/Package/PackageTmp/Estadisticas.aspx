<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Estadisticas.aspx.vb" Inherits="Lab2HADS25.Estadisticas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <br />
            <br />
            <h1>Media de horas reales dedicadas a cada tarea, dentro de cada una de las asignaturas del profesor</h1>
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Profesor.aspx">Volver a inicio Profesor</asp:HyperLink>
            <br />
            <br />

            <asp:Label ID="Label1" runat="server" Text="Selecciona asignatura"></asp:Label>
&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="codigoasig" DataValueField="codigoasig">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS25-TAREASConnectionString %>" SelectCommand="SELECT g.codigoasig FROM GruposClase AS g INNER JOIN ProfesoresGrupo AS p ON g.codigo = p.codigogrupo WHERE (p.email = @email)">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="Usuario" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource2" Height="384px" SuppressExceptions="True" Width="1004px">
                <Series>
                    <asp:Series Name="Series1" XValueMember="codTarea" YValueMembers="Column1" YValuesPerPoint="2">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS25-TAREASConnectionString %>" SelectCommand="SELECT codTarea,avg(HReales) FROM [EstudiantesTareas] as e inner join tareasgenericas as t on e.CodTarea = t.Codigo where CodAsig = @cod group by codTarea">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="cod" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>

        </div>
    </form>
</body>
</html>
