<%@ Page Title="" Language="C#" MasterPageFile="~/MSS.Master" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="MediaSharingSystem.upload" %>
<asp:Content ID="headContainer" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <link href="Resources/Styles/upload-style.css" rel="stylesheet" type="text/css" />

    <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=UploadPreviewImage.ClientID%>').prop('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }
    </script>
</asp:Content>
<asp:Content ID="contentContainer" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="UploadContent">
        <div id="content-container">
            <div id="content-wrapper">
                <div id="UploadMenu" class="upload-menu" runat="server">
                    <a href="upload.aspx?upload=photo"><div class="upload-type-button">Photo</div></a>
                    <a href="upload.aspx?upload=video"><div class="upload-type-button">Video</div></a>
                    <a href="upload.aspx?upload=message"><div class="upload-type-button">Message</div></a>
                </div>

                <div id="UploadFile" class="upload-file" runat="server">
                    <asp:FileUpload id="FileUploadControl" onchange="ShowImagePreview(this)" runat="server" />

                    <div id="preview-wrapper">
                        <img id="UploadPreviewImage" class="upload-preview" src="Resources/Images/preview.png" runat="server" />
                    </div>
                </div>

                <div id="UploadMessage" class="upload-message" runat="server">
                    <div id="title-wrapper">
                        <span>Title</span>
                        <asp:TextBox ID="TitleTextBox" CssClass="title-textbox" runat="server" />
                    </div>
                    <div id="message-content-wrapper">
                        <span>Content</span>
                        <asp:TextBox ID="ContentTextBox" CssClass="content-textbox" TextMode="MultiLine" runat="server" />
                    </div>
                </div>
                <div id="controls-wrapper">
                    <asp:Label ID="StatusLabel" runat="server" />
                    <asp:Button ID="UploadButton" CssClass="upload-button" Text="Upload" onClick="UploadButton_Click" runat="server" />
                </div>

            </div>
        </div>
    </div>
</asp:Content>
