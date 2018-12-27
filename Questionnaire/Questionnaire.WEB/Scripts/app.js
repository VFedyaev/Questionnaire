const TYPE = "Тип";
const NUMBER = "Инвентаризационный номер";
const MODEL = "Модель";
const NAME = "Вариант ответа";

function menuInit() {
    $(document).ready(function () {
        $("#sidebar").mCustomScrollbar({
            theme: "minimal"
        });

        $('#sidebarCollapse').on('click', function () {
            $('#sidebar, #content, .navbar').toggleClass('active');
            $('.collapse.in').toggleClass('in');
            $('a[aria-expanded=true]').attr('aria-expanded', 'false');
        });
    });
}

function activeMenuItem() {
    turnOffCurrentActiveMenuItem();

    var url = window.location.href.toLowerCase();
    if (url.indexOf('user') >= 0) {
        $('#user-page-menu-item').addClass('active');
    }
    else if (url.indexOf('formdata') >= 0) {
        $('#formData-page-menu-item').addClass('active');
    }
    else if (url.indexOf('question') >= 0 || url.indexOf('questionType') >= 0 || url.indexOf('answer') >= 0) {
        $('#question-answer-page-menu-item').addClass('active');
        $('#questionAnswerDropdown').addClass('show');
    }
    else if (url.indexOf('surveygeography') >= 0 || url.indexOf('housingtype') >= 0 || url.indexOf('district') >= 0) {
        $('#survey-geography-page-menu-item').addClass('active');
        $('#surveyGeographyDropdown').addClass('show');
    }
    else if (url.indexOf('family') >= 0 || url.indexOf('form') >= 0 ||  url.indexOf('interviewer') >= 0) {
        $('#contacts-page-menu-item').addClass('active');
        $('#contactDropdown').addClass('show');
    }
    else if (url.indexOf('login') >= 0) {
        $('#login-page-menu-item').addClass('active');
    }
    else if (url.indexOf('changeemail') >= 0) {
        $('#change-email-page-menu-item').addClass('active');
    }
    else if (url.indexOf('changepassword') >= 0) {
        $('#change-password-page-menu-item').addClass('active');
    }
    else {
        $('#main-page-menu-item').addClass('active');
    }
    //else if (url.indexOf('form') >= 0) {
    //    $('#questionary-page-menu-item').addClass('active');
    //}
   
}

function turnOffCurrentActiveMenuItem() {
    var menuItems = [];
    menuItems.push($('#user-page-menu-item'));
    menuItems.push($('#question-answer-page-menu-item'));
    menuItems.push($('#survey-geography-page-menu-item'));
    menuItems.push($('#contacts-page-menu-item'));
    menuItems.push($('#login-page-menu-items'));
    menuItems.push($('#change-email-page-menu-item'));
    menuItems.push($('#change-password-page-menu-item'));
    menuItems.push($('#formData-page-menu-item'));
    menuItems.push($('#main-page-menu-item'));

    //menuItems.push($('#questionary-page-menu-item'));

    for (var i = 0; i < menuItems.length; i++) {
        if (menuItems[i].hasClass('active') >= 0) {
            menuItems[i].removeClass('active');
        }
    }
}

function getAge() {
    var today = new Date();
    var selectDate = new Date(document.getElementById("dateBorn").value);
    var age = today.getFullYear() - selectDate.getFullYear();
    document.getElementById("age").value = age;
}

function searchAnswersByEnter() {
    $(document).ready(function () {
        $("#search-input-value").keyup(function (event) {
            if (event.keyCode == 13) {
                searchAnswers('model');
            }
        });
    });
}

function clearSearch() {
    $("#found-items-area").empty();
    $("#search-input-value").val('');
}

function createTd(tdClass, value) {
    var td = document.createElement("td");
    td.className = tdClass;
    td.innerText = value;

    return td;
}

function searchAnswers(type) {
    var searchValue = $("#search-input-value").val();
    var token = $('input[name="__RequestVerificationToken"]').val();
    var oldSearchingText = document.getElementById('searching').innerText;

    document.getElementById('searching').innerText = "Идет поиск...";

    $.ajax({
        url: "/Answer/FindAnswers",
        type: "Post",
        data: {
            __RequestVerificationToken: token,
            "value": searchValue,
            "type": type
        },
        success: function (html) {
            $("#found-items-area").empty();
            $("#found-items-area").append(html);
            document.getElementById('searching').innerText = oldSearchingText;
        },
        error: function (XMLHttpRequest) {
            console.log(XMLHttpRequest);
            document.getElementById('searching').innerText = oldSearchingText;
        }
    });
    return false;
}

