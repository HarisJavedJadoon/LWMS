<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Vendor/Office/Main.Master" AutoEventWireup="true" CodeBehind="VendorExperiencesList.aspx.cs" Inherits="LWMS.Secure.Vendor.WebPages.VendorExperiencesList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContent" runat="server">
    <!-- Row -->
    <div class="row">
        <div class="col-lg-12">
            <div class="card card-outline-info">

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
                        
                    </div>
                    <div class="form-actions">                        
                        <asp:Button ID="btnNew" CssClass="btn btn-info" runat="server" style="width:100px;" Text="New" PostBackUrl="~/Secure/Vendor/WebPages/VendorExperiences.aspx" />
                    </div>

                </div>
            </div>
        </div>
    </div>
    <!-- Row -->
    <div class="row">
        <div class="col-12">
            <div class="card">
                <asp:ListView ID="lsvMain" ItemPlaceholderID="phMain" OnItemCommand="lsvMain_ItemCommand" runat="server">
                    <LayoutTemplate>
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
                            </table>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>                           
                            <td><%# Eval("CompanyName") %></td>
                            <td><%# Eval("Description") %></td>
                            <td><%# Eval("CompanyContactNumber") %></td>
                            <td><%# Eval("TenderAmount") %></td>                            
                            <td>
                                <asp:LinkButton ID="lnkStatus" CommandName="ChangeStatus" CommandArgument='<%# Eval("ID")%>'
                                    runat="server" OnClientClick="javascript:return confirm('Are you sure you want to change the status?');"><%# (Eval("Status").ToString() == "A") ? "Active" : "InActive" %></asp:LinkButton>
                            </td>
                            <td class="text-nowrap">
                                <asp:LinkButton ID="lnkEdit" CausesValidation="false" ToolTip="Edit" CommandName="EditRecord" CommandArgument='<%# Eval("ID")%>'
                                    runat="server"><i class="fa fa-pencil text-inverse m-r-10"></i></asp:LinkButton>
                                <asp:LinkButton ID="lnk" CausesValidation="false" ToolTip="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("ID")%>'
                                    runat="server"><i class="fa fa-close text-danger"></i></asp:LinkButton>
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
                                    <td colspan="6" style="text-align: center;">
                                        <i>No record exist</i>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
</asp:Content>
