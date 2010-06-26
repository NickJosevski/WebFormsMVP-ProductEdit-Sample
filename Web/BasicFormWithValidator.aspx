<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BasicFormWithValidator.aspx.cs" Inherits="WebFormEventModelExperiments.BasicFormWithValidator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Name: <asp:TextBox id="name" runat="server" />
        <asp:RequiredFieldValidator ID="reqFName"
            ControlToValidate="name"  Display="Dynamic" EnableClientScript="False"
            ErrorMessage="The name field is required!"
            runat="server" >
					<img src="/Resources/gui/warning.gif" border="0" 
						title="Name is required" 
						alt="Name is required" />
        </asp:RequiredFieldValidator>
        <br />
        Desc: <asp:TextBox id="desc" runat="server" />
        <asp:RequiredFieldValidator ID="reqFDesc"
        ControlToValidate="desc"  Display="Dynamic" EnableClientScript="False"
        ErrorMessage="The name field is required!"
        runat="server" >
					<img src="/Resources/gui/warning.gif" border="0" 
						title="Desc is required" 
						alt="Desc is required" />
        </asp:RequiredFieldValidator>
        <br /><br />
        <asp:Button ID="complete" runat="server" Text="Submit" />
        <br /><br />
    </div>
    </form>
</body>
</html>