function attachAnswer(answerId) {
    if (document.body.contains(document.getElementById("pinned-" + answerId))) {
        alert("Комплектующее уже в списке.");
        return false;
    }

    var answerInfo = $("#" + answerId);
    var name = answerInfo.find("td.name")[0].innerText;

    var inputId = document.createElement("input");
    inputId.type = "hidden";
    inputId.name = "answerId[]";
    inputId.value = answerId;

    var nameDiv = createDiv("name", NAME, name);



    var wrapDiv = document.createElement("div");
    wrapDiv.classList.add("col-md-8", "item");

    var newAnswer = document.createElement("div");
    newAnswer.className = "row";
    newAnswer.id = "pinned-" + answerId;

    wrapDiv.appendChild(inputId);
    wrapDiv.appendChild(nameDiv);

    wrapDiv.appendChild(createElement("br"));

    newAnswer.appendChild(wrapDiv);

    var attachedItems = document.getElementById("attached-items");
    attachedItems.appendChild(newAnswer);
}

function createElement(element) {
    return document.createElement(element);
}

function createDiv(divClass, title, value, answerId) {
    var buttonDiv = createButtonDiv(answerId);

    var wrapDiv = document.createElement("div");
    wrapDiv.classList.add(divClass, "row", "item-info-row");

    var firstDiv = document.createElement("div");
    firstDiv.classList.add("col-md-3", "item-info");

    var bold = document.createElement("b");
    bold.innerText = title;

    firstDiv.appendChild(bold);

    var secondDiv = document.createElement("div");
    secondDiv.classList.add("col-md-6", "item-info");
    secondDiv.innerText = value;

    var thirdDiv = document.createElement("div");
    thirdDiv.classList.add("col-md-3", "item-info");
    thirdDiv.appendChild(buttonDiv);

    wrapDiv.appendChild(firstDiv);
    wrapDiv.appendChild(secondDiv);
    wrapDiv.appendChild(thirdDiv);

    wrapDiv.appendChild(createElement("br"));
    wrapDiv.appendChild(createElement("br"));

    return wrapDiv;
}

function createButtonDiv(answerId) {
    var removeBtn = createRemoveButton(answerId);
    var detailsBtn = createDetailsButton(answerId);

    var buttonDiv = document.createElement("div");
    buttonDiv.className = "btn-group";
    buttonDiv.classList.add("btn-group", "float-right");

    buttonDiv.appendChild(removeBtn);
    buttonDiv.appendChild(detailsBtn);

    return buttonDiv;
}

function createRemoveButton(answerId) {
    var button = document.createElement("button");
    button.classList.add("btn", "btn-danger", "btn-sm");
    button.type = "button";
    button.setAttribute("onclick", "detachItem('" + answerId + "')");
    button.innerText = "Убрать";

    return button;
}

function createDetailsButton(answerId) {
    var button = document.createElement("a");
    button.setAttribute("href", "/Answer/Details?id=" + answerId);
    button.classList.add("btn", "btn-primary", "btn-sm");
    button.setAttribute("target", "_blank");
    button.innerText = "Подробности";

    return button;
}

function detachItem(id) {
    var toRemove = $("#pinned-" + id);
    toRemove.remove();
}

function modalRemovalWindow(url) {
    $(document).ready(function () {
        var firstPaginationPage = $('.pagination li:nth-child(2)>a');
        var elementId;
        $('.delete-prompt').on('click', function () {
            elementId = $(this).attr('id');
            $('#myModal').modal('show');
        });

        $('.delete-confirm').on('click', function () {
            var token = $('input[name="__RequestVerificationToken"]').val();
            if (elementId != '') {
                $.ajax({
                    url: url,
                    type: 'Post',
                    data: {
                        __RequestVerificationToken: token,
                        'id': elementId
                    },
                    success: function (data) {
                        if (data == 'Удаление невозможно.') {
                            $('.delete-confirm').css('display', 'none');
                            $('.delete-cancel').html('Закрыть');
                            $('.success-message').html('Удаление невозможно, у записи есть связи!');
                        }
                        else if (data) {
                            $("#" + elementId).remove();
                            $('#myModal').modal('hide');
                            //$.notify("Запись удалена успешно!", "success");
                            location.reload();
                        }
                    }, error: function (err) {
                        if (!$('.modal-header').hasClass('alert-danger')) {
                            $('.modal-header').removeClass('alert-success').addClass('alert-danger');
                            $('.delete-confirm').css('display', 'none');
                        }
                        $('.success-message').html(err.statusText);
                    }
                });
            }
        });
        //function to reset bootstrap modal popups
        $("#myModal").on("hidden.bs.modal", function () {
            $('.delete-confirm').css('display', 'inline-block');
            $('.delete-cancel').html('Нет');
            $('.success-message').html('').html('Вы действительно хотите удалить запись?');
        });
    });
}

