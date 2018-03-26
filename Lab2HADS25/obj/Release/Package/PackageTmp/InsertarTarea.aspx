<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InsertarTarea.aspx.vb" Inherits="Lab2HADS25.InsertarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-color: #C0C0C0">
        <asp:LinkButton ID="LinkButton1" runat="server">Cerrar sesión</asp:LinkButton>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <h1 style="text-align: center">PROFESOR</h1>
        <h1 style="text-align: center">GESTIÓN DE TAREAS GENÉRICAS</h1>
    </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Código"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="textoCodigo" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="textoCodigo" ErrorMessage="*"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Descripción"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="textoDesc" runat="server" Height="121px" TextMode="MultiLine" Width="669px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="textoDesc" ErrorMessage="*"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Asignatura"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="listaAsignaturas" runat="server" DataSourceID="asignaturas" DataTextField="codigoasig" DataValueField="codigoasig">
            </asp:DropDownList>
            <asp:SqlDataSource ID="asignaturas" runat="server" ConnectionString="<%$ ConnectionStrings:HADS25-TAREASConnectionString %>" SelectCommand="SELECT g.codigoasig FROM GruposClase AS g INNER JOIN ProfesoresGrupo AS p ON g.codigo = p.codigogrupo WHERE (p.email = @email)">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="usuario" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Horas estimadas"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="textoEstimadas" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="textoEstimadas" ErrorMessage="*"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Tipo tarea"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="listaTipo" runat="server" DataSourceID="tipoTarea" DataTextField="TipoTarea" DataValueField="TipoTarea">
            </asp:DropDownList>
            <asp:SqlDataSource ID="tipoTarea" runat="server" ConnectionString="<%$ ConnectionStrings:HADS25-TAREASConnectionString %>" SelectCommand="SELECT DISTINCT [TipoTarea] FROM [TareasGenericas]"></asp:SqlDataSource>
            <br />
            <br />
            <asp:Button ID="botonAnadir" runat="server" Text="Añadir tarea" />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="labelMensaje" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TareasProfesor.aspx">Ver tareas</asp:HyperLink>
        </div>
    </form>
</body>
</html>
