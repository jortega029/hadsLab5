<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ImportarTareasDataSet.aspx.vb" Inherits="Lab2HADS25.ImportarTareasDataSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
        <div style="background-color: #C0C0C0">
            <h1 style="text-align: center">PROFESOR</h1>
            <h1 style="text-align: center">IMPORTAR TAREAS GENÉRICAS</h1>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Seleccionar asignatura a importar:"></asp:Label>
            <br />
            <asp:DropDownList ID="listaAsignaturasProf" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="codigoasig" DataValueField="codigoasig">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS25-TAREASConnectionString %>" SelectCommand="SELECT g.codigoasig FROM GruposClase AS g INNER JOIN ProfesoresGrupo AS p ON g.codigo = p.codigogrupo WHERE (p.email = @email)">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="Usuario" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:Label ID="noHayTareas" runat="server" Text="No hay tareas que importar en esta asignatura" Visible="False"></asp:Label>
&nbsp;<br />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
&nbsp;<asp:Button ID="importarButtonDS" runat="server" Text="Importar DS" />
        </div>
         <p>
             <asp:Label ID="labelMensaje" runat="server"></asp:Label>
         </p>
         <p>
             <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Profesor.aspx">Volver a inicio Profesor</asp:HyperLink>
         </p>
    </form>
</body>
</html>

