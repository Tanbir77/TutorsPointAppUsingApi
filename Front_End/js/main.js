$(function () {
  var changeNavBar = function (userType) {
    $('#profile').show();
    $('#logOut').show();
    $('#signUp').hide();
    $('#login').hide();

    if (userType === 'parent') {
      $('#job').show();
      $('#applies').show();
      $('#find').hide();
    }
    else if (userType === 'tutor') {
      $('#find').show();
    }
    else {
      $('#find').show();
      $('#signUp').show();
      $('#login').show();

      $('#job').hide();
      $('#applies').hide();
      $('#profile').hide();
      $('#logOut').hide();
    }
  }

  if (localStorage.userType != undefined) {
    if (localStorage.userType == "parent") {
      changeNavBar('parent');
    }
    else {
      changeNavBar('tutor');
    }
  }
  else {
    changeNavBar(false);
  }

  $('#logOut').click(function () {
    localStorage.clear();
  });
})