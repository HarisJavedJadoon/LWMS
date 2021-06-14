<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LWMS.Login" %>

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
    <title>LWMS</title>
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
                            <img src="Assets/Vendor/images/logo/logo.png" height="22" alt="Home" />
                            <div class="form-group m-t-40">
                                <div class="col-xs-12">
                                    <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="Email" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-12">
                                    <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Password" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-12">
                                    <div class="checkbox checkbox-primary pull-left p-t-0">
                                        <asp:CheckBox ID="chkSignUp" runat="server" />
                                        <label for="checkbox-signup">Remember me </label>
                                    </div>
                                    <a href="#" id="to-recover" class="text-dark pull-right"><i class="fa fa-lock m-r-5"></i>Forgot pwd?</a>
                                </div>
                            </div>
                            <div class="form-group text-center m-t-20">
                                <div class="col-xs-12">
                                    <asp:Button ID="btnLogin" CssClass="btn btn-info btn-lg btn-block text-uppercase waves-light" runat="server" Text="Log In" OnClick="btnLogin_Click" />
                                </div>
                            </div>

                            <div class="form-group m-b-0">
                                <div class="col-sm-12 text-center">
                                    <p>Don't have an account? <a href="SignUp.aspx" class="text-primary m-l-5"><b>Sign Up</b></a></p>
                                </div>
                            </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- ============================================================== -->
        <!-- End Wrapper -->
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
