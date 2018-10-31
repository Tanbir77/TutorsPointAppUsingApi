if (localStorage.userType != undefined) {
  window.location.href = 'Profile.html'
}

$(function () {
  var validateSignUpData = function (userType) {
    $('.errorMessage').text('');

    var isValid = true
    var name = $('#name').val()
    var gender = $('input[name=gender]:checked').val()
    var phone = $('#phone').val()
    var email = $('#email').val()
    var address = $('#address').val()
    var pass = $('#pass').val()
    var conPass = $('#conPass').val()

    var dob = $('#dob').val()
    var institution = $('#institution').val()

    if (name.trim().length == 0) {
      $('#errMsgName').text('Name is required')
      isValid = false
    }

    if (gender == undefined) {
      $('#errMsgGender').text('Select Gender')
      isValid = false
    }

    if (phone.trim().length != 11 && !phone.startsWith('01')) {
      if (phone.trim().length == 0) {
        $('#errMsgPhone').text('Phone is required')
      } else {
        $('#errMsgPhone').text('Invalid Phone No')
      }
      isValid = false
    }

    var pattern = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/
    if (!pattern.test(email)) {
      if (email.trim().length == 0) {
        $('#errMsgEmail').text('email is required')
      } else {
        $('#errMsgEmail').text('Not a valid email')
      }
      isValid = false
    }

    if (userType == 'parent') {
      if (address.trim().length == 0) {
        $('#errMsgAddress').text('Address is required')
        isValid = false
      }
    }
    
    if (pass.trim().length < 6) {
      if (pass.trim().length == 0) {
        $('#errMsgPass').text('Password is required')
      } else {
        $('#errMsgPass').text('Password length 6 minimum')
      }
      isValid = false
    }

    if (conPass.trim() != pass.trim()) {
      $('#errMsgConPass').text('Password doesn\'t match')
      isValid = false
    }
    if (conPass.trim().length == 0) {
      $('#errMsgConPass').text('Confirm Password')
      isValid = false
    }

    if (userType == 'tutor') {
      if (dob == '') {
        $('#errMsgDob').text('Select Date Of Birth')
        isValid = false
      }

      if (institution.trim().length == 0) {
        $('#errMsgInstitution').text('Institution is required')
        isValid = false
      }
    }

    return isValid
  }

  var sendData = function (url, postData) {
    $.ajax({
      url: url,
      method: 'POST',
      header: 'Content-Type: application/json',
      data: postData,
      complete: function (xmlhttp) {
        if (xmlhttp.status == 201) {
          $('#form').hide();
          $('#success').show();
        }
        else {
          alert(xmlhttp.status + ": " + xmlhttp.statusText);
        }
      }
    });
  }

  $('#parentSubmit').click(function () {
    if (validateSignUpData('parent')) {
      var url = 'http://localhost:54153/api/parents'
      var data = {
        parentName: $('#name').val(),
        gender: $('input[name=gender]:checked').val(),
        email: $('#email').val(),
        phone: $('#phone').val(),
        address: $('#address').val(),
        password: $('#pass').val()
      }
      sendData(url, data)
    }
  })

  $('#tutorSubmit').click(function () {
    if (validateSignUpData('tutor')) {
      var url = 'http://localhost:54153/api/tutors'
      var data = {
        tutorName: $('#name').val(),
        gender: $('input[name=gender]:checked').val(),
        email: $('#email').val(),
        phone: $('#phone').val(),
        password: $('#pass').val(),
        dOB: $('#dob').val(),
        institution: $('#institution').val()
      }
      sendData(url, data)
    }
  })
});