function hideAccordion() {
    $("#accordion").hide();
}

function removeListAndPagination() {
    $("#listTable").remove();
    $("#paginationToDelete").remove();
}

function toPrevMain(from = "") {
    if (from == "list") {
        $("#employee-list").empty();
    } else if (from == "admin") {
        $("#name").val("");
        $("#position-select-list").val("");
        $("#department-select-list").val("");
        $("#administration-select-list").val("");
        $("#division-select-list").val("");
        $("#results").empty();
    } else {
        $("#results").empty();
    }
    $("#accordion").show();
}

function closeMessageDiv() {
    $("#message-div").remove();
}

$('.form-submit').on('click', function (e) {
    e.preventDefault();
    var numberFormReuqired = $('#numberFormRequired').val();
    var addressReuqired = $('#addressRequired').val();
    var surveyGeographyReuqired = $('#surveyGeographyIdDropDown').val();
    var housingTypeRequired = $('#housingTypeIdDropDown').val();
    var districtRequired = $('#districtIdDropDown').val();
    var interviewerRequired = $('#interviewerIdDropDown').val();

    var questionTypeRequired = $('#questionTypeDropDown').val();
    var questionNameReuqired = $('#questionNameRequired').val();

    var answerNameReuqired = $('#answerNameRequired').val();

    var validationError = $('.alert');
    var form = $('form');
    var self = $(this);
    $.post({
        url: form.attr("action"),
        data: form.serialize(),

        success: function (response) {
            if (response.hasError) {
                alert("Такая запись уже существует в базе данных!");
            }
            else if (numberFormReuqired == "" ||
                addressReuqired == "" ||
                surveyGeographyReuqired == "" ||
                housingTypeRequired == "" ||
                districtRequired == "" ||
                interviewerRequired == "" ||
                questionTypeRequired == "" ||
                questionNameReuqired == "" ||
                answerNameReuqired == "") {

                validationError.show();
            }
            else
                window.location.href = self.data("redirect-to");
        }
    })
});

function markAnswerAsSelected() {
    $(document).ready(function () {
        $('input[type=radio][name=option]').change(function () {
            var parentClasses = this.parentNode.parentNode.classList;
            if (parentClasses.contains('selected')) {
                this.parentNode.parentNode.classList.remove('selected');
            } else {
                this.parentNode.parentNode.classList.add('selected');
            }
        });
    });
}

function saveForm() {
    var token = $('input[name="__RequestVerificationToken"]').val();
    var formId = $("#FormId").val();
    if (formId.length <= 0) {
        alert("Выберите номер анкеты.");
        return false;
    }

    var selectedOptions = $('.option:checked');
    var selectedOptionsValues = [];
    for (var i = 0; i < selectedOptions.length; i++) {
        selectedOptionsValues.push(selectedOptions[i].value);
    }

    var selectedOptionsWithText = $('.option-with-text:checked');
    var selectedOptionsWithTextValues = [];
    for (var k = 0; k < selectedOptionsWithText.length; k++) {
        var text = selectedOptionsWithText[k].parentNode.parentNode.getElementsByClassName('option-text')[0].value;
        selectedOptionsWithTextValues.push([selectedOptionsWithText[k].value, text]);
    }

    $.ajax({
        url: "/FormData/SaveForm",
        type: "Post",
        data: {
            __RequestVerificationToken: token,
            "formId": formId,
            "options": selectedOptionsValues,
            "optionsWithComment": selectedOptionsWithTextValues
        },
        success: function (success) {
            if (success) {
                document.getElementById("form-saved-success").classList.remove("d-none");
            } else {
                document.getElementById("form-saved-failed").classList.remove("d-none");
            }
            scrollToTop();
        },
        error: function (XmlHttpRequest) {
            document.getElementById("form-saved-failed").classList.remove("d-none");
            scrollToTop();
            console.log(XmlHttpRequest.responseText);
        }
    });
    return false;
}

function scrollToTop() {
    $('html,body').animate({ scrollTop: 0 }, 'fast');
}

function closeSuccessFormSaveMessage() {
    document.getElementById("form-saved-success").classList.add("d-none");
}

function closeFailedFormSaveMessage() {
    document.getElementById("form-saved-failed").classList.add("d-none");
}

function removeDataConfirm() {
    var confirmation = confirm("Вы уверены, что хотите удалить данные анкеты?");
    if (!confirmation) {
        return false;
    }
}