/*
Template Name: Amezia - Responsive Bootstrap 4 Admin Dashboard
Author: Themesbrand
Version: 1.0.0
Website: https://themesbrand.com/
Contact: themesbrand@gmail.com
File: Session Timeout Js File
*/

$.sessionTimeout({
    keepAliveUrl: 'page-starter.html',
    logoutButton:'Logout',
    logoutUrl: 'auth-login.html',
    redirUrl: 'auth-lock-screen.html',
    warnAfter: 3000,
    redirAfter: 30000,
    countdownBar: true
});