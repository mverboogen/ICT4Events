<%@ Page Title="" Language="C#" MasterPageFile="~/MSS.Master" AutoEventWireup="true" CodeBehind="photos.aspx.cs" Inherits="MediaSharingSystem.photos" %>
<asp:Content ID="photosHead" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <link href="Resources/Styles/post-style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="photosContent" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="PhotosContent">
        <div id="content-container">
            <div id="content-wrapper">
                <div id="postWrapper" runat="server">
                    <!-- Dynamic content -->
                </div>
            </div>
        </div>
    </div>
</asp:Content>
