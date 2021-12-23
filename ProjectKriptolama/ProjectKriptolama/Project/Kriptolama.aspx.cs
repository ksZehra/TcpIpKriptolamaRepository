using ProjectKriptolama.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectKriptolama.Project
{
    public partial class Kriptolama : System.Web.UI.Page
    {      
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack && !IsCallback)
                {
                    ddAlgoritmaSec.Items.Clear();
                    ddAlgoritmaSec.Items.Add(new ListItem("Seçiniz", "0"));
                }
            }
            catch (Exception myExp)
            {
                lbError.Text = myExp.Message.ToString();
                divError.Style.Add("display", "block");
            }
        }

        protected void ddTurSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddAlgoritmaSec.Items.Clear();

                if (ddTurSec.SelectedValue == "1")
                {
                    ddAlgoritmaSec.Items.Add(new ListItem("Seçiniz", "0"));
                    ddAlgoritmaSec.Items.Add(new ListItem("MD5", "MD5"));
                    ddAlgoritmaSec.Items.Add(new ListItem("SHA1", "SHA1"));
                    ddAlgoritmaSec.Items.Add(new ListItem("SHA256", "SHA256"));
                    ddAlgoritmaSec.Items.Add(new ListItem("SHA384", "SHA384"));
                    ddAlgoritmaSec.Items.Add(new ListItem("SHA512", "SHA512"));
                    btnDesifrele.Visible = false;
                }
                else if (ddTurSec.SelectedValue == "2")
                {
                    ddAlgoritmaSec.Items.Add(new ListItem("Seçiniz", "0"));
                    ddAlgoritmaSec.Items.Add(new ListItem("DES", "DES"));
                    ddAlgoritmaSec.Items.Add(new ListItem("3DES", "3DES"));
                    ddAlgoritmaSec.Items.Add(new ListItem("RC2", "RC2"));
                    ddAlgoritmaSec.Items.Add(new ListItem("Rijndanel", "Rijndanel"));
                    btnDesifrele.Visible = true;
                }
                else
                {
                    ddAlgoritmaSec.Items.Add(new ListItem("Seçiniz", "0"));
                    btnDesifrele.Visible = true;
                }
            }
            catch (Exception myExp)
            {
                lbError.Text = myExp.Message.ToString();
                divError.Style.Add("display", "block");
            }
        }

        protected void btnSifrele_Click(object sender, EventArgs e)
        {
            try
            {
                string cipherText = "";
                SifreIslemleri sifre = new SifreIslemleri();

                if (ddAlgoritmaSec.SelectedValue == "MD5")
                {
                    cipherText = sifre.MD5(tbPlainText.Text);
                }
                else if (ddAlgoritmaSec.SelectedValue == "SHA1")
                {
                    cipherText = sifre.SHA1(tbPlainText.Text);
                }
                else if (ddAlgoritmaSec.SelectedValue == "SHA256")
                {
                    cipherText = sifre.SHA256(tbPlainText.Text);
                }
                else if (ddAlgoritmaSec.SelectedValue == "SHA384")
                {
                    cipherText = sifre.SHA384(tbPlainText.Text);
                }
                else if (ddAlgoritmaSec.SelectedValue == "SHA512")
                {
                    cipherText = sifre.SHA512(tbPlainText.Text);
                }
                else if (ddAlgoritmaSec.SelectedValue == "DES")
                {
                    cipherText = sifre.DESSifrele(tbPlainText.Text, tbKey.Text);
                }
                else if (ddAlgoritmaSec.SelectedValue == "3DES")
                {
                    cipherText = sifre.TDESEncrypt(tbPlainText.Text, tbKey.Text);
                }
                else if (ddAlgoritmaSec.SelectedValue == "RC2")
                {
                    cipherText = sifre.RC2Sifrele(tbPlainText.Text, tbKey.Text);
                }
                else if (ddAlgoritmaSec.SelectedValue == "Rijndanel")
                {
                    cipherText = sifre.RijndaelSifrele(tbPlainText.Text, tbKey.Text);
                }

                tbCipherText.Text = cipherText;
            }
            catch (Exception myExp)
            {
                lbError.Text = myExp.Message.ToString();
                divError.Style.Add("display", "block");
            }
        }

        protected void btnDesifrele_Click(object sender, EventArgs e)
        {
            try
            {
                string plainText = "";
                SifreIslemleri sifre = new SifreIslemleri();

                if (ddTurSec.SelectedValue == "1")
                {
                    throw new Exception("Hash algoritmaları deşifre edilemez!");
                }

                if (ddAlgoritmaSec.SelectedValue == "DES")
                {
                    plainText = sifre.DESCoz(tbCipherText.Text, tbKey.Text);
                }
                else if (ddAlgoritmaSec.SelectedValue == "3DES")
                {
                    plainText = sifre.TDESDecrypt(tbCipherText.Text, tbKey.Text);
                }
                else if (ddAlgoritmaSec.SelectedValue == "RC2")
                {
                    plainText = sifre.RC2Coz(tbCipherText.Text, tbKey.Text);
                }
                else if (ddAlgoritmaSec.SelectedValue == "Rijndanel")
                {
                    plainText = sifre.RijndaelCoz(tbCipherText.Text, tbKey.Text);
                }

                tbPlainText.Text = plainText;
            }
            catch (Exception myExp)
            {
                lbError.Text = myExp.ToString();
                divError.Style.Add("display", "block");
            }
        }
    }
}