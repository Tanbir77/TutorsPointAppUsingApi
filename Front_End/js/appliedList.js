if (localStorage.userType != undefined) {
  if (localStorage.userType == 'tutor')
    window.location.href = 'Profile.html'
} else {
  window.location.href = 'SignIn.html'
}

function _calculateAge(birthday) {
  birthday = new Date(birthday)
  var ageDifMs = Date.now() - birthday.getTime();
  var ageDate = new Date(ageDifMs);
  return Math.abs(ageDate.getUTCFullYear() - 1970);
}

var tutorToHtml = function (tutor) {
  var tableHtml = `<tr>
                    <table class="post">
                      <tr><td align="right">Name</td><td>${tutor.tutorName}</td></tr>
                      <tr><td align="right">Age</td><td>${_calculateAge(tutor.dob)}</td></tr>
                      <tr><td align="right">Gender</td><td>${tutor.gender}</td></tr>
                      <tr><td align="right">Email</td><td>${tutor.email}</td></tr>
                      <tr><td align="right">Phone</td><td>${tutor.phone}</td></tr>
                      <tr><td align="right">Institution</td><td>${tutor.institution}</td></tr>
                    </table>
                  </tr>
                  `
  return tableHtml
}

var showAppliedList = function (appliedList) {
  var tableHtml = '<table>'
  for (var i = 0; i < appliedList.length; i++) {
    tableHtml += tutorToHtml(appliedList[i])
  }
  tableHtml += '</table>'
  $('#appliedList').html(tableHtml)
}

$(function () {
  var user = JSON.parse(localStorage.userData)
  var parentId = user.parentId
  $.ajax({
    url: 'http://localhost:54153/api/appliedLists/' + parentId,
    complete: function (xmlhttp) {
      if (xmlhttp.status == 200) {
        var data = xmlhttp.responseJSON;
        console.log(data)
        showAppliedList(data)
      }
      else {
        alert(xmlhttp.status + ": " + xmlhttp.statusText);
      }
    }
  });
})