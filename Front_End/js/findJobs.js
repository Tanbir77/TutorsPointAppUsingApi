var userLogginIn = false;
if (localStorage.userType != undefined) {
  if (localStorage.userType == 'parent')
    window.location.href = 'Profile.html'
  userLogginIn = true;
}

let data = [];

function applyForJob(id) {
  if (!userLogginIn)
    window.location.href = 'SignIn.html'

  var user = JSON.parse(localStorage.userData)
  var userEmail = user.email

  $.ajax({
    type: 'POST',
    url: 'http://localhost:54153/api/applies',
    headers: {
        Authorization: 'Basic ' + localStorage.credential
    },
    data: {
      postId: id,
      tutorEmail: userEmail
    },
    complete: function (xmlhttp) {
      if (xmlhttp.status == 201) {
        $(`input[onclick="applyForJob(${id})"]`).val('Applied').css("background-color", "green")
      }
      else {
        alert(xmlhttp.status + ": " + xmlhttp.statusText);
      }
    }
  });
}

var jobToHtml = function (job) {
  return `<tr>
            <table class="post">
              <tr><td align="right">Title</td><td>${job.title}</td></tr>
              <tr><td align="right">Class</td><td>${job.cls}</td></tr>
              <tr><td align="right">Days Per Week</td><td>${job.daysPerWeek}</td></tr>
              <tr><td align="right">Salary</td><td>${job.salary}</td></tr>
              <tr><td align="right">Subjects</td><td>${job.sub}</td></tr>
              <tr><td align="right">Medium</td><td>${job.medium}</td></tr>
              <tr><td align="right">Location</td><td>${job.location}</td></tr>
              <tr><td align="right">Gender</td><td>${job.gender}</td></tr>
              <tr><td align="right">Preferable</td><td>${job.preferable}</td></tr>
              <tr><td align="right">Phone</td><td>${job.phone}</td></tr>
              <tr><td align="right">Contact Email</td><td>${job.parentEmail}</td></tr>
            </table>
            <input onclick="applyForJob(${job.postId})" style="margin-left: 15vw" type="button" class="button" id="apply" value="Apply">
          </tr>`
}

var showJobs = function (jobs) {
  var tableHtml = '<table>'
  for (var i = 0; i < jobs.length; i++) {
    tableHtml += jobToHtml(jobs[i])
  }
  tableHtml += '</table>'
  $('#jobs').html(tableHtml)
}

$(function () {
  $.ajax({
    url: 'http://localhost:54153/api/posts',
    complete: function (xmlhttp) {
      if (xmlhttp.status == 200) {
        data = xmlhttp.responseJSON;
        showJobs(data)
      } else {
        alert(xmlhttp.status + ": " + xmlhttp.statusText);
      }
    }
  });

  $('#searchOptions').change(function () {
    if ($('#searchOptions').val() == 'salaryHTL') {
      data = data.sort((a, b) => a.salary > b.salary)
    } else if ($('#searchOptions').val() == 'salaryLTH') {
      data = data.sort((a, b) => a.salary < b.salary)
    }
    showJobs(data)
  })

  $('#searchText').on('input', function () {
    var searchText = $('#searchText').val()
    var foundData = data.filter(x => x.location.toLowerCase().includes(searchText.toLowerCase()))
    showJobs(foundData)
  })
})