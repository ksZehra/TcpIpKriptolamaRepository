using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectKriptolama.Project
{
    public partial class Kriptolama : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                ddAlgoritmaSec.Items.Clear();
                ddAlgoritmaSec.Items.Add(new ListItem("Seçiniz", "0"));
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
                }
                else if (ddTurSec.SelectedValue == "2")
                {
                    ddAlgoritmaSec.Items.Add(new ListItem("Seçiniz", "0"));
                    ddAlgoritmaSec.Items.Add(new ListItem("DES", "DES"));
                    ddAlgoritmaSec.Items.Add(new ListItem("3DES", "3DES"));
                    ddAlgoritmaSec.Items.Add(new ListItem("RC2", "RC2"));
                    ddAlgoritmaSec.Items.Add(new ListItem("Rijndanel", "Rijndanel"));
                }
                else if (ddTurSec.SelectedValue == "3")
                {
                    ddAlgoritmaSec.Items.Add(new ListItem("Seçiniz", "0"));
                    ddAlgoritmaSec.Items.Add(new ListItem("DSA", "DSA"));
                    ddAlgoritmaSec.Items.Add(new ListItem("RSA", "RSA"));
                }
                else
                {
                    ddAlgoritmaSec.Items.Add(new ListItem("Seçiniz", "0"));
                }
            }
            catch (Exception myExp)
            {
                throw myExp;
            }
        }

        protected void btnSifrele_Click(object sender, EventArgs e)
        {

        }
    }
}