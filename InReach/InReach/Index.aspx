<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="InReach.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" />
    <style>
        body {
            background-color: black;
        }

        .jumbotron {
            margin-top: 10%;
            background-color: white !important;
            border: solid 1px;
            border-radius: 5px;
            width: 70%;
        }

        input[type=email], .fu {
            max-width: 250px;
            max-height: 50px;
            font-family: Tahoma;
            font-size: 18px;
            border-radius: 2px;
            padding: 1%;
        }
    </style>
    <title>Upload File</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <center>
            <div class="jumbotron">
                <div class="container">
                    <div class="alert alert-success" runat="server" id="sucessmsg">
                        <strong>Success!</strong> File has been uploaded please see your email.
                    </div>
                    <div class="alert alert-danger" runat="server" id="errormsg">
                        <strong>Failed!</strong> Error While Uploading File to Server.
                    </div>
                    <h3>InReach File Upload</h3>
                    <input type="email" runat="server" id="txtemail" required="required" placeholder="user@email.com"/><br /><br />
                    <asp:FileUpload runat="server" ID="FileUpload" CssClass="btn btn-danger fu" /><br /><br />
                    <asp:Button ID="btnSubmit" Text="Upload File" runat="server" OnClick="btnSubmit_Click" CssClass="btn btn-success" UseSubmitBehavior="false"/>
                </div>
            </div>
            </center>
        </div>
    </form>
</body>
</html>
