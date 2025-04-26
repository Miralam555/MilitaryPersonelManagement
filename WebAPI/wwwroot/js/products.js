$(document).ready(function () {
    var token = sessionStorage.getItem("token");

    if (!token) {
        alert("Zəhmət olmasa login olun.");
        window.location.href = "/api/auth/login";
        return;
    }

    $.ajax({
        type: "GET",
        url: "/api/militaryrank/getall", // API endpoint burada dəyişə bilər (öz API adresinə bax)
        headers: {
            "Authorization": "Bearer " + token
        },
        success: function (data) {
            $("#productsTable").DataTable({
                data: data,
                columns: [
                    { data: "id" },
                    { data: "personelid" },
                    { data: "personelname" },
                    { data: "personelsurname" },
                    { data: "injunctionid" },
                    { data: "injunctionnumber" },
                    { data: "rankname" }
                ]
            });
        },
        error: function (xhr) {
            console.error("Data yüklenmedi:", xhr.responseText);
            if (xhr.status === 401) {
                alert("Session vaxtı bitib. Yenidən login olun.");
                window.location.href = "/api/auth/login";
            }
        }
    });
});
