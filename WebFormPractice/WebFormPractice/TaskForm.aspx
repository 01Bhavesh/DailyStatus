<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskForm.aspx.cs" Inherits="WebFormPractice.TaskForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Task List</h2>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TaskId" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="199px" >
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Title" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
