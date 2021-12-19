<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kriptolama.aspx.cs" Inherits="ProjectKriptolama.Project.Kriptolama" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kriptolama</title>
    <%-- <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />--%>

    <style type="text/css">
        .fontClass {
            font-family: "Calibri", Times, serif !important;
            font-size: 15px !important;
        }

        .labelClass {
            float: left;
            padding: 5px 10px 0 0;
            font-weight: bold;
        }
    </style>
</head>
<body class="fontClass">
    <form id="form1" runat="server">
        <div class="span12">
            <label class="span6 labelClass">Kriptolama Algoritmasını Seç</label>
            <div class="span6">
                <asp:DropDownList ID="ddKriptolamaSec" CssClass="fontClass" runat="server" Style="width: auto; border-radius: 5px; height: 30px;">
                    <asp:ListItem Value="" Text="Seçiniz"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Hash Şifreleme"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Simetrik Şifreleme"></asp:ListItem>
                    <asp:ListItem Value="3" Text="Asimetrik Şifreleme"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </form>
</body>
</html>
