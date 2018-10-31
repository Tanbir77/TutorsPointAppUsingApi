$(function () {
  $('#name').change(function() {
    var name = $('#name').val()
    if (name.trim().length != 0) {
      $('#errMsgName').text('')
    }
  })

  $('input[type=radio][name=gender]').change(function() {
    var gender = $('input[name=gender]:checked').val()
    if (gender != undefined) {
      $('#errMsgGender').text('')
    }
  })

  $('#phone').change(function() {
    var phone = $('#phone').val()
    if (phone.trim().length == 11 && phone.startsWith('01')) {
      $('#errMsgPhone').text('')
    }
  })

  $('#email').change(function() {
    var email = $('#email').val()
    var pattern = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/
		if (pattern.test(email)) {
				$('#errMsgEmail').text('')
    }
  })

  $('#address').change(function() {
    var address = $('#address').val()
    if (address.trim().length != 0) {
      $('#errMsgAddress').text('')
    }
  })

  $('#pass').change(function() {
    var pass = $('#pass').val()
    if (pass.trim().length >= 4) {
      $('#errMsgPass').text('')
    }
  })

  $('#conPass').change(function() {
    var pass = $('#pass').val()
    var conPass = $('#conPass').val()
    if (conPass.trim() === pass.trim()) {
      $('#errMsgConPass').text('')
    }
  })

  $('#dob').change(function() {
    var dob = $('#dob').val()
    if (dob != '') {
      $('#errMsgDob').text('')
    }
  })

  $('#institution').change(function() {
    var institution = $('#institution').val()
    if (institution.trim().length != 0) {
      $('#errMsgInstitution').text('')
    }
  })

  $('#title').change(function() {
    var title = $('#title').val()
    if (title.trim().length != 0) {
      $('#errMsgTitle').text('')
    }
  })

  $('#class').change(function() {
    var cls = $('#class').val()
    if (cls.trim().length != 0) {
      $('#errMsgClass').text('')
    }
  })

  $('#dPW').change(function() {
    var dPW = $('#dPW').val()
    if (dPW != 0) {
      $('#errMsgDPW').text('')
    }
  })
  
  $('#salary').change(function() {
    var salary = $('#salary').val()
    if (salary != 0) {
      $('#errMsgSalary').text('')
    }
  })
  
  $('#preferable').change(function() {
    var preferable = $('#preferable').val()
    if (preferable.trim().length != 0) {
      $('#errMsgPreferable').text('')
    }
  })
  
  $('#subs').change(function() {
    var subs = $('#subs').val()
    if (subs.trim().length != 0) {
      $('#errMsgSubs').text('')
    }
  })
  
  $('#medium').change(function() {
    var medium = $('#medium').val()
    if (medium.trim().length != 0) {
      $('#errMsgMedium').text('')
    }
  })
})