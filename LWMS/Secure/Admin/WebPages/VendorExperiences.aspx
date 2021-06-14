<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Admin/Office/Main.Master" AutoEventWireup="true" CodeBehind="VendorExperiences.aspx.cs" Inherits="LWMS.Secure.Admin.WebPages.VendorExperiences" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContent" runat="server">

    <div class="row" style="margin-top: 80px;">
        <div class="col-lg-12">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title mb-4">Vendor Experience</h4>
                    <div class="row">
                        <div class="col-lg-12">
                            <div id="divMessages" runat="server"></div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="mb-3">
                                        <label class="form-label">Vendor</label>
                                        <asp:DropDownList ID="ddlVendor" Enabled="false" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="0" Text="Please Select Vendor" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="mb-3">
                                        <label class="form-label">Company Name</label>
                                        <asp:TextBox ID="txtCompanyName" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="form-label">Company Type</label>
                                        <asp:DropDownList ID="ddlCompanyType" Enabled="false" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="0" Text="Please Select Company Type" />
                                            <asp:ListItem Value="T" Text="Technical" />
                                            <asp:ListItem Value="N" Text="Non-Technical" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="form-label">Description</label>
                                        <asp:TextBox ID="txtDescription" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label class="form-label">Company Address</label>
                                        <asp:TextBox ID="txtCompanyAddress" Enabled="false" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="form-label">Company Contact Number</label>
                                        <asp:TextBox ID="txtCompanyContactNumber" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="form-label">Tender Amount</label>
                                        <asp:TextBox ID="txtTenderAmount" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="form-label">From Date</label>
                                        <asp:TextBox ID="txtFromDate" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="form-label">From Date</label>
                                        <asp:TextBox ID="txtToDate" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row ">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="form-label">Status</label>
                                        <asp:DropDownList ID="ddlStatus" Enabled="false" runat="server" CssClass="form-control">
                                            <asp:ListItem Selected="True" Text="Please Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Active" Value="A"></asp:ListItem>
                                            <asp:ListItem Text="InActive" Value="I"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>


                            <div class="mt-3">
                                <asp:Button ID="btnSave" CssClass="btn btn-primary d-none" runat="server" Style="width: 100px;" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnClear" CssClass="btn btn-success d-none" runat="server" Style="width: 100px;" Text="Clear" OnClick="btnClear_Click" />
                                <asp:Button ID="btnBack" CssClass="btn btn-dark" runat="server" Style="width: 100px;" Text="Back" PostBackUrl="~/Secure/Admin/WebPages/Default.aspx" />

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
