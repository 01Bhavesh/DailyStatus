<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskList.aspx.cs" Inherits="WebFormPractice.TaskList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <select id ="TaskList"></select>
            <br/>
            <select>
                <option value="0">select</option>
                <option value="deepak">deepak</option>
                <option value="mayur">mayur</option>
            </select>
            <br/>
            <button id="submit">submit<//button>
        </div>
    </form>
</body>
</html>
