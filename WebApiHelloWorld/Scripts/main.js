
$.getJSON("api/people")
	.done(function (data) {
		$.each(data, function (key, item) {
			appendNewPerson(item);
		});
	});

function getDeleteForm(id) {

	return "<input type=\"button\" value=\"delete\" onclick=\"deletePerson('" + id + "')\" />";
}

function appendNewPerson(data) {
	var item = data.FullName + " | " + data.Age + " " + getDeleteForm(data.Id) + "<br/>";
	$("#people").append(item);
}

function deletePerson(id) {
	$.ajax({
		type: "DELETE",
		url: "api/people",
		data: { Id: id },
		success: function (data, status) {
			if (status === "success") {
				window.location = "/";
			} else {
				$("#People").append("oops, the delete didn't work!");
			}
		}
	});	
}

function submitNewPerson() {
	$.ajax({
		type: "POST",
		url: "api/people",
		data: {
				FullName: $("#FullName").val(),
				Age: $("#Age").val()
		},
		success: function (data, status) {
			if (status === "success") {
				appendNewPerson(data);
			}
		}
	});
}

