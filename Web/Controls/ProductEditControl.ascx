<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ProductEditControl.ascx.cs" 
Inherits="WebFormEventModelExperiments.Controls.ProductEditControl" %>
<%@ Register TagPrefix="mvp" Namespace="WebFormsMvp.Web" Assembly="WebFormsMvp" %>
<div>
	<h1 id="hd" runat="server"><%# Model.HeaderText %></h1>

	<div class="alert" id="validationInfo" runat="server" Visible="<%# !Model.IsValid %>">
		<h4 id="pageErrorSummary" runat="server">There was a problem with the following data:</h4>
		<asp:ValidationSummary ID="validationSummary" runat="server" Visible="false"></asp:ValidationSummary>
	</div>
					
	<asp:FormView ID="productFV" runat="server" DataSourceID="productDataSource" DataKeyNames="Id" DefaultMode="Edit">
		<EditItemTemplate>
		<fieldset>
			<h2>Details</h2> 
			<ul class="blanklist">
            <li>
				<asp:Label runat="server" Text="Product Name" />
				<asp:TextBox ID="pName" runat="server" Text='<%# Bind("ProductName") %>' />

				<asp:RequiredFieldValidator ID="nameReq" runat="server" ErrorMessage="Product Name is required" 
                    Display="Dynamic" 
                    ControlToValidate="pName">
					<img src="/Resources/gui/warning.gif" border="0" title="Product Name is required" alt="Product Name is required" />
				</asp:RequiredFieldValidator>
			</li>
			<li>
				<asp:Label ID="desc" runat="server" Text="Product Description" />
				<asp:TextBox ID="pDesc" runat="server" Text='<%# Bind("ProductDescription") %>' />

				<asp:RequiredFieldValidator ID="descReq" runat="server" ErrorMessage="Product Description is required" 
                    Display="Dynamic" 
                    ControlToValidate="pDesc">
					<img src="/Resources/gui/warning.gif" border="0" title="Product Description is required"  alt="Product Description is required" />
				</asp:RequiredFieldValidator>
			</li>
			<li>
				<asp:Label runat="server" Text="Product is Active?" />
				<asp:CheckBox ID="pActive" runat="server" Checked='<%# Bind("IsActive") %>' Text="* Unchecking this will disable the Product." />
			</li>
            </ul>
		</fieldset>
		<div id="inputBase">
			<asp:Button ID="update" runat="server" CommandName="Update" Text="<%# Model.ActionText %>" CausesValidation="True" />
			<asp:Button ID="delete" runat="server" CommandName="Delete" Text="Delete" Visible="<%# !Model.IsNew %>" />
		</div>
		</EditItemTemplate>
	</asp:FormView>

    <mvp:PageDataSource ID="productDataSource" runat="server"
	    EnablePaging="true"
	    DataObjectTypeName="WebFormEventModelExperiments.Logic.Domain.Product"
	    ConflictDetection="CompareAllValues"
	    OldValuesParameterFormatString="original{0}"
	    SelectMethod="GetProduct"
	    UpdateMethod="UpdateProduct"
	    DeleteMethod="DeleteProduct"
	    >
    </mvp:PageDataSource>
</div>