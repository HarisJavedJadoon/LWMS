﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Vendor/Office/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LWMS.Secure.Vendor.WebPages.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContent" runat="server">
    <!-- ============================================================== -->
    <!-- Start Page Content -->
    <!-- ============================================================== -->
    <div class="row">
        <!-- Column -->
        <div class="col-lg-3 col-md-6">
            <div class="card">
                <div class="card-body">
                    <!-- Row -->
                    <div class="row">
                        <div class="col-8">
                            <h2>2376 <i class="ti-angle-down font-14 text-danger"></i></h2>
                            <h6>Order Received</h6>
                        </div>
                        <div class="col-4 align-self-center text-right  p-l-0">
                            <div id="sparklinedash3"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Column -->
        <div class="col-lg-3 col-md-6">
            <div class="card">
                <div class="card-body">
                    <!-- Row -->
                    <div class="row">
                        <div class="col-8">
                            <h2 class="">3670 <i class="ti-angle-up font-14 text-success"></i></h2>
                            <h6>Tax Deduction</h6>
                        </div>
                        <div class="col-4 align-self-center text-right p-l-0">
                            <div id="sparklinedash"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Column -->
        <div class="col-lg-3 col-md-6">
            <div class="card">
                <div class="card-body">
                    <!-- Row -->
                    <div class="row">
                        <div class="col-8">
                            <h2>1562 <i class="ti-angle-up font-14 text-success"></i></h2>
                            <h6>Revenue Stats</h6>
                        </div>
                        <div class="col-4 align-self-center text-right p-l-0">
                            <div id="sparklinedash2"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Column -->
        <div class="col-lg-3 col-md-6">
            <div class="card">
                <div class="card-body">
                    <!-- Row -->
                    <div class="row">
                        <div class="col-8">
                            <h2>35% <i class="ti-angle-down font-14 text-danger"></i></h2>
                            <h6>Yearly Sales</h6>
                        </div>
                        <div class="col-4 align-self-center text-right p-l-0">
                            <div id="sparklinedash4"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Row -->
    <div class="row">
        <div class="col-lg-8 col-md-7">
            <div class="card">
                <div class="card-body">
                    <div class="d-flex flex-wrap">
                        <div>
                            <h4 class="card-title">Yearly Earning</h4>
                        </div>
                        <div class="ml-auto">
                            <ul class="list-inline">
                                <li>
                                    <h6 class="text-muted text-success"><i class="fa fa-circle font-10 m-r-10 "></i>iMac</h6>
                                </li>
                                <li>
                                    <h6 class="text-muted  text-info"><i class="fa fa-circle font-10 m-r-10"></i>iPhone</h6>
                                </li>

                            </ul>
                        </div>
                    </div>
                    <div id="morris-area-chart2" style="height: 405px;"></div>

                </div>
            </div>
            <div class="card card-default">
                <div class="card-header">
                    <div class="card-actions">
                        <a class="" data-action="collapse"><i class="ti-minus"></i></a>
                        <a class="btn-minimize" data-action="expand"><i class="mdi mdi-arrow-expand"></i></a>
                        <a class="btn-close" data-action="close"><i class="ti-close"></i></a>
                    </div>
                    <h4 class="card-title m-b-0">Product Overview</h4>
                </div>
                <div class="card-body collapse show">
                    <div class="table-responsive">
                        <table class="table product-overview">
                            <thead>
                                <tr>
                                    <th>Customer</th>
                                    <th>Photo</th>
                                    <th>Quantity</th>
                                    <th>Date</th>
                                    <th>Status</th>
                                    <th>Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>Steave Jobs</td>
                                    <td>
                                        <img src="../../../Assets/Vendor/images/gallery/chair.jpg" alt="iMac" width="80">
                                    </td>
                                    <td>20</td>
                                    <td>10-7-2017</td>
                                    <td>
                                        <span class="label label-success font-weight-100">Paid</span>
                                    </td>
                                    <td><a href="javascript:void(0)" class="text-inverse p-r-10" data-toggle="tooltip" title="" data-original-title="Edit"><i class="ti-marker-alt"></i></a><a href="javascript:void(0)" class="text-inverse" title="" data-toggle="tooltip" data-original-title="Delete"><i class="ti-trash"></i></a></td>
                                </tr>
                                <tr>
                                    <td>Varun Dhavan</td>
                                    <td>
                                        <img src="../../../Assets/Vendor/images/gallery/chair2.jpg" alt="iPhone" width="80">
                                    </td>
                                    <td>25</td>
                                    <td>09-7-2017</td>
                                    <td>
                                        <span class="label label-warning font-weight-100">Pending</span>
                                    </td>
                                    <td><a href="javascript:void(0)" class="text-inverse p-r-10" data-toggle="tooltip" title="" data-original-title="Edit"><i class="ti-marker-alt"></i></a><a href="javascript:void(0)" class="text-inverse" title="" data-toggle="tooltip" data-original-title="Delete"><i class="ti-trash"></i></a></td>
                                </tr>
                                <tr>
                                    <td>Ritesh Desh</td>
                                    <td>
                                        <img src="../../../Assets/Vendor/images/gallery/chair3.jpg" alt="apple_watch" width="80">
                                    </td>
                                    <td>12</td>
                                    <td>08-7-2017</td>
                                    <td>
                                        <span class="label label-success font-weight-100">Paid</span>
                                    </td>
                                    <td><a href="javascript:void(0)" class="text-inverse p-r-10" data-toggle="tooltip" title="" data-original-title="Edit"><i class="ti-marker-alt"></i></a><a href="javascript:void(0)" class="text-inverse" title="" data-toggle="tooltip" data-original-title="Delete"><i class="ti-trash"></i></a></td>
                                </tr>
                                <tr>
                                    <td>Hrithik</td>
                                    <td>
                                        <img src="../../../Assets/Vendor/images/gallery/chair4.jpg" alt="mac_mouse" width="80">
                                    </td>
                                    <td>18</td>
                                    <td>02-7-2017</td>
                                    <td>
                                        <span class="label label-danger font-weight-100">Failed</span>
                                    </td>
                                    <td><a href="javascript:void(0)" class="text-inverse p-r-10" data-toggle="tooltip" title="" data-original-title="Edit"><i class="ti-marker-alt"></i></a><a href="javascript:void(0)" class="text-inverse" title="" data-toggle="tooltip" data-original-title="Delete"><i class="ti-trash"></i></a></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-4 col-md-5">
            <!-- Column -->
            <div class="card card-default">
                <div class="card-header">
                    <div class="card-actions">
                        <a class="" data-action="collapse"><i class="ti-minus"></i></a>
                        <a class="btn-minimize" data-action="expand"><i class="mdi mdi-arrow-expand"></i></a>
                        <a class="btn-close" data-action="close"><i class="ti-close"></i></a>
                    </div>
                    <h4 class="card-title m-b-0">Order Stats</h4>
                </div>
                <div class="card-body collapse show">
                    <div id="morris-donut-chart" class="ecomm-donute" style="height: 317px;"></div>
                    <ul class="list-inline m-t-20 text-center">
                        <li>
                            <h6 class="text-muted"><i class="fa fa-circle text-info"></i>Order</h65>
                                    <h4 class="m-b-0">8500</h4>
                        </li>
                        <li>
                            <h6 class="text-muted"><i class="fa fa-circle text-danger"></i>Pending</h6>
                            <h4 class="m-b-0">3630</h4>
                        </li>
                        <li>
                            <h6 class="text-muted"><i class="fa fa-circle text-success"></i>Delivered</h6>
                            <h4 class="m-b-0">4870</h4>
                        </li>
                    </ul>

                </div>
            </div>
            <!-- Column -->
            <div class="card card-default">
                <div class="card-header">
                    <div class="card-actions">
                        <a class="" data-action="collapse"><i class="ti-minus"></i></a>
                        <a class="btn-minimize" data-action="expand"><i class="mdi mdi-arrow-expand"></i></a>
                        <a class="btn-close" data-action="close"><i class="ti-close"></i></a>
                    </div>
                    <h4 class="card-title m-b-0">Offer for you</h4>
                </div>
                <div class="card-body collapse show bg-info">
                    <div id="myCarousel" class="carousel slide" data-ride="carousel">
                        <!-- Carousel items -->
                        <div class="carousel-inner">
                            <div class="carousel-item flex-column">
                                <i class="fa fa-shopping-cart fa-2x text-white"></i>
                                <p class="text-white">25th Jan</p>
                                <h3 class="text-white font-light">Now Get <span class="font-bold">50% Off</span><br>
                                    on buy</h3>
                                <div class="text-white m-t-20">
                                    <i>- Ecommerce site</i>
                                </div>
                            </div>
                            <div class="carousel-item flex-column">
                                <i class="fa fa-shopping-cart fa-2x text-white"></i>
                                <p class="text-white">25th Jan</p>
                                <h3 class="text-white font-light">Now Get <span class="font-bold">50% Off</span><br>
                                    on buy</h3>
                                <div class="text-white m-t-20">
                                    <i>- Ecommerce site</i>
                                </div>
                            </div>
                            <div class="carousel-item flex-column active">
                                <i class="fa fa-shopping-cart fa-2x text-white"></i>
                                <p class="text-white">25th Jan</p>
                                <h3 class="text-white font-light">Now Get <span class="font-bold">50% Off</span><br>
                                    on buy</h3>
                                <div class="text-white m-t-20">
                                    <i>- Ecommerce site</i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Column -->
            <div class="card card-default">
                <div class="card-header">
                    <div class="card-actions">
                        <a class="" data-action="collapse"><i class="ti-minus"></i></a>
                        <a class="btn-minimize" data-action="expand"><i class="mdi mdi-arrow-expand"></i></a>
                        <a class="btn-close" data-action="close"><i class="ti-close"></i></a>
                    </div>
                    <h4 class="card-title m-b-0">Latest Products</h4>
                </div>
                <div class="card-body p-0 collapse show text-center">
                    <div id="myCarousel2" class="carousel slide" data-ride="carousel">
                        <!-- Carousel items -->
                        <div class="carousel-inner">
                            <div class="carousel-item flex-column">
                                <img src="../../../Assets/Vendor/images/gallery/chair.jpg" alt="user">
                                <h4 class="m-b-30">Brand New Chair</h4>
                            </div>
                            <div class="carousel-item flex-column">
                                <img src="../../../Assets/Vendor/images/gallery/chair2.jpg" alt="user">
                                <h4 class="m-b-30">Brand New Chair</h4>
                            </div>
                            <div class="carousel-item flex-column active carousel-item-left">
                                <img src="../../../Assets/Vendor/images/gallery/chair3.jpg" alt="user">
                                <h4 class="m-b-30">Brand New Chair</h4>
                            </div>
                            <div class="carousel-item flex-column carousel-item-next carousel-item-left">
                                <img src="../../../Assets/Vendor/images/gallery/chair4.jpg" alt="user">
                                <h4 class="m-b-30">Brand New Chair</h4>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Row -->


    <!-- Row -->

    <!-- Row -->
    <!-- Row -->

    <!-- Row -->
    <!-- ============================================================== -->
    <!-- End PAge Content -->
    <!-- ============================================================== -->
</asp:Content>