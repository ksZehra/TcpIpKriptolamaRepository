<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kriptolama.aspx.cs" Inherits="ProjectKriptolama.Project.Kriptolama" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kriptolama</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link href="../Css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <style type="text/css">
        .fontClass {
            font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
            font-size: 14px !important;
        }

        .labelClass {
            float: left;
            padding: 4px 10px 0 0;
            font-weight: bold;
            width: 160px;
        }

        .multilineHeightClass {
            max-width: 1368px;
        }

        .span12 {
            padding: 0 0 10px 0 !important;
        }
    </style>
</head>
<body>
    <form id="form1" style="padding: 0px 20px 0 20px !important;" runat="server">
        <div class="span12" style="margin-top: 22px;">
            <center>
                <h4 style="font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; font-weight: bold; font-size: 22px !important;">METİN ŞİFRELEME</h4>
            </center>
        </div>
        <div class="fontClass" style="border: 1px solid white; box-shadow: 0 0 100px 10px grey; border-radius: 5px; padding: 10px;">
            <div class="span12">
                <div class="span6">
                    <label class="labelClass">Kriptolama Türü Seç:</label>
                </div>
                <div class="span6">
                    <asp:DropDownList ID="ddTurSec" CssClass="fontClass" AutoPostBack="true" OnSelectedIndexChanged="ddTurSec_SelectedIndexChanged" runat="server" Style="width: auto; border-radius: 5px; height: 28px;">
                        <asp:ListItem Value="0" Text="Seçiniz"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Hash Şifreleme"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Simetrik Şifreleme"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Asimetrik Şifreleme"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="span12">
                <div class="span6">
                    <label class="labelClass">Algoritma Seç:</label>
                </div>
                <div class="span6">
                    <asp:DropDownList ID="ddAlgoritmaSec" CssClass="fontClass" runat="server" Style="width: auto; border-radius: 5px; height: 28px;">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="span12">
                <div class="span6">
                    <label class="labelClass">Şifrelenecek Metin:</label>
                </div>
                <div class="span6">
                    <asp:TextBox ID="tbPlainText" runat="server" TextMode="MultiLine" Height="150px" Width="89%" CssClass="multilineHeightClass"></asp:TextBox>
                </div>
            </div>
            <div class="span12" id="divKey" style="display: none;">
                <div class="span6">
                    <label class="labelClass">Anahtar:</label>
                </div>
                <div class="span6">
                    <asp:TextBox ID="tbKey" runat="server"></asp:TextBox>
                </div>
            </div>
            <asp:HiddenField ID="hfKey" ClientIDMode="Static" runat="server" />


        </div>
        <div class="span12" style="margin-top: 20px; padding: 10px;">
            <center>
                <asp:Button runat="server" ID="btnSifrele" Text="Şifrele & Gönder" OnClick="btnSifrele_Click" CssClass="btn btn-success" /></center>
        </div>
    </form>

    <script type="text/javascript">
        $(function () {
            $('#ddTurSec').change(function () {
                var selVal = this.value;
                if (selVal == "2" || selVal == "3") {
                    $('#hfKey').val('show');
                }
                else {
                    $('#hfKey').val('hide');
                }
            });

            if ($('#hfKey').val() == 'show') {
                $('#divKey').show();
            }
        });
    </script>
</body>
</html>
