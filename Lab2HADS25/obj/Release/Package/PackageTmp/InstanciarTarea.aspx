<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InstanciarTarea.aspx.vb" Inherits="Lab2HADS25.InstanciarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 120px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-color: #CCFFCC">
        <h1 style="text-align: center">ALUMNOS</h1>
        <h1 style="text-align: center">INSTANCIAR TAREA GENÉRICA</h1>
    </div>
        <div class="auto-style1">
            <asp:Label ID="labelUsuario" runat="server" Text="Usuario"></asp:Label>
&nbsp;
            <asp:TextBox ID="textoUsuario" runat="server"></asp:TextBox>
            <br class="auto-style1" />
            <br class="auto-style1" />
            <asp:Label ID="labelTarea" runat="server" Text="Tarea"></asp:Label>
&nbsp;
            <asp:TextBox ID="textoTarea" runat="server"></asp:TextBox>
            <br class="auto-style1" />
            <br class="auto-style1" />
            <asp:Label ID="labelEstimadas" runat="server" Text="Horas Est."></asp:Label>
&nbsp;
            <asp:TextBox ID="textoEstimadas" runat="server"></asp:TextBox>
            <br class="auto-style1" />
            <br class="auto-style1" />
            <asp:Label ID="labelReales" runat="server" Text="Horas reales"></asp:Label>
&nbsp;
            <asp:TextBox ID="textoReales" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Instanciar tarea" />
            <br />
        </div>
        <div style="margin-left: 600px">

            <asp:GridView ID="gridTareas" runat="server" style="text-align: center">
        </asp:GridView>
        </div>


        <asp:HyperLink ID="atrasLink" runat="server" NavigateUrl="~/TareasAlumno.aspx">Página anterior</asp:HyperLink>


    </form>
</body>
</html>
