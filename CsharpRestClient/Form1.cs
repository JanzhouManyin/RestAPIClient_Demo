using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsharpRestClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        #region UI Event Hndeler
        private void cmdGO_Click(object sender, EventArgs e)
        {
            RestClass rClient = new RestClass();

            rClient.endPoint = txtRequestURI.Text;
            rClient.authTech = autheticationTechnique.RollYourOwn;
            rClient.authType = authenticationType.Basic;
            rClient.userName = txtUserName.Text;
            rClient.userPassword = txtPassword.Text;

            if (rdoBasicAuth.Checked)
            {
                rClient.authType = authenticationType.Basic;
                debugOutput("authenticationType.Basic");
            }
            else {
                rClient.authType = authenticationType.NTLM;
                debugOutput("authenticationType.NTLM");
            }

            if (rdoRollOwn.Checked)
            {
                rClient.authTech = autheticationTechnique.RollYourOwn;
                debugOutput("autheticationTechnique.RollYourOwn;");
            }
            else
            {
                rClient.authTech = autheticationTechnique.NetworkCredential;
                debugOutput("autheticationTechnique.NetworkCredential");
            }

            debugOutput("RESTClient Object created.");

            string strJSON = string.Empty;

            strJSON = rClient.MakeRequest();

            debugOutput(strJSON);
        }
        #endregion
        private void debugOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                txtResponse.Text = txtResponse.Text + strDebugText + Environment.NewLine;
                txtResponse.SelectionStart = txtResponse.TextLength;
                txtResponse.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }
    }
}
