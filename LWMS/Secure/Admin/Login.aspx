<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LWMS.Secure.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>LWMS</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- App favicon -->
    <link rel="shortcut icon" href="../../../Assets/Admin/images/favicon.ico" />

    <!-- Bootstrap Css -->
    <link href="../../../Assets/Admin/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Icons Css -->
    <link rel="stylesheet" href="//cdn.materialdesignicons.com/5.4.55/css/materialdesignicons.min.css" />
    <!-- App Css-->
    <link href="../../../Assets/Admin/css/app.min.css" rel="stylesheet" type="text/css" />
</head>
<body class="authentication-bg">
    <form id="form1" runat="server">
        <div class="account-pages my-5 pt-sm-5">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="text-center">
                            <a href="index.html" class="mb-5 d-block auth-logo">
                                <img src="../../../Assets/Admin/images/logo-dark.png" alt="" height="22" class="logo logo-dark" />
                                <img src="../../../Assets/Admin/images/logo-light.png" alt="" height="22" class="logo logo-light" />
                            </a>
                        </div>
                    </div>
                </div>
                <div class="row align-items-center justify-content-center">
                    <div class="col-md-8 col-lg-6 col-xl-5">
                        <div class="card">
                            <div id="divMessages" runat="server"></div>
                            <div class="card-body p-4">
                                <div class="text-center mt-2">
                                    <h5 class="text-primary">Welcome Back !</h5>
                                    <p class="text-muted">Sign in to continue to LWMS.</p>
                                </div>
                                <div class="p-2 mt-4">

                                    <div class="mb-3">
                                        <label class="form-label" for="username">Username</label>
                                        <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" placeholder="Enter username"></asp:TextBox>

                                    </div>
                                    <div class="mb-3">
                                        <div class="float-end">
                                            <a href="#" class="text-muted">Forgot password?</a>
                                        </div>
                                        <label class="form-label" for="userpassword">Password</label>
                                        <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Enter password" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-check">
                                        <input type="checkbox" class="form-check-input" id="auth-remember-check">
                                        <label class="form-check-label" for="auth-remember-check">Remember me</label>
                                    </div>
                                    <div class="mt-3 text-end">
                                        <asp:Button ID="btnLogin" CssClass="btn btn-primary w-sm waves-effect waves-light" runat="server" Text="Log In" OnClick="btnLogin_Click" />
                                    </div>


                                    <div class="mt-4 text-center">
                                        <div class="signin-other-title">
                                            <h5 class="font-size-14 mb-3 title">Sign in with</h5>
                                        </div>
                                        <ul class="list-inline">
                                            <li class="list-inline-item">
                                                <a href="javascript:void()" class="social-list-item bg-primary text-white border-primary">
                                                    <i class="mdi mdi-facebook"></i>
                                                </a>
                                            </li>
                                            <li class="list-inline-item">
                                                <a href="javascript:void()" class="social-list-item bg-info text-white border-info">
                                                    <i class="mdi mdi-twitter"></i>
                                                </a>
                                            </li>
                                            <li class="list-inline-item">
                                                <a href="javascript:void()" class="social-list-item bg-danger text-white border-danger">
                                                    <i class="mdi mdi-google"></i>
                                                </a>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="mt-5 text-center">
                            <p>
                                ©
                                <script>document.write(new Date().getFullYear())</script>
                                Minible. Crafted with <i class="mdi mdi-heart text-danger"></i>by Themesbrand
                            </p>
                        </div>

                    </div>
                </div>
                <!-- end row -->
            </div>
            <!-- end container -->
        </div>
    </form>
    <!-- JAVASCRIPT -->
    <script src="../../../Assets/Admin/libs/jquery/jquery.min.js"></script>
    <script src="../../../Assets/Admin/libs/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="../../../Assets/Admin/libs/metismenu/metisMenu.min.js"></script>
    <script src="../../../Assets/Admin/libs/simplebar/simplebar.min.js"></script>
    <script src="../../../Assets/Admin/libs/node-waves/waves.min.js"></script>
    <script src="../../../Assets/Admin/libs/waypoints/lib/jquery.waypoints.min.js"></script>
    <script src="../../../Assets/Admin/libs/jquery.counterup/jquery.counterup.min.js"></script>

    <!-- App js -->
    <script src="../../../Assets/Admin/js/app.js"></script>
</body>

</html>
