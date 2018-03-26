<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Profesor.aspx.vb" Inherits="Lab2HADS25.Profesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

            <asp:Label ID="Label3" runat="server"></asp:Label>
        &nbsp;
        <asp:LinkButton ID="LinkButton1" runat="server">Cerrar sesión</asp:LinkButton>
            &nbsp;
        <br />
        <br />
        <div style="border: medium solid #000000; width: 200px; height: 500px; position:absolute; background-color: #FFFFCC; text-align: center; font-weight: 700; font-size: x-large;">
            
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Estadisticas.aspx">Estadísticas</asp:HyperLink>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Profesor.aspx">Asignaturas</asp:HyperLink>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/TareasProfesor.aspx">Tareas</asp:HyperLink>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Profesor.aspx">Grupos</asp:HyperLink>
            
            <br />
            <br />
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/ImportarTareasXMLDocument.aspx">Importar v. XMLDocument</asp:HyperLink>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/ExportarTareas.aspx">Exportar</asp:HyperLink>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/ImportarTareasDataSet.aspx">Importar v. DataSet</asp:HyperLink>
            
        </div>
        <div style=" height: 500px; width: 700px; position: relative; left: 220px; background-color: #CCFFCC; text-align: center; border-left-style: groove; border-left-color: #C0C0C0; border-right-style: groove; border-right-color: #000000; border-top-style: groove; border-top-color: #C0C0C0; border-bottom-style: groove; border-bottom-color: #000000;">
            
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" style="text-align: center; font-size: xx-large; font-weight: 700" Text="Gestión Web de Tareas-Dedicación"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" style="text-align: center; font-size: xx-large; font-weight: 700" Text="Profesores"></asp:Label>
            
        </div>
    </form>
</body>
</html>
