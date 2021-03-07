<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="poliza.aspx.cs" Inherits="Ejercicio_XML1.poliza" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Datos Generales<br />
            <br />
            No.Cotización:
            <asp:TextBox ID="txtNoCotizacion" runat="server" TextMode="Number" Width="110px"></asp:TextBox>
            <br />
            Agencia:
            <asp:TextBox ID="txtAgencia" runat="server" Width="330px"></asp:TextBox>
            <br />
            Fecha de cotización:<asp:TextBox ID="txtFechaCotizacion" runat="server" TextMode="Date" Width="207px"></asp:TextBox>
            <br />
            <br />
            Datos de cliente<br />
            Nombre del asegurado:<asp:TextBox ID="txtNombreAsegurado" runat="server" Width="250px"></asp:TextBox>
            <br />
            RFC:<asp:TextBox ID="txtRFC" runat="server" Width="296px"></asp:TextBox>
            <br />
            Telefono:<asp:TextBox ID="txtTelefono" runat="server" TextMode="Number" Width="226px"></asp:TextBox>
            <br />
            <br />
            Datos Vehículo<br />
            Marca:<asp:TextBox ID="txtMarca" runat="server" Width="250px"></asp:TextBox>
            <br />
            Modelo:<asp:TextBox ID="txtModelo" runat="server" Width="239px"></asp:TextBox>
            <br />
            Numero serie:<asp:TextBox ID="txtNumSerie" runat="server" Width="205px"></asp:TextBox>
            <br />
            Numero motor:<asp:TextBox ID="txtNumMotor" runat="server" Width="193px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnPoliza" runat="server" OnClick="btnPoliza_Click" Text="Generar Poliza" />
            &nbsp;<asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar Poliza" />
            &nbsp;<asp:Button ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" Text="Nuevo Registro" Width="131px" />
            <br />
            <br />
            <asp:Label ID="lblMensaje" runat="server" Text="lblMensaje"></asp:Label>
        </div>
    <div>
        MOSTRAR DATOS DE POLIZA:
        <asp:Button ID="btnLeer" runat="server" OnClick="btnLeer_Click" Text="Leer XML" />
        <br />
        <asp:Label ID="Label1" runat="server" ForeColor="Blue" Text="Label1"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" ForeColor="#33CC33" Text="Label2"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="Label3"></asp:Label>
        <br />
        <br />
        Llenar tabla:
        <asp:Button ID="btnllenar" runat="server" OnClick="btnllenar_Click" Text="Mostrar Todos" />
        &nbsp;<br />
        Numero de poliza a buscar:&nbsp;
        <asp:TextBox ID="txtIdBuscar" runat="server" TextMode="Number"></asp:TextBox>
&nbsp;&nbsp;
        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" Width="129px" />
        &nbsp;<asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" Width="121px" />
        <br />
        Numero de poliza a eliminar:
        <asp:TextBox ID="txtIdEliminar" runat="server" TextMode="Number"></asp:TextBox>
&nbsp;&nbsp;
        <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" Width="125px" />
        <br />
        <br />
        Polizas<br />
        <asp:GridView ID="dgvTablaPolizas" runat="server">
        </asp:GridView>
        <br />
    </div>
    </form>
    </body>
</html>
