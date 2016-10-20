<%@ Page Title="Todo Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoDetails.aspx.cs" Inherits="COMP229_F2016_MidTerm_300861065.TodoDetails" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <!--Subject : Web Application
        Name: Bhavin Master
        Student No: 300861065
        File Name : TodoDetails.aspx-->
     <div class="container">
        <div class="row">
            <div class="col-md-offset-3 col-md-6">
                <h1>Todo Details</h1>
                <h5>All Fields are required</h5>
                <br />

                <div class="form-group">
                    <label class="control-label" for="DescriptionDescriptionBox">Todo Description</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="DescriptionDescriptionBox" 
                        placeholder="Todo Description" required="true"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label class="control-label" for="NotesTextBox">Todo Notes</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="NotesTextBox" 
                        placeholder="Todo Notes" required="true"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label class="control-label" for="Completion">Completion</label>
                    <asp:CheckBox runat="server" CssClass="form-control" ID="Completion" 
                        placeholder="Completion" required="true"></asp:CheckBox>Completed
                </div>

                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server"
                        UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click" />
                    <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server"
                        OnClick="SaveButton_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
