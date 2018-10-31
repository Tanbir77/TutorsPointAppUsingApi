if (localStorage.userType != undefined) {
	window.location.href = 'Profile.html'
}

$(function () {
	var validateLogInData = function () {
		$('.errorMessage').text('');

		var isValid = true
		var email = $('#email').val()
		var pass = $('#pass').val()
		
		var pattern = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/
		if (!pattern.test(email)) {
			if (email.trim().length == 0) {
				$('#errMsgEmail').text('email is required')
			} else {
				$('#errMsgEmail').text('Not a valid email')
			}
			isValid = false
		}
		if (pass.trim().length < 4) {
			if (pass.trim().length == 0) {
				$('#errMsgPass').text('Password is required')
			} else {
				$('#errMsgPass').text('Password length 6 minimum')
			}
			isValid = false
		}

		return isValid
	}

	$('#loginBtn').click(function () {
		if (validateLogInData()) {
			localStorage.credential = btoa($('#email').val() + ':' + $('#pass').val());
			$.ajax({
				url: 'http://localhost:54153/api/users',
				headers: {
			        Authorization: 'Basic ' + localStorage.credential
			    },
				complete: function (xmlhttp) {
					if (xmlhttp.status == 200) {
						var data = xmlhttp.responseJSON;
						localStorage.userData = JSON.stringify(data);
						localStorage.userType = data.parentName ? "parent" : "tutor";
						window.location.href = 'Profile.html'
					}
					else {
						$('#errMsgPass').text('Email or password is invalid')
						alert(xmlhttp.status + ": " + xmlhttp.statusText);

					}
				}
			});
		}
	});
});