﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MediaSharingSystem.index" MasterPageFile="~/MSS.master" %>
<asp:Content ID="headContainer" ContentPlaceHolderID="HeadPlaceHolder" Runat="Server">
   <link href="Resources/Styles/post-style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="contentContainer" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <div id="IndexContent">
        <div id="content-container">
            <div id="content-wrapper">
                <div id="postWrapper" runat="server">
                    <!-- Dynamic content -->
                </div>
            </div>
        </div>
    </div>
</asp:Content>
