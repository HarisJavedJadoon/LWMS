<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Vendor/Office/Main.Master" AutoEventWireup="true" CodeBehind="VendorProfile.aspx.cs" Inherits="LWMS.Secure.Vendor.WebPages.VendorProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContent" runat="server">
    <!-- Row -->
    <div class="row">


        <!-- Column -->
        <div class="col-lg-4 col-xlg-3 col-md-5">
            <div class="card">
                <div class="card-body">
                    <center class="m-t-30">
                        <img src="~/Assets/Vendor/images/users/test.jpg" id="imgpatient" class="img-circle" runat="server" width="150" />
                        <h4 class="card-title m-t-10" id="lblName" runat="server"></h4>
                       <%-- <h6 class="card-subtitle">Accoubts Manager Amix corp</h6>
                        <div class="row text-center justify-content-md-center">
                            <div class="col-4"><a href="javascript:void(0)" class="link"><i class="icon-people"></i><font class="font-medium">254</font></a></div>
                            <div class="col-4"><a href="javascript:void(0)" class="link"><i class="icon-picture"></i><font class="font-medium">54</font></a></div>
                        </div>--%>
                    </center>
                </div>
                <div>
                    <hr>
                </div>

            </div>
        </div>
        <!-- Column -->
        <!-- Column -->
        <div class="col-lg-8 col-xlg-9 col-md-7">
            <div class="card">
                <div id="divMessages" runat="server"></div>
                <div class="card-body">
                    <div class="form-horizontal form-material">
                        <div class="form-group">
                            <label class="col-md-12">Full Name</label>
                            <div class="col-md-12">
                                <asp:TextBox ID="txtName" CssClass="form-control form-control-line" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="example-email" class="col-md-12">Email</label>
                            <div class="col-md-12">
                                <asp:TextBox ID="txtEmail" CssClass="form-control form-control-line" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-12">Password</label>
                            <div class="col-md-12">
                                <asp:TextBox ID="txtPassword" CssClass="form-control form-control-line" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-12">CNIC No</label>
                            <div class="col-md-12">
                                <asp:TextBox ID="txtCNICNo" CssClass="form-control form-control-line" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-12">Mobile No</label>
                            <div class="col-md-12">
                                <asp:TextBox ID="txtMobileNo" CssClass="form-control form-control-line" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-12">Landline</label>
                            <div class="col-md-12">
                                <asp:TextBox ID="txtLandline" CssClass="form-control form-control-line" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-12">SalesTax No</label>
                            <div class="col-md-12">
                                <asp:TextBox ID="txtSalesTaxNo" CssClass="form-control form-control-line" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-12">NTN No</label>
                            <div class="col-md-12">
                                <asp:TextBox ID="txtNTNNo" CssClass="form-control form-control-line" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-12">Description</label>
                            <div class="col-md-12">
                                <asp:TextBox ID="txtDescription" TextMode="MultiLine" CssClass="form-control form-control-line" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-12">Office Address</label>
                            <div class="col-md-12">
                                <asp:TextBox ID="txtOfficeAddress" TextMode="MultiLine" CssClass="form-control form-control-line" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-md-12">Profile Picture</label>
                            <div class="col-md-12">
                                <asp:FileUpload ID="fupImage" runat="server" />
                                <asp:HiddenField ID="hfvImageURL" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <asp:Button ID="btnUpdate" CssClass="btn btn-success" runat="server" Text="Update Profile" OnClick="btnUpdate_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Column -->
    </div>
    <!-- Row -->
</asp:Content>
