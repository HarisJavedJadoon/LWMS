<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="LWMS.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!-- Tell the browser to be responsive to screen width -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <!-- Favicon icon -->
    <link rel="icon" type="image/png" sizes="16x16" href="Assets/Vendor/images/favicon.png" />
    <title>eProcurement</title>
    <!-- Bootstrap Core CSS -->
    <link href="Assets/Vendor/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Morries chart CSS -->
    <link href="Assets/Vendor/plugins/morrisjs/morris.css" rel="stylesheet" />


    <!-- Custom CSS -->
    <link href="Assets/Vendor/css/style.css" rel="stylesheet" />
    <!-- You can change the theme colors from here -->
    <link href="Assets/Vendor/css/colors/blue.css" id="theme" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- ============================================================== -->
        <!-- Preloader - style you can find in spinners.css -->
        <!-- ============================================================== -->
        <div class="preloader">
            <svg class="circular" viewBox="25 25 50 50">
                <circle class="path" cx="50" cy="50" r="20" fill="none" stroke-width="2" stroke-miterlimit="10" />
            </svg>
        </div>
        <!-- ============================================================== -->
        <!-- Main wrapper - style you can find in pages.scss -->
        <!-- ============================================================== -->

        <section id="wrapper" class="login-register login-sidebar" style="background-image: url(Assets/Vendor/images/logo/maxresdefault-10.jpg);">
            <div class="login-box card">
                <div id="divMessages" runat="server"></div>
                <div class="card-body">
                    <div class="form-horizontal form-material">
                        <a href="javascript:void(0)" class="text-center db">
                            <img src="../../Assets/Admin/images/logo/logo.png" alt="" height="22" class="logo logo-dark" /></a>
                        <h3 class="box-title m-t-40 m-b-0">Register Now</h3>
                        <div class="form-group  m-t-20">
                            <div class="col-xs-12">
                                <asp:TextBox ID="txtName" CssClass="form-control" placeholder="Name" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                                    ValidationGroup="SignUp" Display="Dynamic" InitialValue="" ErrorMessage="Required"
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group ">
                            <div class="col-xs-12">
                                <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="Email" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                    ValidationGroup="SignUp" Display="Dynamic" InitialValue="" ErrorMessage="Required"
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <asp:TextBox ID="txtMobileNo" CssClass="form-control" placeholder="Mobile NO" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobileNo"
                                    ValidationGroup="SignUp" Display="Dynamic" InitialValue="" ErrorMessage="Required"
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group ">
                            <div class="col-xs-12">
                                <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Password" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                                    ValidationGroup="SignUp" Display="Dynamic" InitialValue="" ErrorMessage="Required"
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-12">
                                <div class=" p-t-0">
                                    <asp:CheckBox ID="chkSignUp" runat="server" />
                                    <label for="checkbox-signup">I agree to all <a href="#">Terms</a></label>

                                </div>
                            </div>
                        </div>
                        <div class="form-group text-center m-t-20">
                            <div class="col-xs-12">
                                <asp:Button ID="btnSignUp" ValidationGroup="SignUp" CssClass="btn btn-info btn-lg btn-block text-uppercase waves-light" runat="server" Text="Sign Up" OnClick="btnSignUp_Click" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <p style="display: inline; text-align: left !important;">Already have an account? <a href="Login.aspx" style="display: inline; text-align: left !important;" class="text-info"><b style="display: inline; text-align: left !important;">Sign In</b></a></p>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </section>

        <!-- ============================================================== -->
        <!-- End Wrapper -->
        <!-- ============================================================== -->
        <!-- ============================================================== -->

    </form>

    <!-- All Jquery -->
    <!-- ============================================================== -->
    <scripts>
        <script src="Assets/Vendor/plugins/jquery/jquery.min.js"></script>
        <!-- Bootstrap tether Core JavaScript -->
        <script src="Assets/Vendor/plugins/bootstrap/js/popper.min.js"></script>

        <script src="Assets/Vendor/plugins/bootstrap/js/bootstrap.min.js"></script>
        <!-- slimscrollbar scrollbar JavaScript -->
        <script src="Assets/Vendor/js/jquery.slimscroll.js"></script>
        <!--Wave Effects -->
        <script src="Assets/Vendor/js/waves.js"></script>
        <!--Menu sidebar -->
        <script src="Assets/Vendor/js/sidebarmenu.js"></script>
        <!--stickey kit -->
        <script src="Assets/Vendor/plugins/sticky-kit-master/dist/sticky-kit.min.js"></script>
        <script src="Assets/Vendor/plugins/sparkline/jquery.sparkline.min.js"></script>
        <!--Custom JavaScript -->
        <script src="Assets/Vendor/js/custom.min.js"></script>
        <!-- ============================================================== -->
        <!-- This page plugins -->
        <!-- ============================================================== -->

        <!-- ============================================================== -->
        <!-- Style switcher -->
        <!-- ============================================================== -->
        <script src="Assets/Vendor/plugins/styleswitcher/jQuery.style.switcher.js"></script>
    </scripts>
</body>
</html>
