$(function () {
	var changeNavBar = function (userType) {
		if (userType === 'parent') {
			$('#job').show();
			$('#applies').show();
			$('#find').hide();
		}
		else if (userType === 'tutor') {
			$('#find').show();
			$('#job').hide();
			$('#applies').hide();
		}
	}

	function getOnlyDate(dateTime) {
		dt = new Date(dateTime)
		return  dt.getDate() + "-" + (dt.getMonth() + 1) + "-" +  + dt.getFullYear();
	}

	var showParentInfo = function (data) {
		$('#profileType').text('Profile Info (Parent)');
		$('#name').val(data.parentName);
		$('#gender').val(data.gender);
		$('#phone').val(data.phone);
		$('#email').val(data.email);
		$('#address').val(data.address);
		$('#password').val(data.password);

		$('#loginView').hide();
		$('#parentProfileView').show();
		changeNavBar('parent');
	}

	var showTutorInfo = function (data) {
		$('#profileType').text('Profile Info (Tutor)');
		$('#tName').val(data.tutorName);
		$('#tGender').val(data.gender);
		$('#date').val(getOnlyDate(data.dob));
		$('#tPhone').val(data.phone);
		$('#tEmail').val(data.email);
		$('#institution').val(data.institution);
		$('#tPassword').val(data.password);

		$('#loginView').hide();
		$('#tutorProfileView').show();
		changeNavBar('tutor');
	}
	    if (localStorage.userType && localStorage.userData) {
	var userData = JSON.parse(localStorage.userData)
	if (localStorage.userType == "parent") {
			showParentInfo(userData);
	}
	else {
			showTutorInfo(userData);
	}
	} else {
		window.location.href = 'SignIn.html'
	}

	var disableAttributes = function (isDisable = true) {
		$('input[type=text]').attr("disabled", isDisable);
	}

	var updateUserData = function (userType, newData) {
		var user = JSON.parse(localStorage.userData)
		var apiUrl = 'http://localhost:54153/api/'
		if (userType === 'parent') {
			apiUrl += 'parents/' + user.parentId
		} else {
			apiUrl += 'tutors/' + user.tutorId
		}

		$.ajax({
			type: 'PUT',
			url: apiUrl,
			headers: {
		        Authorization: 'Basic ' + localStorage.credential
		    },
			data: newData,
			complete: function (xmlhttp) {
				if (xmlhttp.status == 200) {
					var data = xmlhttp.responseJSON;
					localStorage.userData = JSON.stringify(data)
					disableAttributes();
					$('#btnforParent, #btnforTutor').val('Update');
				}
				else {
					window.location.href = 'SignIn.html'
				}
			}
		});

	}

	$('#btnforParent').click(function () {
		if ($('#btnforParent').val() == 'Update') {
			disableAttributes(false);
			$('#btnforParent').val('Save')
		} else {
			var newData = {
				parentName: $('#name').val(),
				gender: $('#gender').val(),
				phone: $('#phone').val(),
				email: $('#email').val(),
				address: $('#address').val(),
				password: $('#password').val()
			}
			updateUserData('parent', newData);
		}
	})

	$('#btnforTutor').click(function () {
		if ($('#btnforTutor').val() == 'Update') {
			disableAttributes(false);
			$('#btnforTutor').val('Save')
		} else {
			var newData = {
				tutorName: $('#tName').val(),
				dob: $('#date').val(),
				gender: $('#tGender').val(),
				email: $('#tEmail').val(),
				phone: $('#tPhone').val(),
				institution: $('#institution').val(),
				password: $('#tPassword').val()
			}
			updateUserData('tutor', newData);
		}
	})
})