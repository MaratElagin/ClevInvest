function openEdit() {
    document.getElementById('descText').classList.add('d-none');
    document.getElementById('editForm').classList.remove('d-none');
    document.getElementById('editedDescr').value = document.getElementById('artDesc').innerHTML.trim();
}

function closeEdit() {
    document.getElementById('descText').classList.remove('d-none');
    document.getElementById('editForm').classList.add('d-none');
}

function editDescription() {
    var id = document.getElementById('artId').innerText;
    var descr = document.getElementById('editedDescr').value;
    $.ajax({
        url: "/api/article",
        // dataType: "json", // Для использования JSON формата получаемых данных
        method: "POST", // Что бы воспользоваться POST методом, меняем данную строку на POST   
        data: JSON.stringify({"Id": id, "Description": descr}),
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            if (data.result == "ok") {
                document.getElementById('artDesc').innerHTML = descr;
                closeEdit();
            } else {
                console.log(data);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function CancelComment() {
    document.getElementById('commentMessage').value = "";
}

function logout() {
    $.ajax({
        url: "/api/session",
        // dataType: "json", // Для использования JSON формата получаемых данных
        method: "DELETE", // Что бы воспользоваться POST методом, меняем данную строку на POST
        success: function (data) {
            if (data.result == "ok")
                window.location.replace("/LoginRegister/Login");
            else {
                console.log(data);
            }
            // Возвращаемые данные выводим в консоль
        },
        error: function (error) {
            console.log(error);
        }
    });
}

