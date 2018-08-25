<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="TreeControl.Views.Shared.Test" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" /> 
    <title></title>
    <script runat="server">
        void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<TreeControl.User> users = null;
                using (TreeControl.Database1Entities dc = new TreeControl.Database1Entities())
                {
                    users = dc.Users.OrderBy(a => a.Id).ToList();
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/DataReport.rdlc");
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource("ReportDataSet", users);
                    ReportViewer1.LocalReport.DataSources.Add(rdc);
                    ReportViewer1.LocalReport.Refresh();
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>        
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="false" SizeToReportContent="true">
            
        </rsweb:ReportViewer>
    </form>
</body>
</html>
