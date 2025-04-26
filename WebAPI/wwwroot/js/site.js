$(document).ready(function () {
    $("#loginForm").submit(function (e) {
        e.preventDefault();

        var data = {
            email: $("#email").val(),
            password: $("#password").val()
        };
        console.log(data);
        $.ajax({
            type: "POST",
            url: "https://localhost:44362/api/auth/login", 
            contentType: "application/json",
            data: JSON.stringify(data),
            success: function (response) {
                console.log("Login Successful!", response);
                
                sessionStorage.setItem("token", response.token);
                alert("Daxil oldun!");
                window.location.href = "/products"; 
            },
            error: function (xhr) {
                console.error("Login failed:", xhr.responseText);
                alert("İstifadəçi adı və ya şifrə səhvdir.");
            }
        });
    });
});
