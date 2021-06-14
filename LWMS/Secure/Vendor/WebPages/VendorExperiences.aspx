<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Vendor/Office/Main.Master" AutoEventWireup="true" CodeBehind="VendorExperiences.aspx.cs" Inherits="LWMS.Secure.Vendor.WebPages.VendorExperiences" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContent" runat="server">

    <!-- ============================================================== -->
    <!-- Start Page Content -->
    <!-- ============================================================== -->
    <!-- Row -->
    <div class="row">
        <div class="col-lg-12">
            <div class="card ">

                <div class="card-body">
                    <div class="row">
                        <div class="form-group col-md-12">
                            <div id="divMessages" runat="server">
                            </div>
                        </div>
                    </div>
                    <div class="form-body">
                        <h3 class="card-title">Vendor Experience</h3>
                        <hr>
                        <div class="row ">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">Vendor</label>
                                    <asp:DropDownList ID="ddlVendor" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0" Text="Please Select Vendor" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">Company Name</label>
                                    <asp:TextBox ID="txtCompanyName" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">Company Type</label>
                                    <asp:DropDownList ID="ddlCompanyType" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0" Text="Please Select Company Type" />
                                        <asp:ListItem Value="T" Text="Technical" />
                                        <asp:ListItem Value="N" Text="Non-Technical" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">Description</label>
                                    <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label class="control-label">Company Address</label>
                                    <asp:TextBox ID="txtCompanyAddress" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">Company Contact Number</label>
                                    <asp:TextBox ID="txtCompanyContactNumber" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">Tender Amount</label>
                                    <asp:TextBox ID="txtTenderAmount" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">From Date</label>
                                    <asp:TextBox ID="txtFromDate" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">From Date</label>
                                    <asp:TextBox ID="txtToDate"  TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row ">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">Status</label>
                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                        <asp:ListItem Selected="True" Text="Please Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Active" Value="A"></asp:ListItem>
                                        <asp:ListItem Text="InActive" Value="I"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-actions">
                        <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Style="width: 100px;" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnClear" CssClass="btn btn-success" runat="server" Style="width: 100px;" Text="Clear" OnClick="btnClear_Click" />
                        <asp:Button ID="btnBack" CssClass="btn btn-inverse" runat="server" Style="width: 100px;" Text="Back" PostBackUrl="~/Secure/Vendor/WebPages/VendorExperiencesList.aspx" />

                    </div>

                </div>
            </div>
        </div>
    </div>
    <!-- Row -->

</asp:Content>
