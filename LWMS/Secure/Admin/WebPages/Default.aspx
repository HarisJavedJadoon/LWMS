<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Admin/Office/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LWMS.Secure.Admin.WebPages.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContent" runat="server">
    <div class="page-content">
        <div class="container-fluid">

            <!-- start page title -->
            <div class="row">
                <div class="col-12">
                    <div class="row">
                        <div class="col-12">
                            <div id="divMessages" runat="server"></div>
                        </div>
                    </div>
                    <div class="card">
                        <asp:ListView ID="lsvMain" ItemPlaceholderID="phMain" OnItemCommand="lsvMain_ItemCommand" runat="server">
                            <LayoutTemplate>
                                <table id="datatable" class="table table-bordered dt-responsive nowrap" style="border-collapse: collapse; border-spacing: 0; width: 100%;">

                                    <thead>
                                        <th>Vendor</th>
                                        <th>Mobile #</th>
                                        <th>CNIC #</th>
                                        <th style="width: 150px">SalesTax #</th>
                                        <th>Status</th>
                                        <th class="text-nowrap">Action</th>
                                        <th></th>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="phMain" runat="server" />
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("Name") %></td>
                                    <td><%# Eval("MobileNo") %></td>
                                    <td><%# Eval("CNICNo") %></td>
                                    <td><%# Eval("SalesTaxNo") %></td>
                                    <td>
                                        <asp:LinkButton ID="lnkStatus" CommandName="ChangeStatus" CommandArgument='<%# Eval("ID")%>'
                                            runat="server" OnClientClick="javascript:return confirm('Are you sure you want to change the status?');"><%# (Eval("Status").ToString() == "A") ? "Active" : "InActive" %></asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnk" CssClass="btn btn-danger w-100" CausesValidation="false" ToolTip="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("ID")%>'
                                            runat="server">Blacklist</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkEdit" CssClass="btn btn-primary w-100" CausesValidation="false" ToolTip="Edit" CommandName="EditRecord" CommandArgument='<%# Eval("ID")%>'
                                            runat="server">Vendor Experience</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <div class="table-responsive">
                                    <table class="table table-bordered">
                                        <thead>
                                            <tr>
                                                <th>Company</th>
                                                <th>Description</th>
                                                <th>Number</th>
                                                <th style="width: 150px">Tender Amount</th>
                                                <th>Status</th>
                                                <th class="text-nowrap">Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:PlaceHolder ID="phMain" runat="server" />
                                        </tbody>
                                        <tr>
                                            <td colspan="7" style="text-align: center;">
                                                <i>No record exist</i>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </div>
                </div>
                <!-- end col -->
            </div>
            <!-- end row -->
        </div>
        <!-- container-fluid -->
    </div>
    <!-- End Page-content -->
</asp:Content>
