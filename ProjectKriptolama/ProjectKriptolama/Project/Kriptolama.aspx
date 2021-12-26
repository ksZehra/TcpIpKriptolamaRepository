<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kriptolama.aspx.cs" Inherits="ProjectKriptolama.Project.Kriptolama" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kriptolama</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link href="../Css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <script src="../bootstrap.js"></script>
    <script src="../bootstrap.min.js"></script>

    <style type="text/css">
        .fontClass {
            font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
            font-size: 14px !important;
        }

        .labelClass {
            float: left;
            padding: 4px 1px 7px 0;
            font-weight: bold;
            width: 150px;
        }

        .multilineHeightClass {
            max-width: 1368px;
        }

        .col-lg-12 {
            padding-left: 5px !important;
        }

        .col-lg-6 {
            padding-left: 4px !important;
        }

        .tbBorderClass {
            border-color: #cccccc !important;
            border-radius: 5px !important;
        }
    </style>
</head>
<body style="background-color: #f2f2f2;">
    <form id="form1" runat="server" class="fontClass">

        <div class="row" runat="server" style="padding: 0 10px 0 10px; width: 99.5%; margin-left: 0.1%; margin-bottom: 0px !important; margin-top: 15px; display: none;" id="divError">
            <div class="col-lg-12 col-md-12" style="background-color: white; border: 1px solid #cc0000; border-radius: 5px; padding: 10px;">
                <center>
                    <asp:Label runat="server" Text="" ID="lbError" ForeColor="#cc0000" Font-Bold="true"></asp:Label>
                </center>
            </div>
        </div>

        <div class="row" style="padding: 0 10px 0 10px; width: 99.5%; margin-left: 0.1%; margin-bottom: 0px !important">
            <div class="col-lg-12" style="background-color: white; border: 1px solid #cccccc; margin-top: 15px; margin-bottom: 5px !important; padding: 10px; border-radius: 5px;">
                <center>
                    <h4 style="font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; font-weight: bold; font-size: 21px !important;">METİN ŞİFRELEME - ŞİFRE ÇÖZME</h4>
                </center>
            </div>
        </div>

        <div class="row" style="padding: 0 10px 10px 10px; width: 99.5%; margin-left: 0.1%;">
            <div class="col-lg-12 col-md-12 col-sm-12" style="background-color: white; border: 1px solid #cccccc; padding: 25px 0 25px 0; border-radius: 5px;">
                <div class="col-lg-12">
                    <label class="labelClass">Kriptolama Türü Seç:</label>
                    <asp:DropDownList ID="ddTurSec" CssClass="fontClass" AutoPostBack="true" OnSelectedIndexChanged="ddTurSec_SelectedIndexChanged" runat="server" Style="width: auto; border-radius: 5px; border-color: #cccccc; height: 28px;">
                        <asp:ListItem Value="0" Text="Seçiniz"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Hash Şifreleme"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Simetrik Şifreleme"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <label class="labelClass">Algoritma Seç:</label>
                    <asp:DropDownList ID="ddAlgoritmaSec" CssClass="fontClass" runat="server" Style="width: auto; border-radius: 5px; height: 28px; border-color: #cccccc;">
                    </asp:DropDownList>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12" id="divKey" style="display: none;">
                    <label class="labelClass">Anahtar:</label>
                    <asp:TextBox ID="tbKey" runat="server" Height="28px" BorderWidth="1px" CssClass="tbBorderClass"></asp:TextBox>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-12" style="padding-right: 0px !important;">
                    <label class="labelClass">Şifrelenecek Metin:</label>
                    <asp:TextBox ID="tbPlainText" runat="server" TextMode="MultiLine" Height="200px" Width="77%" CssClass="multilineHeightClass tbBorderClass"></asp:TextBox>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6" style="padding-right: 0px !important;">
                    <div class="col-lg-12 col-md-12 col-sm-12" runat="server">
                        <label class="labelClass">Şifrelenmiş Metin:</label>
                        <asp:TextBox ID="tbCipherText" runat="server" TextMode="MultiLine" Height="200px" Width="77%" CssClass="multilineHeightClass tbBorderClass"></asp:TextBox>
                    </div>
                </div>
                <asp:HiddenField ID="hfKey" ClientIDMode="Static" runat="server" />
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12" style="background-color: white; border: 1px solid #cccccc; margin-top: 5px; padding: 20px; border-radius: 5px;">
                <center>
                    <asp:Button runat="server" ID="btnSifrele" Text="Şifrele" OnClick="btnSifrele_Click" CssClass="btn btn-success" Style="margin-right: 5px;" />
                    <button onclick="functionClear();" class="btn btn-info" style="margin-right: 5px;">Temizle</button>
                    <asp:Button runat="server" ID="btnDesifrele" Text="Deşifrele" OnClick="btnDesifrele_Click" CssClass="btn btn-warning" Visible="true" />
                </center>
            </div>
        </div>
    </form>

    <script type="text/javascript">
        $(function () {
            $('#ddTurSec').change(function () {
                var selVal = this.value;
                if (selVal == "2") {
                    $('#hfKey').val('show');
                }
                else {
                    $('#hfKey').val('hide');
                }

                $('#tbKey').val('');
                $('#tbPlainText').val('');
                $('#tbCipherText').val('');
            });

            if ($('#hfKey').val() == 'show') {
                $('#divKey').show();
            }
        });

        function functionClear() {
            $('#tbKey').val('');
            $('#tbPlainText').val('');
            $('#ddTurSec').val('0');
            $('#ddAlgoritmaSec').val('0');
            window.location.reload();
        }

        $("#btnSifrele").on('click', function () {
            if (($('#ddAlgoritmaSec').val() == 'DES' || $('#ddAlgoritmaSec').val() == 'RC2' || $('#ddAlgoritmaSec').val() == 'Rijndael') && $('#tbKey').val().length > 8) {
                window.alert('Anahtar uzunluğu 8 karakterden fazla olamaz!');
                return false;
            }
        });
    </script>
</body>
</html>
