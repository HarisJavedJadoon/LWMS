<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LWMS.Default" %>

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
<body style="margin: 0px;">
    <form id="form1" runat="server">
        <section id="wrapper" class="login-register login-sidebar" style="background-image: url(Assets/Vendor/images/sigmund-aI4RJ--Mw4I-unsplash.jpg);">
            <div class="row">
                <div class="col-lg-12">
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-8">
                                <h3 class="font-bold text-white mt-5 mb-5" style="font-size: 38px; line-height: 1.5;">Welcome To Lahore Waste
                                        <br />
                                    Management  Company
                                
                                </h3>
                            </div>
                            <div class="col-lg-4">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                            </div>
                            <div class="col-lg-2">
                            </div>
                            <div class="col-lg-4">

                                <a href="Secure/Admin/Login.aspx" class="mt-5 btn bg-warning btn-lg text-uppercase waves-light">Admin</a> &nbsp;&nbsp;
                                 <a href="Login.aspx" class="mt-5 btn bg-light-primary btn-lg  text-uppercase waves-light">Vendor</a>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </section>
    </form>
</body>
</html>
