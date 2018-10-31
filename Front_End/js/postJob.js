if (localStorage.userType && localStorage.userData) {
  if (localStorage.userType == 'tutor')
    window.location.href = 'Profile.html'
} else {
  window.location.href = 'SignIn.html'
}

var parent = JSON.parse(localStorage.userData)

function validatePostData() {
  $('.errorMessage').text('');

  var isValid = true
  var title = $('#title').val()
  var gender = $('input[name=gender]:checked').val()
  var cls = $('#class').val()
  var dPW = $('#dPW').val()
  var salary = $('#salary').val()
  var preferable = $('#preferable').val()
  var subs = $('#subs').val()
  var medium = $('#medium').val()

  if (title.trim().length == 0) {
    $('#errMsgTitle').text('Title is required')
    isValid = false
  }
  if (gender == undefined) {
    $('#errMsgGender').text('Select Gender')
    isValid = false
  }
  if (cls.trim().length == 0) {
    $('#errMsgClass').text('Class is required')
    isValid = false
  }
  if (dPW == 0) {
    $('#errMsgDPW').text('Days Per Week is required')
    isValid = false
  }
  if (salary == 0) {
    $('#errMsgSalary').text('Salary is required')
    isValid = false
  }

  if (preferable.trim().length == 0) {
    $('#errMsgPreferable').text('Preferable is required')
    isValid = false
  }
  if (subs.trim().length == 0) {
    $('#errMsgSubs').text('Subject is required')
    isValid = false
  }
  if (medium.trim().length == 0) {
    $('#errMsgMedium').text('Medium is required')
    isValid = false
  }

  return isValid
}

function disableAttributes(isDisable = true) {
  $('input[type=text],[type=number],[type=radio]').attr("disabled", isDisable);
}

function newPost() {
  $('#newPost').show()
  $('#allPosts').hide()
}

function updatePost(postId) {
  var post = allPostData.find(post => post.postId == postId)
  if (post) {
    newPost()
    $('#title').val(post.title)
    $('input[name=gender]').filter(`[value=${post.gender}]`).prop('checked', true)
    $('#class').val(post.cls)
    $('#dPW').val(post.daysPerWeek)
    $('#salary').val(post.salary)
    $('#preferable').val(post.preferable)
    $('#subs').val(post.sub)
    $('#medium').val(post.medium)
    $('#submit').val('Update')
  }
}

function deletePost(postId) {
  $.ajax({
    url: 'http://localhost:54153/api/posts/' + postId,
    headers: {
        Authorization: 'Basic ' + localStorage.credential
    },
    method: 'delete',
    complete: function (xmlhttp) {
      if (xmlhttp.status == 204) {
        window.location.href = 'JobPost.html'
      }
      else {
        alert(xmlhttp.status + ": " + xmlhttp.statusText);
      }
    }
  });
}

function postToHtml(post) {
  return `<tr>
            <table class="post">
              <tr><td align="right">Title</td><td>${post.title}</td></tr>
              <tr><td align="right">Class</td><td>${post.cls}</td></tr>
              <tr><td align="right">Days Per Week</td><td>${post.daysPerWeek}</td></tr>
              <tr><td align="right">Salary</td><td>${post.salary}</td></tr>
              <tr><td align="right">Subjects</td><td>${post.sub}</td></tr>
              <tr><td align="right">Medium</td><td>${post.medium}</td></tr>
              <tr><td align="right">Gender</td><td>${post.gender}</td></tr>
              <tr><td align="right">Preferable</td><td>${post.preferable}</td></tr>
            </table>
            <input onclick="deletePost(${post.postId})" type="button" class="button" id="apply" value="Delete" style="background-color: rgb(170, 46, 46)">
          </tr>`
}
//<input onclick="updatePost(${post.postId})" type="button" class="button" id="apply" value="Update"> 

function showPosts() {
  var tableHtml = '<br><input onclick="newPost()" type="button" class="button" id="apply" value="Post New Job" style="background-color: rgb(28, 160, 64)">'
  tableHtml += '<table>'
  for (var i = 0; i < allPostData.length; i++) {
    tableHtml += postToHtml(allPostData[i])
  }
  tableHtml += '</table>'

  console.log(allPostData)
  $('#allPosts').html(tableHtml)
}

(function getPostData() {
  $.ajax({
    url: 'http://localhost:54153/api/posts/' + parent.parentId,
    headers: {
          Authorization: 'Basic ' + localStorage.credential
      },
    complete: function (xmlhttp) {
      if (xmlhttp.status == 200) {
        allPostData = xmlhttp.responseJSON;
        showPosts()
      } else {
        alert(xmlhttp.status + ": " + xmlhttp.statusText);
      }
    }
  })
})()

function sendPostData() {
  $.ajax({
    url,
    method,
    header: 'Content-Type: application/json',
    headers: {
        Authorization: 'Basic ' + localStorage.credential
    },
    data: postData,
    complete: function (xmlhttp) {
      if (xmlhttp.status == statusCode) {
        disableAttributes()
        $('#submit').val('Saved')
      }
      else {
        alert(xmlhttp.status + ": " + xmlhttp.statusText);
      }
    }
  });
}

$(function () {
  $('#submit').click(function () {
    if (validatePostData()) {
      postData = {
        title: $('#title').val(),
        gender: $('input[name=gender]:checked').val(),
        phone: parent.phone,
        daysPerWeek: $('#dPW').val(),
        salary: $('#salary').val(),
        preferable: $('#preferable').val(),
        location: parent.address,
        cls: $('#class').val(),
        medium: $('#medium').val(),
        sub: $('#subs').val(),
        parentEmail: parent.email,
        parentId: parent.parentId
      }

      if ($('#submit').val() == 'Save') {
        url = 'http://localhost:54153/api/posts'
        method = 'POST'
        statusCode = 201
        btnName = 'Update'
        sendPostData()
      } else if ($('#submit').val() == 'Update') {
        url = 'http://localhost:54153/api/posts/' + parent.parentId
        method = 'PUT'
        statusCode = 200
        btnName = 'Save'
        sendPostData()
      }
    }
  })
});