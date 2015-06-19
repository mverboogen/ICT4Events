<%@ Page Title="" Language="C#" MasterPageFile="~/MSS.Master" AutoEventWireup="true" CodeBehind="comment.aspx.cs" Inherits="MediaSharingSystem.comment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <link href="Resources/Styles/comments-style.css" rel="stylesheet" type="text/css" />
    <link href="Resources/Styles/index-style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="CommentContent">
        <div id="content-container">
            <div id="content-wrapper">
                <div id="commentWrapper" runat="server">
                    <!-- Dynamic content -->
                </div>
            </div>
        </div>
    </div>
</asp:Content>
